using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SimpleVideoCutter.Windows
{
    public partial class RadDisplayCurrentFilesToPlayWindow : Telerik.WinControls.UI.RadForm
    {
        public RadDisplayCurrentFilesToPlayWindow(IList<string> list)
        {
            InitializeComponent();
            radListControl1.DataSource = list;
            this.radLblVideosToViewCurrentlyCount.Text = String.Format("Number Of Videos In Directory  {0}", list.Count);

        }
       
    }
}
