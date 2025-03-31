namespace PilaT
{
    partial class frmMain
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
            this.lblCompilador = new System.Windows.Forms.Label();
            this.txtCompilador = new System.Windows.Forms.TextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.lblPolaca = new System.Windows.Forms.Label();
            this.txtPolaca = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCompilador
            // 
            this.lblCompilador.AutoSize = true;
            this.lblCompilador.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompilador.Location = new System.Drawing.Point(45, 55);
            this.lblCompilador.Name = "lblCompilador";
            this.lblCompilador.Size = new System.Drawing.Size(357, 55);
            this.lblCompilador.TabIndex = 0;
            this.lblCompilador.Text = "COMPILADOR";
            // 
            // txtCompilador
            // 
            this.txtCompilador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompilador.Location = new System.Drawing.Point(55, 212);
            this.txtCompilador.Name = "txtCompilador";
            this.txtCompilador.Size = new System.Drawing.Size(565, 26);
            this.txtCompilador.TabIndex = 1;
            // 
            // btnCompilar
            // 
            this.btnCompilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnCompilar.Location = new System.Drawing.Point(881, 89);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(202, 99);
            this.btnCompilar.TabIndex = 2;
            this.btnCompilar.Text = "COMPILAR";
            this.btnCompilar.UseVisualStyleBackColor = true;
            // 
            // lblPolaca
            // 
            this.lblPolaca.AutoSize = true;
            this.lblPolaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPolaca.Location = new System.Drawing.Point(45, 370);
            this.lblPolaca.Name = "lblPolaca";
            this.lblPolaca.Size = new System.Drawing.Size(464, 55);
            this.lblPolaca.TabIndex = 3;
            this.lblPolaca.Text = "NOTACIÓ POLACA";
            // 
            // txtPolaca
            // 
            this.txtPolaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolaca.Location = new System.Drawing.Point(55, 557);
            this.txtPolaca.Name = "txtPolaca";
            this.txtPolaca.Size = new System.Drawing.Size(565, 26);
            this.txtPolaca.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(881, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 99);
            this.button1.TabIndex = 5;
            this.button1.Text = "NOTACIÓ POLACA";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPolaca);
            this.Controls.Add(this.lblPolaca);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.txtCompilador);
            this.Controls.Add(this.lblCompilador);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOTACIO POLACA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompilador;
        private System.Windows.Forms.TextBox txtCompilador;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Label lblPolaca;
        private System.Windows.Forms.TextBox txtPolaca;
        private System.Windows.Forms.Button button1;
    }
}

