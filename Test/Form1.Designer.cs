namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.davButton1 = new Test.DavButton();
            this.SuspendLayout();
            // 
            // davButton1
            // 
            this.davButton1.Location = new System.Drawing.Point(41, 96);
            this.davButton1.Name = "davButton1";
            this.davButton1.Size = new System.Drawing.Size(150, 63);
            this.davButton1.TabIndex = 1;
            this.davButton1.Text = "davButton1";
            this.davButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.davButton1);
            this.Name = "Form1";
            this.Opacity = 1D;
            this.Text = "Hola";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.davButton1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DavButton davButton1;
    }
}

