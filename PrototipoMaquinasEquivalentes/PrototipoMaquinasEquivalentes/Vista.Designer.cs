namespace PrototipoMaquinasEquivalentes
{
    partial class Vista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrearTablasEstados = new System.Windows.Forms.Button();
            this.Columnas = new System.Windows.Forms.TextBox();
            this.lblEstímulos = new System.Windows.Forms.Label();
            this.lblEspecificarTransiciones = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRealizarAnalisis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTipoMaquinas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCrearTablasEstados
            // 
            this.btnCrearTablasEstados.Location = new System.Drawing.Point(46, 111);
            this.btnCrearTablasEstados.Name = "btnCrearTablasEstados";
            this.btnCrearTablasEstados.Size = new System.Drawing.Size(269, 35);
            this.btnCrearTablasEstados.TabIndex = 2;
            this.btnCrearTablasEstados.Text = "3. Crear Tablas de Estado";
            this.btnCrearTablasEstados.UseVisualStyleBackColor = true;
            this.btnCrearTablasEstados.Click += new System.EventHandler(this.agregarColumna_Click);
            // 
            // Columnas
            // 
            this.Columnas.Location = new System.Drawing.Point(215, 69);
            this.Columnas.Name = "Columnas";
            this.Columnas.Size = new System.Drawing.Size(100, 22);
            this.Columnas.TabIndex = 3;
            this.Columnas.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblEstímulos
            // 
            this.lblEstímulos.AutoSize = true;
            this.lblEstímulos.Location = new System.Drawing.Point(43, 72);
            this.lblEstímulos.Name = "lblEstímulos";
            this.lblEstímulos.Size = new System.Drawing.Size(157, 17);
            this.lblEstímulos.TabIndex = 4;
            this.lblEstímulos.Text = "2. Especificar Estímulos";
            this.lblEstímulos.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblEspecificarTransiciones
            // 
            this.lblEspecificarTransiciones.AutoSize = true;
            this.lblEspecificarTransiciones.Location = new System.Drawing.Point(43, 161);
            this.lblEspecificarTransiciones.Name = "lblEspecificarTransiciones";
            this.lblEspecificarTransiciones.Size = new System.Drawing.Size(331, 17);
            this.lblEspecificarTransiciones.TabIndex = 5;
            this.lblEspecificarTransiciones.Text = "4. Especificar transiciones en las tablas de estados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 6;
            // 
            // btnRealizarAnalisis
            // 
            this.btnRealizarAnalisis.Location = new System.Drawing.Point(46, 446);
            this.btnRealizarAnalisis.Name = "btnRealizarAnalisis";
            this.btnRealizarAnalisis.Size = new System.Drawing.Size(269, 35);
            this.btnRealizarAnalisis.TabIndex = 7;
            this.btnRealizarAnalisis.Text = "5. Realizar análisis de equivalencia";
            this.btnRealizarAnalisis.UseVisualStyleBackColor = true;
            this.btnRealizarAnalisis.Click += new System.EventHandler(this.btnRealizarAnalisis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "1. Especificar tipo";
            // 
            // cbxTipoMaquinas
            // 
            this.cbxTipoMaquinas.FormattingEnabled = true;
            this.cbxTipoMaquinas.Items.AddRange(new object[] {
            "Mealy",
            "Moore"});
            this.cbxTipoMaquinas.Location = new System.Drawing.Point(215, 30);
            this.cbxTipoMaquinas.Name = "cbxTipoMaquinas";
            this.cbxTipoMaquinas.Size = new System.Drawing.Size(100, 24);
            this.cbxTipoMaquinas.TabIndex = 9;
            // 
            // Vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 514);
            this.Controls.Add(this.cbxTipoMaquinas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRealizarAnalisis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEspecificarTransiciones);
            this.Controls.Add(this.lblEstímulos);
            this.Controls.Add(this.Columnas);
            this.Controls.Add(this.btnCrearTablasEstados);
            this.Name = "Vista";
            this.Text = "Vista";
            this.Load += new System.EventHandler(this.Vista_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCrearTablasEstados;
        private System.Windows.Forms.TextBox Columnas;
        private System.Windows.Forms.Label lblEstímulos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblEspecificarTransiciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRealizarAnalisis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipoMaquinas;
    }
}