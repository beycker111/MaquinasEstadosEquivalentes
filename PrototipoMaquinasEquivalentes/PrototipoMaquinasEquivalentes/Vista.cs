using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoMaquinasEquivalentes
{
    public partial class Vista : Form
    {
        private EquivalencyTester model;

        public Vista()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void agregarFila_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;

        }

        private void agregarColumna_Click(object sender, EventArgs e)
        {
            if (this.cbxTipoMaquinas.Text.Equals("Mealy"))
            {
                initializeMealyStateTables();
            }
            else if (this.cbxTipoMaquinas.Text.Equals("Moore"))
            {
                initializeMooreStateTables();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void initializeMealyStateTables()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new DataGridView();

            string[] columnas1 = this.Columnas.Text.Split(' ');
            string[] columnas2 = this.Columnas.Text.Split(' ');

            DataGridViewTextBoxColumn[] columnasgrid1 = new DataGridViewTextBoxColumn[columnas1.Length + 1];
            DataGridViewTextBoxColumn[] columnasgrid2 = new DataGridViewTextBoxColumn[columnas2.Length + 1];

            columnasgrid1[0] = new DataGridViewTextBoxColumn();
            columnasgrid1[0].HeaderText = "State Name";
            columnasgrid1[0].Name = "State Name";

            for (int i = 1; i < columnasgrid1.Length; i++)
            {
                columnasgrid1[i] = new DataGridViewTextBoxColumn();
                columnasgrid1[i].HeaderText = columnas1[i-1];
                columnasgrid1[i].Name = columnas1[i-1];

            }

            columnasgrid2[0] = new DataGridViewTextBoxColumn();
            columnasgrid2[0].HeaderText = "State Name";
            columnasgrid2[0].Name = "State Name";

            for (int i = 1; i < columnasgrid2.Length; i++)
            {
                columnasgrid2[i] = new DataGridViewTextBoxColumn();
                columnasgrid2[i].HeaderText = columnas2[i-1];
                columnasgrid2[i].Name = columnas2[i-1];

            }
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            this.dataGridView1.Columns.AddRange(columnasgrid1);
            this.dataGridView1.Location = new System.Drawing.Point(20,150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.AllowUserToAddRows = true;
            this.dataGridView1.AllowUserToDeleteRows = true;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.Controls.Add(this.dataGridView1);
            this.dataGridView1.AutoResizeColumns();


            // 
            // dataGridView2
            // 

            this.dataGridView2.Columns.AddRange(columnasgrid2);
            this.dataGridView2.Location = new System.Drawing.Point(410, 150);
            this.dataGridView2.Name = "dataGridView1";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView2.AllowUserToAddRows = true;
            this.dataGridView2.AllowUserToDeleteRows = true;
            this.dataGridView2.AllowUserToOrderColumns = false;
            this.Controls.Add(this.dataGridView2);
            this.dataGridView2.AutoResizeColumns();

        }

        private void initializeMooreStateTables()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new DataGridView();

            string[] columnas1 = this.Columnas.Text.Split(' ');
            string[] columnas2 = this.Columnas.Text.Split(' ');

            DataGridViewTextBoxColumn[] columnasgrid1 = new DataGridViewTextBoxColumn[columnas1.Length + 2];
            DataGridViewTextBoxColumn[] columnasgrid2 = new DataGridViewTextBoxColumn[columnas2.Length + 2];

            columnasgrid1[0] = new DataGridViewTextBoxColumn();
            columnasgrid1[0].HeaderText = "State Name";
            columnasgrid1[0].Name = "State Name";

            for (int i = 1; i < columnasgrid1.Length-1; i++)
            {
                columnasgrid1[i] = new DataGridViewTextBoxColumn();
                columnasgrid1[i].HeaderText = columnas1[i - 1];
                columnasgrid1[i].Name = columnas1[i - 1];

            }

            columnasgrid1[columnasgrid1.Length-1] = new DataGridViewTextBoxColumn();
            columnasgrid1[columnasgrid1.Length - 1].HeaderText = "Output";
            columnasgrid1[columnasgrid1.Length - 1].Name = "Output";

            columnasgrid2[0] = new DataGridViewTextBoxColumn();
            columnasgrid2[0].HeaderText = "State Name";
            columnasgrid2[0].Name = "State Name";

            for (int i = 1; i < columnasgrid2.Length-1; i++)
            {
                columnasgrid2[i] = new DataGridViewTextBoxColumn();
                columnasgrid2[i].HeaderText = columnas2[i - 1];
                columnasgrid2[i].Name = columnas2[i - 1];

            }

            columnasgrid2[columnasgrid2.Length - 1] = new DataGridViewTextBoxColumn();
            columnasgrid2[columnasgrid2.Length - 1].HeaderText = "Output";
            columnasgrid2[columnasgrid2.Length - 1].Name = "Output";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Columns.AddRange(columnasgrid1);
            this.dataGridView1.Location = new System.Drawing.Point(20, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.AllowUserToAddRows = true;
            this.dataGridView1.AllowUserToDeleteRows = true;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.Controls.Add(this.dataGridView1);
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.AutoResizeRows();



            // 
            // dataGridView2
            // 

            this.dataGridView2.Columns.AddRange(columnasgrid2);
            this.dataGridView2.Location = new System.Drawing.Point(410, 170);
            this.dataGridView2.Name = "dataGridView1";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView2.AllowUserToAddRows = true;
            this.dataGridView2.AllowUserToDeleteRows = true;
            this.dataGridView2.AllowUserToOrderColumns = false;
            this.Controls.Add(this.dataGridView2);
            this.dataGridView2.AutoResizeColumns();
            this.dataGridView2.AutoResizeRows();

        }
        private void Vista_Load(object sender, EventArgs e)
        {

        }

        private void btnRealizarAnalisis_Click(object sender, EventArgs e)
        {
            model = new EquivalencyTester();
            generateMachines();
            model.crearRelaciones();
            model.particionar();
            int i = 0;
        }

        private void generateMachines()
        {
            model.tipo = cbxTipoMaquinas.Text;
            model.cantidadColumnasMaquinas = dataGridView1.ColumnCount;
            model.cantidadEstadosM1 = dataGridView1.RowCount;
            model.cantidadEstadosM2 = dataGridView2.RowCount;

            String[,] M1 = new string[dataGridView1.RowCount, dataGridView1.ColumnCount];
            DataGridViewRowCollection rows1 = dataGridView1.Rows;
            for (int i = 0; i < rows1.Count; i++)
            {
                model.agregarEstado(new State(rows1[i].Cells[0].Value + ""));
                for (int j = 0; j < rows1[i].Cells.Count; j++)
                {
                    M1[i, j] = rows1[i].Cells[j].Value + "";
                }
            }
            model.matrizM1 = M1;

            String[,] M2 = new string[dataGridView2.RowCount, dataGridView2.ColumnCount];
            DataGridViewRowCollection rows2 = dataGridView1.Rows;
            for (int i = 0; i < rows2.Count; i++)
            {
                model.agregarEstado(new State(rows1[i].Cells[0].Value + ""));
                for (int j = 0; j < rows2[i].Cells.Count; j++)
                {
                    M2[i, j] = rows2[i].Cells[j].Value + "";
                }
            }
            model.matrizM2 = M2;
            
        }
    }
    
}
