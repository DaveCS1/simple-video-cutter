using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter.Util
{
    /*usage
    private void InitializeComponents()
    {
        // Create controls and set their Tag properties
        Button button1 = new Button { Text = "Button 1", Tag = "Tag1" };
        Button button2 = new Button { Text = "Button 2", Tag = "Tag2" };
        TextBox textBox1 = new TextBox { Text = "TextBox 1", Tag = "Tag1" };

        // Add controls to the form
        Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(textBox1);

        // Get controls with a specific Tag value
        List<Control> matchingControls = this.GetControlsByTag("Tag1");

        // Display the matching controls (for demonstration purposes)
        foreach (Control control in matchingControls)
        {
            Console.WriteLine($"Control Name: {control.Name}, Tag: {control.Tag}");
        }
    //}*/

    public static class GetVideoTrimControls
    {
        public static List<Control> GetControlsByTag(this Control control, object tagValue)
        {
            try
            {
                List<Control> matchingControls = new List<Control>();

                foreach (Control childControl in control.Controls)
                {
                    if (childControl.Tag != null && childControl.Tag.Equals(tagValue))
                    {
                        matchingControls.Add(childControl);
                    }

                    matchingControls.AddRange(childControl.GetControlsByTag(tagValue));
                }

                return matchingControls;
            }
            catch (Exception ex)
            {               
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
    }
}
