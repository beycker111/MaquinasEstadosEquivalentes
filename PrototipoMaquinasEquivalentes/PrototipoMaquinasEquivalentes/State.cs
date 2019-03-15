using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    public class State //Puede ser que aqui falte el public
    {
        /// <summary>
        /// Representan los estados a los que se puede llegar desde el estado actual,
        /// con los diferentes estímulos del alfabeto de entrada.
        /// </summary>
        private List<State> adyacentStates = new List<State>();

        /// <summary>
        /// Representa el nombre que identifica al estado actual.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Permite el acceso a los estados adyacentes del estado actual. 
        /// </summary>
        public List<State> getAdyacentStates
        {
            get
            {
                return adyacentStates;
            }
        }

        /// <summary>
        /// Permite agregar un nuevo estado adyacente a la lista de estados adyacentes del estado actual.
        /// </summary>
        /// <param name="p">Nuevo estado adyacente al estado actual</param>
        public void setEstadoAdyacente(State p)
        {
            adyacentStates.Add(p);
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Permite crear un nuevo estado.
        /// </summary>
        /// <param name="name">Identificador del estado a crear</param>
        public State(string name)
        {
            this.name = name;
        }
    }
}
