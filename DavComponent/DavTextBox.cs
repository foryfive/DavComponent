using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavComponent
{
    public class DavTextBox : TextBox
    {
        public bool DavHabilitarTabulacionEnter { get; set; } = true;
        public bool DavSoloNumero { get; set; } = false;
        public string DavFormatoNumero { get; set; } = "###,###,###,###.00";
        public double DavMaximo { get; set; } = 999999999;
        public bool DavMostrarVacio { get; set; } = true;
        public bool DavIsFloat { get; set; } = false;

        public double Value
        {
            get
            {
                double.TryParse(this.Text, out double valor);
                return valor;
            }
            set
            {
                if (this.ContainsFocus)
                    this.Text = value.ToString();
                else
                {
                    if (DavMostrarVacio)
                    {
                        if (DavSoloNumero)
                            this.Text = value == 0 ? string.Empty : value.ToString(DavFormatoNumero);
                        else
                            this.Text = value == 0 ? string.Empty : value.ToString();
                    }
                    else
                    {
                        if (DavSoloNumero)
                            this.Text = value.ToString(DavFormatoNumero);
                        else
                            this.Text = value.ToString();
                    }

                }
            }
        }

        public DavTextBox()
        {
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9);
            if (DavSoloNumero)
            {
                this.TextAlign = HorizontalAlignment.Right;
            }

        }
        protected override void OnClick(EventArgs e)
        {
            if (DavSoloNumero)
            {
                this.Select(0, 9999999);
            }
            base.OnClick(e);
        }
        public double GetValue()
        {
            double.TryParse(this.Text, out double valor);
            return valor;
        }
        public int GetIntValue()
        {
            int.TryParse(this.Text, out int valor);
            return valor;
        }
        protected override void OnGotFocus(EventArgs e)
        {
            if (!this.ReadOnly || !this.Enabled)
                this.Text = this.Text.Replace(",", "");
            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            if (DavSoloNumero)
            {
                double.TryParse(this.Text, out double valor);
                if (valor > DavMaximo)
                    valor = DavMaximo;
                this.Text = valor.ToString(DavFormatoNumero);
            }
            base.OnLostFocus(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (DavSoloNumero)
            {
                if (DavIsFloat && e.KeyChar.ToString() == ".")
                {
                    if (this.Text.Contains("."))
                        e.Handled = true;
                }
                else
                {
                    //Para obligar a que sólo se introduzcan números 
                    if (Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                      if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        //el resto de teclas pulsadas se desactivan 
                        e.Handled = true;
                    }
                }

            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DavHabilitarTabulacionEnter)
                {
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                }
            }
            base.OnKeyDown(e);
        }
    }
}
