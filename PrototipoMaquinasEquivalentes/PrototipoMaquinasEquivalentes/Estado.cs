using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    public class Estado //Puede ser que aqui falte el public
    {
        private List<Estado> estadosAdyacentes = new List<Estado>();
        public Estado(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
        public List<Estado> getEstadosAdyacentes
        {
            get
            {
                return estadosAdyacentes;
            }
        }

        public void setEstadoAdyacente(Estado p)
        {
            estadosAdyacentes.Add(p);
        }

        

        public override string ToString()
        {
            return name;
        }
    }
}
