using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public class DavButton : Button
    {
        private Color DefaultColor { get; set; }

        public DavButton()
        {
            this.Size = new Size(105,43);
            this.Cursor = Cursors.Hand;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.LightGray;
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(0, 123, 255);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!Enabled)
            {
                BackColor = Color.LightGray;
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                BackColor = DefaultColor;
            }
            base.OnEnabledChanged(e);
        }

    }
}
