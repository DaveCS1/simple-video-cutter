using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.TempControlTest
{
    public partial class RadFormWaitingBar : Telerik.WinControls.UI.RadForm
    {
        public RadFormWaitingBar()
        {
            InitializeComponent();
            load();
        }
       

        private void load()
        {
            //using (var aTimer = new System.Timers.Timer(10000))
            //{ aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;

            //}
 radWaitingBar1.Visible=true;
            radWaitingBar1.StartWaiting();
           
                var aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            radPictureBox1.Image = Image.FromFile("head roll ko 4_Trim.jpg");
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime);
            if (true)
            {

            }
            stop();
   
        }
        private void stop()
        {
   radWaitingBar1.InvokeIfRequired(() =>
            {
                 radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible=false;
            });
            //radWaitingBar1.StopWaiting();
            //radWaitingBar1.Visible = false;
            //this.Controls.Remove(radWaitingBar1);
        }
        /*
*  timer = new System.Timers.Timer(2000);
// Hook up the Elapsed event for the timer. 
timer.Elapsed += OnTimedEvent;
timer.AutoReset = true;
timer.Enabled = true;
The OnTimedEvent should look like this:

private static void OnTimedEvent(Object source, ElapsedEventArgs e)
{
Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
             e.SignalTime);
}
If you need to Stop the timer you should call:

timer.Stop();
timer.Dispose();*/
    }
}
