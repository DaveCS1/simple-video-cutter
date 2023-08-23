using LibVLCSharp.Shared;
using SimpleVideoCutter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter.TelerikForms
{
    public partial class RadMainForm : Telerik.WinControls.UI.RadForm
    {
        //private LibVLC libVLC;
        //private string lastDirectory = null;
        //private string fileBeingPlayed = null;
        //private TaskProcessor taskProcessor = new TaskProcessor();
        //private KeyFramesExtractor keyFramesExtractor = new KeyFramesExtractor();
        //private int volume = 100;
        //private FormSettings formSettings;
        //private string fileToLoadOnStartup = null;
        //private Debouncer debouncerHover = new Debouncer();
        //private bool playingSelection = false;

        //private bool EnsureFFmpegConfigured()
        //{
        //    if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
        //    {
        //        using (var dialog = new FormFFmpegMissingDialog())
        //        {
        //            dialog.Owner = this;
        //            dialog.ShowDialog();
        //            if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
        //            {
        //                formSettings.ShowSettingsDialog();
        //            }
        //        }

        //        return false;
        //    }
        //    return true;
        //}


        #region VLCcontrols
        private LibVLC libVLC;
        private string lastDirectory = null;
        private string fileBeingPlayed = null;
        private TaskProcessor taskProcessor = new TaskProcessor();
        private KeyFramesExtractor keyFramesExtractor = new KeyFramesExtractor();
        private int volume = 100;
        private FormSettings formSettings;
        private string fileToLoadOnStartup = null;
        private Debouncer debouncerHover = new Debouncer();
        private bool playingSelection = false;

        //   this.videoViewHover.Visible = VideoCutterSettings.Instance.ShowPreview;


        private bool EnsureFFmpegConfigured()
        {
            if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
            {
                using (var dialog = new FormFFmpegMissingDialog())
                {
                    dialog.Owner = this;
                    dialog.ShowDialog();
                    if (VideoCutterSettings.Instance.FFmpegPath == null || !File.Exists(VideoCutterSettings.Instance.FFmpegPath))
                    {
                        formSettings.ShowSettingsDialog();
                    }
                }

                return false;
            }
            return true;
        }


        //normally is loaded in app
        //string fileToLoadOnStartup = null;
        static string svcFolder = "SimpleVideoCutter";
        string configFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), svcFolder);
        private void InitVLC()
        {
            this.fileToLoadOnStartup = null; //fileToLoadOnStartup;
            VideoCutterSettings.Instance.ConfigFolder = configFolder;
            VideoCutterSettings.Instance.LoadSettings();

            if (VideoCutterSettings.Instance.Language == null)
            {
                VideoCutterSettings.Instance.Language = Thread.CurrentThread.CurrentUICulture.Name;
            }
            else
            {
                var culture = CultureInfo.GetCultureInfo(VideoCutterSettings.Instance.Language);
                if (culture != null)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                    CultureInfo.DefaultThreadCurrentUICulture = culture;
                }
            }

            formSettings = new FormSettings();
            voidLoadVLC();
            TempPlay();
        }

        private void voidLoadVLC() //from form load
        {
            Core.Initialize();

            // Full list of command line arguments: https://wiki.videolan.org/VLC_command-line_help

            var args = new List<string>(new string[] {
                "--play-and-pause",
                "--no-sub-autodetect-file",
            });

            if (!VideoCutterSettings.Instance.Autostart)
            {
                args.Add("--no-playlist-autostart");
                args.Add("--start-paused");
            }

            libVLC = new LibVLC(args.ToArray());

            vlcControl1.MediaPlayer = new MediaPlayer(libVLC);
            videoViewHover.MediaPlayer = new MediaPlayer(libVLC);

            vlcControl1.MediaPlayer.MediaChanged += VlcControl1_MediaChanged;
            vlcControl1.MediaPlayer.LengthChanged += VlcControl1_LengthChanged;
            vlcControl1.MediaPlayer.Playing += VlcControl1_Playing;
            vlcControl1.MediaPlayer.Paused += VlcControl1_Paused;
            vlcControl1.MediaPlayer.Stopped += VlcControl1_Stopped;
            vlcControl1.MediaPlayer.PositionChanged += VlcControl1_PositionChanged;
            vlcControl1.MediaPlayer.EndReached += VlcControl1_EndReached;
            vlcControl1.MouseWheel += VlcControl1_MouseWheel;
            vlcControl1.MediaPlayer.TimeChanged += VlcControl1_TimeChanged;
            vlcControl1.MediaPlayer.EnableMouseInput = false;
            vlcControl1.MediaPlayer.EnableKeyInput = false;

            videoViewHover.MediaPlayer.Volume = 0;
            videoViewHover.MediaPlayer.EnableKeyInput = false;
            videoViewHover.MediaPlayer.TimeChanged += VideoViewerHover_MediaPlayer_TimeChanged;
            videoViewHover.Visible = false;

            videoCutterTimeline1.SelectionChanged += VideoCutterTimeline1_SelectionChanged;
            videoCutterTimeline1.TimelineHover += VideoCutterTimeline1_TimelineHover;
            videoCutterTimeline1.PositionChangeRequest += VideoCutterTimeline1_PositionChangeRequest;
            videoCutterTimeline1.KeyframesRequest += VideoCutterTimeline1_KeyframesRequest;

            taskProcessor.PropertyChanged += TaskProcessor_PropertyChanged;
            taskProcessor.TaskProgress += TaskProcessor_TaskProgress;
            keyFramesExtractor.KeyFramesExtractorProgress += KeyFramesExtractor_KeyFramesExtractorProgress;

            if (VideoCutterSettings.Instance.RestoreToolbarsLayout)
                ToolStripManager.LoadSettings(this, "SimpleVideoCutterMainForm");

            VideoCutterSettings.Instance.RestoreToolbarsLayout = true;

            //var latestRelease = await GitHubVersionCheck.GetLatestReleaseVersionFromGitHub();
            //if (latestRelease != null && latestRelease != Utils.GetCurrentRelease())
            //{
            //    this.toolStripButtonInternetVersionCheck.ForeColor = Color.Red;
            //}

            //ResizePreview();

        }

        //other events etc  some may need to be replaced
        private void VlcControl1_EndReached(object sender, EventArgs e)
        {
            var length = (int)vlcControl1.MediaPlayer.Length;
            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = length;
            });
            //EnableButtons();
        }

        private void VlcControl1_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            AckPositionChange((long)(e.Position * vlcControl1.MediaPlayer.Length));
        }

        private void AckPositionChange(long position)
        {
            var length = (long)vlcControl1.MediaPlayer.Length;

            if (!videoCutterTimeline1.Selections.Empty && playingSelection)
            {
                long? adjustedPosition = videoCutterTimeline1.Selections.FindNextValidPosition(position);
                if (adjustedPosition == null)
                {
                    if (vlcControl1.MediaPlayer.IsPlaying)
                    {
                        vlcControl1.MediaPlayer.SetPause(true);
                        vlcControl1.MediaPlayer.Position = (float)videoCutterTimeline1.Selections.OverallEnd.Value / vlcControl1.MediaPlayer.Length;
                    }
                }
                else if (adjustedPosition.Value != position)
                {
                    position = adjustedPosition.Value;
                    var mediaPlayerPosition = (float)position / vlcControl1.MediaPlayer.Length;
                    if (mediaPlayerPosition != vlcControl1.MediaPlayer.Position)
                    {
                        vlcControl1.MediaPlayer.Position = mediaPlayerPosition;
                    }
                }
            }

            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = position;
            });
            //EnableButtons();
        }

        private void VlcControl1_LengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
            var length = vlcControl1.MediaPlayer.Length;
            var time = vlcControl1.MediaPlayer.Time;

            videoCutterTimeline1.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Length = length;
            });
            //EnableButtons();
        }

        private void VlcControl1_Stopped(object sender, EventArgs e)
        {
            playingSelection = false;
            //EnableButtons();
        }

        private void VlcControl1_Paused(object sender, EventArgs e)
        {
            playingSelection = false;
            var length = vlcControl1.MediaPlayer.Length;
            var position = vlcControl1.MediaPlayer.Position;
            this.InvokeIfRequired(() =>
            {
                videoCutterTimeline1.Position = (int)(position * length);
            });
            //EnableButtons();
        }

        private void VlcControl1_MediaChanged(object sender, MediaPlayerMediaChangedEventArgs e)
        {
            var fi = new FileInfo(fileBeingPlayed);
            string fileInfo = string.Format("{0:yyyy/MM/dd HH:mm:ss}", fi.LastWriteTime);
            //statusStrip.InvokeIfRequired(() =>
            //{
            //    toolStripStatusLabelFileDate.Text = fileInfo;
            //});
            //EnableButtons();

        }

        private void VlcControl1_Playing(object sender, EventArgs e)
        {
            //EnableButtons();
        }

        private void OpenFile()
        {
            if (lastDirectory == null)
            {
                lastDirectory = ReplaceStandardDirectoryPatterns(VideoCutterSettings.Instance.DefaultInitialDirectory);
            }
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.InitialDirectory = lastDirectory;
                fd.RestoreDirectory = true;

                var filter = $"{GlobalStrings.MainForm_AllVideoFiles}|" + string.Join(";", VideoCutterSettings.Instance.VideoFilesExtensions.Select(ex => "*" + ex).ToArray());
                fd.Filter = filter;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    lastDirectory = Path.GetDirectoryName(fd.FileName);
                    OpenFile(fd.FileName);
                }
            }
        }

        private string ReplaceStandardDirectoryPatterns(string str)
        {
            return str
                .Replace("{SameFolder}", Path.GetDirectoryName(fileBeingPlayed))
                .Replace("{UserVideos}", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                .Replace("{UserDocuments}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                .Replace("{MyComputer}", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        }
        private string ReplaceFilePatterns(string str, string path)
        {
            var fileInfo = new FileInfo(path);

            return str
                .Replace("{FileName}", Path.GetFileName(path))
                .Replace("{FileNameWithoutExtension}", Path.GetFileNameWithoutExtension(path))
                .Replace("{FileExtension}", Path.GetExtension(path))
                .Replace("{FileDate}", string.Format("{0:yyyyMMdd-HHmmss}", fileInfo.LastWriteTime))
                .Replace("{Timestamp}", string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now))
                .Replace("{SelectionStart}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallStart.Value)))
                .Replace("{SelectionEnd}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallEnd.Value)))
                .Replace("{SelectionStartMs}", string.Format("{0}", this.videoCutterTimeline1.Selections.OverallStart.Value))
                .Replace("{SelectionEndMs}", string.Format("{0}", this.videoCutterTimeline1.Selections.OverallEnd.Value))
                .Replace("{Duration}", string.Format("{0:hhmmss}", TimeSpan.FromMilliseconds(this.videoCutterTimeline1.Selections.OverallDuration)));
        }

        private void TempPlay() //for intial testing purposes, delete after files can load from ui
        {
            fileBeingPlayed = "BlankVideo.mp4";
            //statusStrip.InvokeIfRequired(() =>
            //{
            //    toolStripStatusLabelFilePath.Text = path;
            //});
            string path = AppDomain.CurrentDomain.BaseDirectory + "BlankVideo.mp4";
            Console.WriteLine(path);
            if (!File.Exists(path)) { MessageBox.Show("Error loading media file"); return; }

            if (vlcControl1.MediaPlayer.IsPlaying)
            {
                vlcControl1.MediaPlayer.Stop();
            }

            //ClearAllSelections();
            //UpdateIndexLabel();
            //EnableButtons();

            vlcControl1.MediaPlayer.Mute = VideoCutterSettings.Instance.Mute;
            vlcControl1.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath));
            videoViewHover.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath));

            keyFramesExtractor.Start(path);
        }

        private void OpenFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            fileBeingPlayed = path;
            //statusStrip.InvokeIfRequired(() =>
            //{
            //    toolStripStatusLabelFilePath.Text = path;
            //});

            if (vlcControl1.MediaPlayer.IsPlaying)
            {
                vlcControl1.MediaPlayer.Stop();
            }

            //ClearAllSelections();
            //UpdateIndexLabel();
            //EnableButtons();

            vlcControl1.MediaPlayer.Mute = VideoCutterSettings.Instance.Mute;
            vlcControl1.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath));
            videoViewHover.MediaPlayer.Play(new Media(libVLC, path, FromType.FromPath));

            keyFramesExtractor.Start(path);
        }

        private void vlcControl1_MouseClick(object sender, MouseEventArgs e)
        {
            PlayPause();
        }

        private void PlayPause()
        {
            if (vlcControl1.MediaPlayer.State == VLCState.Ended || vlcControl1.MediaPlayer.State == VLCState.Stopped)
            {
                vlcControl1.MediaPlayer.Play(new Media(libVLC, fileBeingPlayed, FromType.FromPath));
                //EnableButtons();
            }
            else
            {
                vlcControl1.MediaPlayer.Pause();
                //EnableButtons();
            }
        }


        private void NextFrame()
        {
            if (fileBeingPlayed != null)
            {
                vlcControl1.MediaPlayer.NextFrame();
                videoCutterTimeline1.InvokeIfRequired(() =>
                {
                    videoCutterTimeline1.Position = (int)(vlcControl1.MediaPlayer.Position * vlcControl1.MediaPlayer.Length);
                });
            }
        }

        private void SetStartAtCurrentPosition()
        {
            // RegisterNewSelectionStart raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.RegisterNewSelectionStart(videoCutterTimeline1.Position);
        }
        private void SetEndAtCurrentPosition()
        {
            // RegisterNewSelectionEnd raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            videoCutterTimeline1.RegisterNewSelectionEnd(videoCutterTimeline1.Position);
        }

        private void SetSelectionAtCurrentPositionTillTheEnd()
        {
            MessageBox.Show("TODO");
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            //videoCutterTimeline1.SetSelection(videoCutterTimeline1.Position, videoCutterTimeline1.Length);
        }

        private void SetSelectionFromTheBeginningTillCurrentPosition()
        {
            MessageBox.Show("TODO");
            // SetSelection raises SelectionChanged event, see VideoCutterTimeline1_SelectionChanged
            //videoCutterTimeline1.SetSelection(0, videoCutterTimeline1.Position);
        }

        private void GoToSelectionStart()
        {
            if (videoCutterTimeline1.Selections.OverallStart != null)
            {
                var position = videoCutterTimeline1.Selections.OverallStart.Value;
                vlcControl1.MediaPlayer.Position = (float)position / vlcControl1.MediaPlayer.Length;
                videoCutterTimeline1.GoToPosition(position);
                AckPositionChange(position);
            }
        }

        private void GoToSelectionEnd()
        {
            if (videoCutterTimeline1.Selections.OverallEnd != null)
            {
                var position = videoCutterTimeline1.Selections.OverallEnd.Value;
                vlcControl1.MediaPlayer.Position = (float)position / vlcControl1.MediaPlayer.Length;
                videoCutterTimeline1.GoToPosition(position);
                AckPositionChange(position);
            }
        }

        private void VideoCutterTimeline1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateSelectionLabel();
            //EnableButtons();
        }


        private void RefreshTasks()
        {
            listViewTasks.InvokeIfRequired(() =>
            {
                var tasks = taskProcessor.GetTasks().Reverse();

                listViewTasks.Items.Clear();
                listViewTasks.Items.AddRange(tasks.Select(
                    task =>
                    {
                        var item = new ListViewItem(task.StateLabel);
                        item.SubItems.Add(string.Format("{0}", task.Lossless ?
                            GlobalStrings.MainForm_Lossless : GlobalStrings.MainForm_ReEncoding));
                        item.SubItems.Add(string.Format("{0}", task.InputFileName));
                        item.SubItems.Add(string.Format("{0} sec", Math.Round(task.OverallDuration / 1000.0f, 1)));
                        item.SubItems.Add(string.Format("{0}", task.OutputFilePath));
                        item.SubItems.Add(string.Format("{0}", task.ErrorMessage));
                        if (task.State == FFmpegTaskState.FinishedError)
                            item.BackColor = Color.Tomato;
                        return item;
                    }).ToArray());

                listViewTasks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                columnStatus.Width = 80;
            });
        }
        private void TaskProcessor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tasks")
            {
                RefreshTasks();
            }
        }

        private void TaskProcessor_TaskProgress(object sender, TaskProgressEventArgs e)
        {
            labelProgress.InvokeIfRequired(() =>
            {
                labelProgress.Text = e.ProgressText;
            });
        }


        private void KeyFramesExtractor_KeyFramesExtractorProgress(object sender, KeyFramesExtractorProgressEventArgs e)
        {
            Action safeRefresh = delegate { videoCutterTimeline1.Refresh(); };
            videoCutterTimeline1.Invoke(safeRefresh);
        }
        private void VlcControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            volume = volume + (e.Delta / 120 * 10);
            if (volume < 0)
                volume = 0;
            else if (volume > 200)
                volume = 200;

            //statusStrip.InvokeIfRequired(() =>
            //{
            //    toolStripStatusLabelVolume.Text = $"{GlobalStrings.MainForm_Volume}: {volume} %";
            //});

            vlcControl1.MediaPlayer.Volume = volume;
        }


        private void VlcControl1_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
        }
        private void VideoViewerHover_MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            if (videoViewHover.MediaPlayer.IsPlaying)
                videoViewHover.MediaPlayer.Pause();
        }
        private void VideoCutterTimeline1_TimelineHover(object sender, TimelineHoverEventArgs e)
        {
            timerHoverPositionChanged.Start();
        }

        private void VideoCutterTimeline1_PositionChangeRequest(object sender, PositionChangeRequestEventArgs e)
        {
            vlcControl1.MediaPlayer.Position = (float)e.Position / vlcControl1.MediaPlayer.Length;
            videoCutterTimeline1.Position = e.Position;
        }

        private void VideoCutterTimeline1_KeyframesRequest(object sender, KeyframesRequestEventArgs e)
        {
            e.Keyframes = keyFramesExtractor.Keyframes;
            e.InProgress = keyFramesExtractor.InProgress;
        }
        #endregion





        //end
    }

}
