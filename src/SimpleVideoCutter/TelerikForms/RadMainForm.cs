using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SimpleVideoCutter.TelerikForms
{
    public partial class RadMainForm : Telerik.WinControls.UI.RadForm
    {
        public RadMainForm()
        {
            InitializeComponent();
        }

        private void RadMainForm_Load(object sender, EventArgs e)
        {
            //radCommandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            string fileToLoadOnStartup = null;
            string svcFolder = "SimpleVideoCutter";
            string configFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), svcFolder);
            var t = new SimpleVideoCutter.MainForm( fileToLoadOnStartup , configFolder);
            t.Show();
            //MainForm mainForm = new MainForm(string fileToLoadOnStartup, string configFolder);
            //mainForm.Show();
        }


        //trim videos tab
        private void commandBarButton2_Click(object sender, EventArgs e)
        {
            radPageView1.SelectedPage = radPageViewPageTrimVideos;

           
        }
        public List<string> FullVideoPaths { get; set; } = new List<string>();
        private void radButton2_Click(object sender, EventArgs e)
        {
            FullVideoPaths.Clear();
            this.radOpenFolderDialogSelectVideos.OpenFolderDialogForm.ThemeName = "FluentDark";
            this.radOpenFolderDialogSelectVideos.MultiSelect = true;
            this.radOpenFolderDialogSelectVideos.ShowDialog(this);


            var x1 = radOpenFolderDialogSelectVideos.OpenFolderDialogForm.FileNames;
            var s = radOpenFolderDialogSelectVideos.FileName;
            var t = radOpenFolderDialogSelectVideos.FileNames;
            var cnt = t.Count();
            if (cnt > 0)
            {
                foreach (var item in radOpenFolderDialogSelectVideos.FileNames)
                {//todo use global settings for video extentions
                    string[] files = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories).Where(file => new string[] { ".avi", ".flv", ".mp4", ".mpg", ".mov" }.Contains(Path.GetExtension(file))).ToArray();
                    Array.Sort(files, (x, y) => DateTime.Compare(new FileInfo(x).LastWriteTime, new FileInfo(y).LastWriteTime));
                    FullVideoPaths.AddRange(files);
                }

            }
            Console.WriteLine(FullVideoPaths.Count);
            this.radCheckedListBox1.DataSource = FullVideoPaths;

        }

        private void radMenuButtonItem1_Click(object sender, EventArgs e)
        {
            radMenu1.BackColor = radPageViewPageAddFiles.BackColor;

            RadMenuContentItem textBoxContentItem = new RadMenuContentItem();
            RadTextBoxElement textBox = new RadTextBoxElement();
            textBox.Text = "Enter text here";
            textBox.MinSize = new Size(100, 0);
            textBoxContentItem.ContentElement = textBox;
            radMenu1.Items.Add(textBoxContentItem);
            RadMenuContentItem buttonContentItem = new RadMenuContentItem();
            RadButtonElement button = new RadButtonElement();
            button.Text = "OK";
            //button.Click += new EventHandler(button_Click);
            buttonContentItem.ContentElement = button;
            radMenu1.Items.Add(buttonContentItem);
        }

        private void radSplitButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private void radTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            radPopupEditor1.Text= radTrackBar2.Value.ToString();
        }

        private void radPopupContainer2_Click(object sender, EventArgs e)
        {

        }

        private void radPopupContainer3_Click(object sender, EventArgs e)
        {

        }
        //  explorerControl1.ThemeName = "FluentDark";
        //  explorerControl1.MultiSelect = true;
    }
}
