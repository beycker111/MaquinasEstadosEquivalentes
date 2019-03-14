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
    public partial class Form1 : Form
    {

        private List<Estado> listaDeEstados = new List<Estado>();

        private string tipo = ""; 
        private int cantidadEstadosM1 = 0;
        private int cantidadEstadosM2 = 0;
        private int cantidadColumnasMaquinas = 0;

        private string[,] matrizM1;
        private string[,] matrizM2;
        private string[,] matrizSumaDirecta;

        private int filasAgregadasHastaAhora = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            if(cbxTipo.Text == "mealing")
            {
                tipo = "mealing";
                cantidadEstadosM1 = Convert.ToInt32(txtCantidadEstadosM1.Text);
                string[] listaEstimulos = txtEstimulos.Text.Split(' ');
                cantidadColumnasMaquinas = listaEstimulos.Length + 1;
                matrizM1 = new string[cantidadEstadosM1, cantidadColumnasMaquinas];

            }
            else
            {
                tipo = "moore";
                cantidadEstadosM1 = Convert.ToInt32(txtCantidadEstadosM1.Text);
                string[] listaEstimulos = txtEstimulos.Text.Split(' ');
                cantidadColumnasMaquinas = listaEstimulos.Length + 2;
                matrizM1 = new string[cantidadEstadosM1, cantidadColumnasMaquinas];
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {

            if(tipo == "mealing")
            {
                mealingM1();
            }
            else
            {
                mooreM1();
            }

        }

        public void mealingM1()
        {
            //Aqui empezamos a construir la matriz y el grafo
            string[] filaN = txtFilasM1.Text.Split(' ');

            Estado nuevoEstado = new Estado(filaN[0]);
            listaDeEstados.Add(nuevoEstado);
            for (int i = 0; i < cantidadColumnasMaquinas; i++)
            {
                matrizM1[filasAgregadasHastaAhora, i] = filaN[i];
            }
            filasAgregadasHastaAhora++;

            //Empieza a crearse las relaciones
            if (filasAgregadasHastaAhora == cantidadEstadosM1)
            {
                for (int a = 0; a < cantidadEstadosM1; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas; b++) //sE QUITO UN MENOS 1
                    {
                        Estado padre = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM1[a, 0] == elemento.name) padre = elemento;
                        }
                        Estado hijo = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            string[] nodoAdy = matrizM1[a, b].Split(',');
                            if (nodoAdy[0] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<Estado> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
                //Hasta este punto encontramos los estados alcanzables y los tenemos en una lista
                int estadosEliminados = 0;

                for (int i = 1; i < cantidadEstadosM1; i++)
                {
                    Boolean seEncontro = false;
                    for (int j = 0; j < listaAlcanzables.Count && !seEncontro; j++)
                    {
                        if (listaAlcanzables.ElementAt(j).name == matrizM1[i, 0])
                        {
                            seEncontro = true;
                        }
                    }
                    if (!seEncontro)
                    {
                        //Si no se encuentra el estado, se coloca vacio para posteriormente crear una nueva matriz sin ese estado
                        estadosEliminados++;
                        matrizM1[i, 0] = "";
                    }
                }

                //Vamos a asignar a la variable cantidadEstados el nuevo valor con las filas eliminadas
                cantidadEstadosM1 = cantidadEstadosM1 - estadosEliminados;
                //Creamos la nueva matriz con estados eliminados
                string[,] nuevaMatrizM1 = new string[cantidadEstadosM1, cantidadColumnasMaquinas];
                //Llenamos la nueva matriz
                for (int i = 0, l = 0; i < cantidadEstadosM1; i++, l++)
                {
                    for (int j = 0; j < cantidadColumnasMaquinas; j++)
                    {
                        while (matrizM1[l, 0] == "")
                        {
                            l++;
                        }
                        //listaDeEstados no se modifica debido a que creo que no se utilizara en suma directa.
                        nuevaMatrizM1[i, j] = matrizM1[l, j];
                    }
                }

                matrizM1 = nuevaMatrizM1;

            }
        }

        public void mealingM2()
        {
            //Aqui empezamos a construir la matriz y el grafo

            string[] filaN = txtFilasM2.Text.Split(' ');

            Estado nuevoEstado = new Estado(filaN[0]);
            listaDeEstados.Add(nuevoEstado);
            for (int i = 0; i < cantidadColumnasMaquinas; i++)
            {
                matrizM2[filasAgregadasHastaAhora, i] = filaN[i];
            }
            filasAgregadasHastaAhora++;

            //Empieza a crearse las relaciones
            if (filasAgregadasHastaAhora == cantidadEstadosM2)
            {
                for (int a = 0; a < cantidadEstadosM2; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas; b++)
                    {
                        Estado padre = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM2[a, 0] == elemento.name) padre = elemento;
                        }
                        Estado hijo = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            string[] nodoAdy = matrizM2[a, b].Split(',');
                            if (nodoAdy[0] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<Estado> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
                //Hasta este punto encontramos los estados alcanzables y los tenemos en una lista
                int estadosEliminados = 0;

                for (int i = 1; i < cantidadEstadosM2; i++)
                {
                    Boolean seEncontro = false;
                    for (int j = 0; j < listaAlcanzables.Count && !seEncontro; j++)
                    {
                        if (listaAlcanzables.ElementAt(j).name == matrizM2[i, 0])
                        {
                            seEncontro = true;
                        }
                    }
                    if (!seEncontro)
                    {
                        //Si no se encuentra el estado, se coloca vacio para posteriormente crear una nueva matriz sin ese estado
                        estadosEliminados++;
                        matrizM2[i, 0] = "";
                    }
                }
                //Vamos a asignar a la variable cantidadEstados el nuevo valor con las filas eliminadas
                cantidadEstadosM2 = cantidadEstadosM2 - estadosEliminados;
                //Creamos la nueva matriz con estados eliminados
                string[,] nuevaMatrizM2 = new string[cantidadEstadosM2, cantidadColumnasMaquinas];
                //Llenamos la nueva matriz
                for (int i = 0, l = 0; i < cantidadEstadosM2; i++, l++)
                {
                    for (int j = 0; j < cantidadColumnasMaquinas; j++)
                    {
                        while (matrizM2[l, 0] == "")
                        {
                            l++;
                        }
                        //listaDeEstados no se modifica debido a que creo que no se utilizara en suma directa.
                        nuevaMatrizM2[i, j] = matrizM2[l, j];
                    }
                }

                matrizM2 = nuevaMatrizM2;

                //Ahora haremos la sumaDirecta;
                sumaDirecta();

            }
        }

        public void mooreM1()
        {
            //Aqui empezamos a construir la matriz y el grafo
            string[] filaN = txtFilasM1.Text.Split(' ');

            Estado nuevoEstado = new Estado(filaN[0]);
            listaDeEstados.Add(nuevoEstado);
            for (int i = 0; i < cantidadColumnasMaquinas; i++)
            {
                matrizM1[filasAgregadasHastaAhora, i] = filaN[i];
            }
            filasAgregadasHastaAhora++;

            //Empieza a crearse las relaciones
            if (filasAgregadasHastaAhora == cantidadEstadosM1)
            {
                for (int a = 0; a < cantidadEstadosM1; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas - 1; b++)
                    {
                        Estado padre = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM1[a, 0] == elemento.name) padre = elemento;
                        }
                        Estado hijo = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM1[a, b] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<Estado> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
                //Hasta este punto encontramos los estados alcanzables y los tenemos en una lista
                int estadosEliminados = 0;

                for (int i = 1; i < cantidadEstadosM1; i++)
                {
                    Boolean seEncontro = false;
                    for (int j = 0; j < listaAlcanzables.Count && !seEncontro; j++)
                    {
                        if (listaAlcanzables.ElementAt(j).name == matrizM1[i, 0])
                        {
                            seEncontro = true;
                        }
                    }
                    if (!seEncontro)
                    {
                        //Si no se encuentra el estado, se coloca vacio para posteriormente crear una nueva matriz sin ese estado
                        estadosEliminados++;
                        matrizM1[i, 0] = "";
                    }
                }
                //Vamos a asignar a la variable cantidadEstados el nuevo valor con las filas eliminadas
                cantidadEstadosM1 = cantidadEstadosM1 - estadosEliminados;
                //Creamos la nueva matriz con estados eliminados
                string[,] nuevaMatrizM1 = new string[cantidadEstadosM1, cantidadColumnasMaquinas];
                //Llenamos la nueva matriz
                for (int i = 0, l = 0; i < cantidadEstadosM1; i++, l++)
                {
                    for (int j = 0; j < cantidadColumnasMaquinas; j++)
                    {
                        while (matrizM1[l, 0] == "")
                        {
                            l++;
                        }
                        //listaDeEstados no se modifica debido a que creo que no se utilizara en suma directa.
                        nuevaMatrizM1[i, j] = matrizM1[l, j];
                    }
                }

                matrizM1 = nuevaMatrizM1;

            }
        }

        public void mooreM2()
        {
            //Aqui empezamos a construir la matriz y el grafo

            string[] filaN = txtFilasM2.Text.Split(' ');

            Estado nuevoEstado = new Estado(filaN[0]);
            listaDeEstados.Add(nuevoEstado);
            for (int i = 0; i < cantidadColumnasMaquinas; i++)
            {
                matrizM2[filasAgregadasHastaAhora, i] = filaN[i];
            }
            filasAgregadasHastaAhora++;

            //Empieza a crearse las relaciones
            if (filasAgregadasHastaAhora == cantidadEstadosM2)
            {
                for (int a = 0; a < cantidadEstadosM2; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas - 1; b++)
                    {
                        Estado padre = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM2[a, 0] == elemento.name) padre = elemento;
                        }
                        Estado hijo = null;
                        foreach (Estado elemento in listaDeEstados)
                        {
                            if (matrizM2[a, b] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<Estado> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
                //Hasta este punto encontramos los estados alcanzables y los tenemos en una lista
                int estadosEliminados = 0;

                for (int i = 1; i < cantidadEstadosM2; i++)
                {
                    Boolean seEncontro = false;
                    for (int j = 0; j < listaAlcanzables.Count && !seEncontro; j++)
                    {
                        if (listaAlcanzables.ElementAt(j).name == matrizM2[i, 0])
                        {
                            seEncontro = true;
                        }
                    }
                    if (!seEncontro)
                    {
                        //Si no se encuentra el estado, se coloca vacio para posteriormente crear una nueva matriz sin ese estado
                        estadosEliminados++;
                        matrizM2[i, 0] = "";
                    }
                }
                //Vamos a asignar a la variable cantidadEstados el nuevo valor con las filas eliminadas
                cantidadEstadosM2 = cantidadEstadosM2 - estadosEliminados;
                //Creamos la nueva matriz con estados eliminados
                string[,] nuevaMatrizM2 = new string[cantidadEstadosM2, cantidadColumnasMaquinas];
                //Llenamos la nueva matriz
                for (int i = 0, l = 0; i < cantidadEstadosM2; i++, l++)
                {
                    for (int j = 0; j < cantidadColumnasMaquinas; j++)
                    {
                        while (matrizM2[l, 0] == "")
                        {
                            l++;
                        }
                        //listaDeEstados no se modifica debido a que creo que no se utilizara en suma directa.
                        nuevaMatrizM2[i, j] = matrizM2[l, j];
                    }
                }

                matrizM2 = nuevaMatrizM2;

                //Ahora haremos la sumaDirecta;
                sumaDirecta();

            }
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            Estado D = new Estado("D");
            Estado E = new Estado("E");
            Estado F = new Estado("F");
            Estado G = new Estado("G");
            Estado H = new Estado("H");
            Estado I = new Estado("I");
            D.setEstadoAdyacente(E);
            D.setEstadoAdyacente(D);
            E.setEstadoAdyacente(D);
            E.setEstadoAdyacente(F);
            F.setEstadoAdyacente(F);
            F.setEstadoAdyacente(I);
            G.setEstadoAdyacente(E);
            G.setEstadoAdyacente(H);
            H.setEstadoAdyacente(D);
            H.setEstadoAdyacente(G);
            I.setEstadoAdyacente(E);
            I.setEstadoAdyacente(H);
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            cantidadEstadosM2 = Convert.ToInt32(txtCantidadEstadosM2.Text);
            matrizM2 = new string[cantidadEstadosM2, cantidadColumnasMaquinas];

            //Reiniciamos los atributos que se reciclaran de M1
            listaDeEstados = new List<Estado>();
            filasAgregadasHastaAhora = 0;
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            if (tipo == "mealing")
            {
                mealingM2();
            }
            else
            {
                mooreM2();
            }
        }

        public void sumaDirecta()
        {
            matrizSumaDirecta = new string[cantidadEstadosM1 + cantidadEstadosM2, cantidadColumnasMaquinas];
            for(int i = 0; i < cantidadEstadosM1; i++)
            {
                for(int j = 0; j < cantidadColumnasMaquinas; j++)
                {
                    matrizSumaDirecta[i, j] = matrizM1[i, j];
                }
            }
            for (int i = cantidadEstadosM1, a = 0; i < (cantidadEstadosM1 + cantidadEstadosM2); i++, a++)
            {
                for (int j = 0; j < cantidadColumnasMaquinas; j++)
                {
                    matrizSumaDirecta[i, j] = matrizM2[a, j];
                }
            }

            Console.WriteLine("fin");
        }
    }
}
