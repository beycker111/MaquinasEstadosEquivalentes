using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    class EquivalencyTester
    {
        /// <summary>
        /// Representa los estados de una máquina, dependiendo del proceso puede ser reutilizada para crear las relaciones de
        /// diferentes máquinas.
        /// </summary>
        private List<State> listaDeEstados = new List<State>();
        /// <summary>
        /// Representa el tipo de máquinas que introdujeron al programa, los tipos pueden ser: Mealy, Moore.
        /// </summary>
        public string tipo { get; set; }
        /// <summary>
        /// Representa la cantidad de estados de la primera máquina.
        /// </summary>
        public int cantidadEstadosM1 = 0;
        /// <summary>
        /// Representa la cantidad de estados de la segunda máquina.
        /// </summary>
        public int cantidadEstadosM2 = 0;
        /// <summary>
        /// Representa la cantidad de columnas para la tabla que representa la máquina.
        /// Para máquinas mealy: número de estímulos + columna de nombres de estados
        /// Para máquinas moore: número de estímulos + columna de nombres de estados + columna de outputs
        /// </summary>
        public int cantidadColumnasMaquinas = 0;
        /// <summary>
        /// Representa la primera máquina de estados. Puede ser mealy o moore
        /// </summary>
        public string[,] matrizM1 { get; set; }
        /// <summary>
        /// Representa la segunda máquina de estados. Puede ser mealy o moore
        /// </summary>
        public string[,] matrizM2 { get; set; }
        /// <summary>
        /// Representa la matriz de suma directa de ambas máquinas de estado, necesaria para el algoritmo de particionamiento.
        /// </summary>
        public string[,] matrizSumaDirecta { get; set; }
        /// <summary>
        /// Permite agregar un nuevo estado a la lista de estados de la máquina.
        /// </summary>
        /// <param name="nuevoEstado">Nuevo estado a agregar</param>
        public void agregarEstado(State nuevoEstado)
        {
            listaDeEstados.Add(nuevoEstado);
        }
        /// <summary>
        /// Perimite reiniciar la lista de estados para que pueda ser usada para representar la lista de estados de otra máquina
        /// </summary>
        public void reiniciarListaEstados()
        {
            listaDeEstados = new List<State>();
        }
        /// <summary>
        /// Permite el llamado al método de particionamiento correcto de acuerdo con el tipo de máquinas que se esta manejando
        /// </summary>
        /// <returns>Retorna true si las máquinas son equivalentes, false en el caso contrario</returns>
        public bool particionar()
        {
            if (tipo.Equals("Mealy"))
            {
                return particionamientoMealy();
            }
            else
            {
                return particionamientoMoore();
            }
        }
        /// <summary>
        /// Permite representar las relaciones de la primera máquina de estados de moore en forma de árbol con el fin de realizar un recorrido BFS
        /// y así poder encontrar los estados inaccesibles, los cuales elimina para dejar las máquinas listas para el análisis
        /// de equivalencia.
        /// </summary>
        public void crearRelacionesMooreM1()
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
        /// <summary>
        /// Permite representar las relaciones de la segunda máquina de estados en forma de árbol con el fin de realizar un recorrido BFS
        /// y así poder encontrar los estados inaccesibles, los cuales elimina para dejar las máquinas listas para el análisis
        /// de equivalencia.
        /// </summary>
        public void crearRelacionesMooreM2()
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
            sumaDirectaMoore();
        }
        /// <summary>
        /// Permite representar las relaciones de la primera máquina de estados de mealy en forma de árbol con el fin de realizar un recorrido BFS
        /// y así poder encontrar los estados inaccesibles, los cuales elimina para dejar las máquinas listas para el análisis
        /// de equivalencia.
        /// </summary>
        public void crearRelacionesMealyM1()
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
        /// <summary>
        /// Permite representar las relaciones de la segunda máquina de estados de mealy en forma de árbol con el fin de realizar un recorrido BFS
        /// y así poder encontrar los estados inaccesibles, los cuales elimina para dejar las máquinas listas para el análisis
        /// de equivalencia.
        /// </summary>
        public void crearRelacionesMealyM2()
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
        }
        /// <summary>
        /// Permite generar la matriz de suma directa de las máquinas de estados de mealy, matriz necesaria para el
        /// análisis de equivalencia
        /// </summary>
        /// <returns>Retorna una lista de listas que representan las filas y columnas de la nueva máquina de estados</returns>
        private List<List<string>> sumaDirectaMealy()
        {
            List<List<string>> sumaDirecta = new List<List<string>>();
            for (int i = 0; i < cantidadEstadosM1; i++)
            {
                List<string> fila = new List<string>();
                for (int j = 0; j < cantidadColumnasMaquinas; j++)
                {
                    fila.Add(matrizM1[i, j]);
                }
                sumaDirecta.Add(fila);
            }
            for (int i = 0; i < cantidadEstadosM2; i++)
            {
                List<string> fila = new List<string>();
                for (int j = 0; j < cantidadColumnasMaquinas; j++)
                {
                    fila.Add(matrizM2[i, j]);
                }
                sumaDirecta.Add(fila);
            }
            return sumaDirecta;
        }
        /// <summary>
        /// Permite generar la matriz de suma directa de las máquinas de estados de moore, matriz necesaria para el
        /// análisis de equivalencia
        /// </summary>
        private void sumaDirectaMoore()
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
        }
        /// <summary>
        /// Permite realizar el algoritmo de particionamiento sobre máquinas de mealy con el fin de verificar si hay equivalencia 
        /// entre las máquinas.
        /// </summary>
        /// <returns>Retorna true si las máquinas resultan equivalentes, false en caso contrario</returns>
        public bool particionamientoMealy()
        {
            //INICIO PARTICIÓN 1
            List<List<string>> sumaDirecta = sumaDirectaMealy();
            List<List<string>> particiones = new List<List<string>>(); // Aquí serán guardadas las particiones
            for (int i = 0; i < sumaDirecta.Count; i++)
            {
                List<string> particion = new List<string>();
                List<string> filaTemp = sumaDirecta[i];
                particion.Add(filaTemp[0]);
                sumaDirecta.Remove(filaTemp);
                for (int j = 0; j < sumaDirecta.Count; j++)
                {
                    int outputsIguales = 0;
                    for (int k = 1; k < cantidadColumnasMaquinas; k++)
                    {
                        string[] transicionTemp = filaTemp[k].Split(',');
                        string[] transicionActual = sumaDirecta[j][k].Split(',');
                        if (transicionTemp[1].Equals(transicionActual[1]))
                        {
                            outputsIguales++;
                        }
                    }
                    if (outputsIguales == cantidadColumnasMaquinas - 1)
                    {
                        particion.Add(sumaDirecta[j][0] + "");
                        sumaDirecta.Remove(sumaDirecta[j]);
                        j = -1;
                    }
                    
                }
                particiones.Add(particion);
                i = -1;
            }
            //FINAL PARTICIÓN 1
            sumaDirecta = sumaDirectaMealy();
            List<List<string>> nuevasParticiones = new List<List<string>>();
            Boolean diferentes = true;
            while (diferentes)
            {

                for (int l = 0; l < particiones.Count; l++)
                {
                    List<string> particion = new List<string>();
                    
                    string[] aux = new string[particiones[l].Count];
                    particiones[l].CopyTo(aux);
                    particion = aux.ToList();
                    nuevasParticiones.Add(particion);
                    
                    if (particion.Count > 1)
                    {
                        for (int k = 0; k < particion.Count; k++)
                        {
                            string estado = particion[k];
                            List<string> nuevaParticion = new List<string>();
                            for (int i = 0; i < particion.Count; i++)
                            {

                                int sucesoresEnMismaParticion = 0;
                                List<List<string>> filaEstadoTemp = sumaDirecta.Where(x => x[0].Equals(particion[i])).ToList();
                                List<List<string>> filaEstadoActual = sumaDirecta.Where(x => x[0].Equals(estado)).ToList();
                                for (int j = 1; j < cantidadColumnasMaquinas; j++)
                                {
                                    string[] tempActual = filaEstadoActual[0][j].Split(',');
                                    string[] tempTemp = filaEstadoTemp[0][j].Split(',');
                                    if (particiones.Where(x => x.Contains(tempActual[0]) && x.Contains(tempTemp[0])).Count() != 0)
                                    {
                                        sucesoresEnMismaParticion++;
                                    }
                                }
                                if (sucesoresEnMismaParticion != cantidadColumnasMaquinas - 1)
                                {
                                    nuevaParticion.Add(particion[i]);
                                    particion.Remove(particion[i]);
                                    i = -1;
                                }
                            }
                            if (nuevaParticion.Count != 0)
                            {
                                nuevasParticiones.Add(nuevaParticion);
                            }
                        }
                    }
                }
                if(nuevasParticiones.Count == particiones.Count)
                {
                    diferentes = false;
                }
                imprimirParticiones(particiones);
                particiones = new List<List<string>>();
                foreach (List<string> particion in nuevasParticiones)
                {
                    particiones.Add(particion);
                };
                nuevasParticiones = new List<List<string>>();
            }
            return comprobarMaquinaDeMoore(particiones);
        }
        /// <summary>
        /// Permite imprimir las particiones dadas por parámetro con el fin de verificar que el algoritmo de particionamiento 
        /// funcione.
        /// </summary>
        /// <param name="particiones">Lista de listas que contiene las particiones de una máquina de suma directa</param>
        public void imprimirParticiones(List<List<string>> particiones)
        {
            foreach (List<string> particion in particiones)
            {
                Console.Write("{");
                foreach (string estado in particion)
                {
                    Console.Write(estado + ",");
                }
                Console.Write("}");
            }
        }
        /// <summary>
        /// Permite realizar el algoritmo de particionamiento sobre máquinas de moore con el fin de verificar si hay equivalencia 
        /// entre las máquinas.
        /// </summary>
        /// <returns>Retorna true si las máquinas resultan equivalentes, false en caso contrario</returns>
        public bool particionamientoMoore()
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

            return comprobarMaquinaDeMoore(lista);


        }
        /// <summary>
        /// Permite determinar si la partición encontrada al final del algoritmo de particionamiento cumple con las
        /// condiciones que necesita para concluir la equivalencia de las máquinas.
        /// Condición 1: Dentro de cada partición debe existir almenos un estado de cada una de las máquinas originales.
        /// Condición 2: Dentro de alguna de las particiones se encuentran los estados inciales de las máquinas originales.
        /// </summary>
        /// <param name="listaFinal">Particiones finales producto del algoritmo de particionamiento</param>
        /// <returns></returns>
        public bool comprobarMaquinaDeMoore(List<List<string>> listaFinal)
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
            return resultado;
        }
    }

}
