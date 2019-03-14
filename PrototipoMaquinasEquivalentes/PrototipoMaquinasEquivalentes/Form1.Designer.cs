namespace PrototipoMaquinasEquivalentes
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadEstadosM1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstimulos = new System.Windows.Forms.TextBox();
            this.btnUno = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilasM1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilasM2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCuatro = new System.Windows.Forms.Button();
            this.btnTres = new System.Windows.Forms.Button();
            this.txtCantidadEstadosM2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrueba = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de maquina";
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "mealing",
            "moore"});
            this.cbxTipo.Location = new System.Drawing.Point(171, 31);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de estados";
            // 
            // txtCantidadEstadosM1
            // 
            this.txtCantidadEstadosM1.Location = new System.Drawing.Point(155, 187);
            this.txtCantidadEstadosM1.Name = "txtCantidadEstadosM1";
            this.txtCantidadEstadosM1.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadEstadosM1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese los estimulos en orden separados por espacio";
            // 
            // txtEstimulos
            // 
            this.txtEstimulos.Location = new System.Drawing.Point(191, 105);
            this.txtEstimulos.Name = "txtEstimulos";
            this.txtEstimulos.Size = new System.Drawing.Size(278, 20);
            this.txtEstimulos.TabIndex = 5;
            // 
            // btnUno
            // 
            this.btnUno.Location = new System.Drawing.Point(103, 231);
            this.btnUno.Name = "btnUno";
            this.btnUno.Size = new System.Drawing.Size(75, 23);
            this.btnUno.TabIndex = 6;
            this.btnUno.Text = "Aceptar";
            this.btnUno.UseVisualStyleBackColor = true;
            this.btnUno.Click += new System.EventHandler(this.btnUno_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(113, 339);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 7;
            this.btn2.Text = "Aceptar";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maquina1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Maquina2";
            // 
            // txtFilasM1
            // 
            this.txtFilasM1.Location = new System.Drawing.Point(14, 298);
            this.txtFilasM1.Name = "txtFilasM1";
            this.txtFilasM1.Size = new System.Drawing.Size(278, 20);
            this.txtFilasM1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ingrese una fila de la tabla, Aceptar e ingresar las demás";
            // 
            // txtFilasM2
            // 
            this.txtFilasM2.Location = new System.Drawing.Point(369, 298);
            this.txtFilasM2.Name = "txtFilasM2";
            this.txtFilasM2.Size = new System.Drawing.Size(278, 20);
            this.txtFilasM2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ingrese una fila de la tabla, Aceptar e ingresar las demás";
            // 
            // btnCuatro
            // 
            this.btnCuatro.Location = new System.Drawing.Point(468, 339);
            this.btnCuatro.Name = "btnCuatro";
            this.btnCuatro.Size = new System.Drawing.Size(75, 23);
            this.btnCuatro.TabIndex = 15;
            this.btnCuatro.Text = "Aceptar";
            this.btnCuatro.UseVisualStyleBackColor = true;
            this.btnCuatro.Click += new System.EventHandler(this.btnCuatro_Click);
            // 
            // btnTres
            // 
            this.btnTres.Location = new System.Drawing.Point(458, 231);
            this.btnTres.Name = "btnTres";
            this.btnTres.Size = new System.Drawing.Size(75, 23);
            this.btnTres.TabIndex = 14;
            this.btnTres.Text = "Aceptar";
            this.btnTres.UseVisualStyleBackColor = true;
            this.btnTres.Click += new System.EventHandler(this.btnTres_Click);
            // 
            // txtCantidadEstadosM2
            // 
            this.txtCantidadEstadosM2.Location = new System.Drawing.Point(510, 187);
            this.txtCantidadEstadosM2.Name = "txtCantidadEstadosM2";
            this.txtCantidadEstadosM2.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadEstadosM2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cantidad de estados";
            // 
            // btnPrueba
            // 
            this.btnPrueba.Location = new System.Drawing.Point(550, 23);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(75, 23);
            this.btnPrueba.TabIndex = 18;
            this.btnPrueba.Text = "Prueba";
            this.btnPrueba.UseVisualStyleBackColor = true;
            this.btnPrueba.Click += new System.EventHandler(this.btnPrueba_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 386);
            this.Controls.Add(this.btnPrueba);
            this.Controls.Add(this.txtFilasM2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCuatro);
            this.Controls.Add(this.btnTres);
            this.Controls.Add(this.txtCantidadEstadosM2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFilasM1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btnUno);
            this.Controls.Add(this.txtEstimulos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidadEstadosM1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadEstadosM1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstimulos;
        private System.Windows.Forms.Button btnUno;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilasM1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilasM2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCuatro;
        private System.Windows.Forms.Button btnTres;
        private System.Windows.Forms.TextBox txtCantidadEstadosM2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrueba;
    }
}

