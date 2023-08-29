using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter.Util
{
    /// <summary>
    /// Finds the controls on the form by type of control "Button" etc.
    ///var controls= this.FindChildControlsOfType<CheckBox>();
    ///
    /// </summary>
    public static class FindFormChildControls
    {
// var checkBoxes = tableLayoutPanel1.FindChildControlsOfType<CheckBox>();

//foreach (var checkBox in checkBoxes)
//{
//    checkBox.Checked = false;
//}

    public static IEnumerable<TControl> FindChildControlsOfType<TControl>(this Control control) where TControl : Control
        {
            foreach (var childControl in control.Controls.Cast<Control>())
            {
                if (childControl.GetType() == typeof(TControl))
                {
                    yield return (TControl)childControl;
                }
                else
                {
                    foreach (var next in FindChildControlsOfType<TControl>(childControl))
                    {
                        yield return next;
                    }
                }
            }
        }
    }
}
