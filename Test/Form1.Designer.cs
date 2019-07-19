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
            this.davButton2 = new Test.DavButton();
            this.SuspendLayout();
            // 
            // davButton1
            // 
            this.davButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.davButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.davButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.davButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.davButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.davButton1.ForeColor = System.Drawing.Color.White;
            this.davButton1.Location = new System.Drawing.Point(260, 132);
            this.davButton1.Name = "davButton1";
            this.davButton1.Size = new System.Drawing.Size(105, 43);
            this.davButton1.TabIndex = 1;
            this.davButton1.Text = "davButton1";
            this.davButton1.UseVisualStyleBackColor = false;
            // 
            // davButton2
            // 
            this.davButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.davButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.davButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.davButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.davButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.davButton2.ForeColor = System.Drawing.Color.White;
            this.davButton2.Location = new System.Drawing.Point(371, 132);
            this.davButton2.Name = "davButton2";
            this.davButton2.Size = new System.Drawing.Size(105, 43);
            this.davButton2.TabIndex = 2;
            this.davButton2.Text = "davButton2";
            this.davButton2.UseVisualStyleBackColor = false;
            this.davButton2.Click += new System.EventHandler(this.DavButton2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.davButton2);
            this.Controls.Add(this.davButton1);
            this.Name = "Form1";
            this.Opacity = 1D;
            this.Text = "Hola";
            this.ZMaximizar = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.davButton1, 0);
            this.Controls.SetChildIndex(this.davButton2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DavButton davButton1;
        private DavButton davButton2;
    }
}

