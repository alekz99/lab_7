using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
{
    public partial class ColorPicker : Form
    {
        public ColorPicker()
        {
            InitializeComponent();
            NewColor();
        }

        private void NewColor()
        {
            panel1.BackColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            Clipboard.Clear();
            Clipboard.SetText($"#{trackBarRed.Value:X}{trackBarGreen.Value:X}{trackBarBlue.Value:X}");
            toolTip1.SetToolTip(panel1, Clipboard.GetText());
        }

        private void trackBarGreen_Scroll(object sender, EventArgs e)
        {
            NewColor();
        }

        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            NewColor();
        }

        private void trackBarBlue_Scroll(object sender, EventArgs e)
        {
            NewColor();
        }
    }
}
