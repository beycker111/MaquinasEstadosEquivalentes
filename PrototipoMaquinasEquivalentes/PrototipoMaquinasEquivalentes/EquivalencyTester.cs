using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    class EquivalencyTester
    {
        public static string _ESP = "_";

        private List<State> listaDeEstados = new List<State>();

        public string tipo { get; set; }
        public int cantidadEstadosM1 = 0;
        public int cantidadEstadosM2 = 0;
        public int cantidadColumnasMaquinas = 0;

        public string[,] matrizM1 { get; set; }
        public string[,] matrizM2 { get; set; }
        public string[,] matrizSumaDirecta { get; set; }

        public void agregarEstado(State nuevoEstado)
        {
            listaDeEstados.Add(nuevoEstado);
        }
        public void crearRelaciones()
        {
            if(tipo.Equals("Mealy"))
            {
                crearRelacionesMealyM1();
                crearRelacionesMealy2();
            }
            else if(tipo.Equals("Moore"))
            {
                crearRelacionesMooreM1();
                crearRelacionesMooreM2();
            }
        }
        public void particionar()
        {
            if (tipo.Equals("Mealy"))
            {
                particionamientoMealy();
            }
            else if (tipo.Equals("Moore"))
            {
                particionamientoMoore();
            }
        }
        private void crearRelacionesMooreM1()
        {
            //Empieza a crearse las relaciones
           
                for (int a = 0; a < cantidadEstadosM1; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas - 1; b++)
                    {
                        State padre = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM1[a, 0] == elemento.name) padre = elemento;
                        }
                        State hijo = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM1[a, b] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<State> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
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
        private void crearRelacionesMooreM2()
        {
            //Empieza a crearse las relaciones
            
                for (int a = 0; a < cantidadEstadosM2; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas - 1; b++)
                    {
                        State padre = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM2[a, 0] == elemento.name) padre = elemento;
                        }
                        State hijo = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM2[a, b] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<State> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
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
        private void crearRelacionesMealyM1()
        {
           
                for (int a = 0; a < cantidadEstadosM1; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas; b++) //sE QUITO UN MENOS 1
                    {
                        State padre = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM1[a, 0] == elemento.name) padre = elemento;
                        }
                        State hijo = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            string[] nodoAdy = matrizM1[a, b].Split(',');
                            if (nodoAdy[0] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

            BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
            List<State> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
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
        private void crearRelacionesMealy2()
        {
            //Empieza a crearse las relaciones
            
                for (int a = 0; a < cantidadEstadosM2; a++)
                {
                    for (int b = 1; b < cantidadColumnasMaquinas; b++)
                    {
                        State padre = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            if (matrizM2[a, 0] == elemento.name) padre = elemento;
                        }
                        State hijo = null;
                        foreach (State elemento in listaDeEstados)
                        {
                            string[] nodoAdy = matrizM2[a, b].Split(',');
                            if (nodoAdy[0] == elemento.name) hijo = elemento;
                        }
                        padre.setEstadoAdyacente(hijo);
                    }
                }

                BreadthFirstAlgorithm consultarAlcanzables = new BreadthFirstAlgorithm();
                List<State> listaAlcanzables = consultarAlcanzables.Traverse(listaDeEstados.ElementAt(0));
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
        private void sumaDirecta()
        {
            matrizSumaDirecta = new string[cantidadEstadosM1 + cantidadEstadosM2, cantidadColumnasMaquinas];
            for (int i = 0; i < cantidadEstadosM1; i++)
            {
                for (int j = 0; j < cantidadColumnasMaquinas; j++)
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

            //Console.WriteLine("fin");
            //Prueba para ver si estoy conectado
            particionamientoMoore();
        }
        public void particionamientoMoore()
        {

            //INICIO PARTICION 1

            string[,] matrizAux = matrizSumaDirecta;
            List<List<string>> lista = new List<List<string>>(); // Aquí serán guardadas las particiones
            for (int i = 0; i < (cantidadEstadosM1 + cantidadEstadosM2); i++)
            {
                if (matrizAux[i, cantidadColumnasMaquinas - 1] != "")
                {
                    string salida = matrizAux[i, cantidadColumnasMaquinas - 1];
                    matrizAux[i, cantidadColumnasMaquinas - 1] = "";
                    List<string> listaN = new List<string>();
                    listaN.Add(matrizAux[i, 0]);

                    for (int j = i; j < (cantidadEstadosM1 + cantidadEstadosM2); j++)
                    {
                        if (matrizAux[j, cantidadColumnasMaquinas - 1] != "")
                        {
                            if (salida == matrizAux[j, cantidadColumnasMaquinas - 1])
                            {
                                matrizAux[j, cantidadColumnasMaquinas - 1] = "";
                                listaN.Add(matrizAux[j, 0]);
                            }
                        }
                    }
                    lista.Add(listaN);

                }
            }

            Console.WriteLine("Particion 1 OK");

            //FIN PARTICION 1

            //COMIENZAN LAS DEMAS PARTICIONES
            //Se acabara cuando la longitud de lista no haya cambiado

            //notas
            //En algun punto estrategico debo crear una nueva lista que almacene las nuevas particiones que se generan
            Boolean cierre = false;
            while (!cierre)
            {
                List<List<string>> auxP1 = lista; //En esta lista se agregaran todos los cambios de la nueva particion
                int conjuntos = auxP1.Count;

                for (int i = 0; i < conjuntos; i++)
                {
                    List<string> listaM = lista.ElementAt(i);

                    int posicionCero = 0;
                    string estadoA = listaM.ElementAt(posicionCero); //Este sera A
                    List<string> listaNuevaM = new List<string>(); //Esta será la lista donde vayan los valores que ya no esten en la particon
                                                                   //Este parece ser un buen lugar para agregar la lista de string
                    for (int k = posicionCero + 1; k < listaM.Count; k++)
                    {
                        string estadoB = listaM.ElementAt(k);
                        //Ya que tenemos los dos estados a comparar, los buscamos en la matriz
                        int filaA = -1;
                        int filaB = -1;
                        //Vamos a buscar la fila de A
                        for (int l = 0; l < (cantidadEstadosM1 + cantidadEstadosM2); l++)
                        {
                            if (estadoA == matrizSumaDirecta[l, 0])
                            {
                                filaA = l;
                            }
                            else if (estadoB == matrizSumaDirecta[l, 0])
                            {
                                filaB = l;
                            }
                            //Cuando ya encontramos las posiciones en las filas de los estados entonces cortamos.
                            if (filaA != -1 && filaB != -1)
                            {
                                break;
                            }
                        }

                        //Ahora tenemos que ver si todos los estimulos de esas dos filas corresponden a un grupo de la lista
                        //Boolean coso = lista.ElementAt(0).Contains("T");
                        Boolean seParticiono = false;
                        for (int h = 1; h < (cantidadColumnasMaquinas - 1) && !seParticiono; h++)
                        {
                            //Obtenemos aqui cada uno de los estados a comparar de acuerdo al estimulo en que esten
                            string estadoEstimuloA = matrizSumaDirecta[filaA, h];
                            string estadoEstimuloB = matrizSumaDirecta[filaB, h];
                            //Ahora miramos si estan en la misma particion

                            for (int c = 0; c < lista.Count; c++)
                            {
                                if (lista.ElementAt(c).Contains(estadoEstimuloA))
                                {
                                    if (lista.ElementAt(c).Contains(estadoEstimuloB))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        //Aquí es donde va si no pertenecen a la misma particion
                                        //Deberia romper dos for hacia arriba
                                        seParticiono = true;
                                        listaNuevaM.Add(estadoB);
                                        break;
                                    }
                                }
                            }
                        }


                    }

                    //Agregamos listaNueva a auxP1
                    if (listaNuevaM.Count != 0)
                    {
                        auxP1.Add(listaNuevaM);
                        //Aqui es donde se deberian eliminar
                        for (int g = 0; g < auxP1.ElementAt(i).Count; g++)
                        {
                            if (auxP1.ElementAt(auxP1.Count - 1).Contains(auxP1.ElementAt(i).ElementAt(g)))
                            {
                                auxP1.ElementAt(i).RemoveAt(g);
                                g--;
                            }
                        }
                    }

                    Console.WriteLine("Casi listo");

                }

                //Aqui miramos si no se han hecho nuevas particiones, si se han hecho, debe continuar, sino se acaba el programa
                if (auxP1.Count == conjuntos)
                {
                    cierre = true;
                }
                else
                {
                    lista = auxP1;
                }
            }

            comprobarMaquinaDeMoore(lista);


        }
        public void comprobarMaquinaDeMoore(List<List<string>> listaFinal)
        {
            Boolean resultado = true;
            for (int i = 0; i < listaFinal.Count; i++)
            {
                if (listaFinal.ElementAt(i).Count < 2)
                {
                    resultado = false;
                    break;
                }
            }
            resultado = resultado && (listaFinal.ElementAt(0).Contains(matrizM1[0, 0]) && listaFinal.ElementAt(0).Contains(matrizM2[0, 0]));

            if (resultado)
            {
                for (int i = 0; i < listaFinal.Count && resultado; i++)
                {
                    Boolean encontroM1 = false;
                    for (int j = 0; j < cantidadEstadosM1 && resultado; j++)
                    {
                        if (listaFinal.ElementAt(i).Contains(matrizM1[j, 0]))
                        {
                            //encontroM1 = true;
                            Boolean encontroM2 = false;
                            for (int k = 0; k < cantidadEstadosM2; k++)
                            {
                                if (listaFinal.ElementAt(i).Contains(matrizM2[k, 0]))
                                {
                                    encontroM1 = true;
                                    encontroM2 = true;
                                    break;
                                }
                            }
                            if (!encontroM2)
                            {
                                resultado = false;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (!encontroM1)
                    {
                        resultado = false;
                    }
                }
            }

            Console.WriteLine(resultado);
        }
    }

}
