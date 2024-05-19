namespace prySvetlizaEtapa7
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
            this.btnConexion = new System.Windows.Forms.Button();
            this.trvMonstruos = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnConexion
            // 
            this.btnConexion.Location = new System.Drawing.Point(644, 386);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(144, 52);
            this.btnConexion.TabIndex = 0;
            this.btnConexion.Text = "conexion";
            this.btnConexion.UseVisualStyleBackColor = true;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // trvMonstruos
            // 
            this.trvMonstruos.Location = new System.Drawing.Point(12, 12);
            this.trvMonstruos.Name = "trvMonstruos";
            this.trvMonstruos.Size = new System.Drawing.Size(412, 399);
            this.trvMonstruos.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trvMonstruos);
            this.Controls.Add(this.btnConexion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.TreeView trvMonstruos;
    }
}

