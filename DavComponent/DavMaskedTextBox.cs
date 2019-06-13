using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DavComponent
{
    public class DavMaskedTextBox : MaskedTextBox
    {

        public DavMaskedTextBox()
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }

            base.OnKeyDown(e);
        }
    }
}
