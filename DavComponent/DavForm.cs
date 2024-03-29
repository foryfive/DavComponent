﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace DavComponent
{

    public partial class DavForm : Form
    {
        private bool Maximizado { get; set; }
        private int Ancho { get; set; }
        private int Alto { get; set; }
        public bool PrimeraVez { get; set; } = true;
        public bool ZMaximizar { get; set; } = false;

        private double opa = 0;
        System.Timers.Timer timer = new System.Timers.Timer();

        public DavForm()
        {
            InitializeComponent();
        }
        private void DavForm_Load(object sender, EventArgs e)
        {
            if (ZMaximizar)
            {
                toolTip1.SetToolTip(panelHeader, "Doble click para maximizar, minimizar.");
            }
            LblTitulo.Text = this.Text;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 100;
            timer.Start();
            Ancho = this.Width;
            Alto = this.Height;
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Location = new Point(0, 0);
                ZMaximizar = true;
                var rectangle = ScreenRectangle();
                Size = new Size(rectangle.Width - 1, rectangle.Height - 25);
                Location = new Point(0, 0);
                Maximizado = true;
            }
        }
        public Rectangle ScreenRectangle()
        {
            return Screen.FromControl(this).Bounds;
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            opa += 1;
            this.Invoke(new MethodInvoker(() => { Opacity = opa; }));
            if (opa >= 1)
                timer.Stop();
        }



        protected override void OnActivated(EventArgs e)
        {
            //if (PrimeraVez)
            //{
            //    double opa = 0;
            //    Task.Factory.StartNew(() =>
            //    {

            //        while (true)
            //        {
            //            opa += 0.1;
            //            this.Invoke(new MethodInvoker(() => { Opacity = opa; }));
            //            if (opa >= 1)
            //                break;
            //        }


            //    });
            //    PrimeraVez = false;
            //}



            base.OnActivated(e);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {

                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;

            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            //if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }

        private int xClick = 0, yClick = 0;


        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCerrar_MouseEnter(object sender, EventArgs e)
        {
            BtnCerrar.BackColor = Color.Red;
        }

        private void BtnCerrar_MouseLeave(object sender, EventArgs e)
        {
            BtnCerrar.BackColor = Color.Transparent;
        }

        private void PanelHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ZMaximizar)
            {
                if (this.Width == Ancho)
                {
                    var rectangle = ScreenRectangle();
                    Size = new Size(rectangle.Width - 1, rectangle.Height - 25);
                    Location = new Point(0, 0);
                    Maximizado = true;
                }
                else
                {
                    var rectangle = ScreenRectangle();
                    Size = new Size(Ancho, Alto);
                    Location = new Point(Ancho / 2, Alto / 2);
                    Maximizado = false;
                }
            }
        }



        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Maximizado)
            {
                if (e.Button != MouseButtons.Left)
                {
                    xClick = e.X; yClick = e.Y;
                }
                else
                {
                    this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);

                }
            }
        }
    }
}
