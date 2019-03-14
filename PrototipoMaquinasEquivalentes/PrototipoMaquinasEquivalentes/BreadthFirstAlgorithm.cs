using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    public class BreadthFirstAlgorithm
    {
        public Estado construirGrafo()
        {

            //

            Estado Aaron = new Estado("Aaron");
            Estado Betty = new Estado("Betty");
            Estado Brian = new Estado("Brian");
            Aaron.setEstadoAdyacente(Betty);
            Aaron.setEstadoAdyacente(Brian);

            Estado Catherine = new Estado("Catherine");
            Estado Carson = new Estado("Carson");
            Estado Darian = new Estado("Darian");
            Estado Derek = new Estado("Derek");
            Estado Luis = new Estado("Luis");
            Estado Beycker = new Estado("Beycker");
            Estado Angie = new Estado("Angie");

            Betty.setEstadoAdyacente(Catherine);
            Betty.setEstadoAdyacente(Darian);
            Brian.setEstadoAdyacente(Carson);
            Brian.setEstadoAdyacente(Derek);
            Brian.setEstadoAdyacente(Luis);
            Luis.setEstadoAdyacente(Beycker);
            Angie.setEstadoAdyacente(Beycker);
            Beycker.setEstadoAdyacente(Aaron);

            return Betty;
        }

        //http://en.wikipedia.org/wiki/Breadth-first_search#Pseudocode
        public Estado Search(Estado origen, string destino)
        {
            Queue<Estado> Q = new Queue<Estado>();
            HashSet<Estado> S = new HashSet<Estado>();
            Q.Enqueue(origen);
            S.Add(origen);

            while (Q.Count > 0)
            {
                Estado p = Q.Dequeue();
                if (p.name == destino)
                    return p;
                foreach (Estado friend in p.getEstadosAdyacentes)
                {
                    if (!S.Contains(friend))
                    {
                        Q.Enqueue(friend);
                        S.Add(friend);
                    }
                }
            }
            return null;
        }

        public List<Estado> Traverse(Estado root)
        {
            List<Estado> final = new List<Estado>();
            Queue<Estado> traverseOrder = new Queue<Estado>();

            Queue<Estado> Q = new Queue<Estado>();
            HashSet<Estado> S = new HashSet<Estado>();
            Q.Enqueue(root);
            S.Add(root);

            while (Q.Count > 0)
            {
                Estado p = Q.Dequeue();
                traverseOrder.Enqueue(p);

                foreach (Estado friend in p.getEstadosAdyacentes)
                {
                    if (!S.Contains(friend))
                    {
                        Q.Enqueue(friend);
                        S.Add(friend);
                    }
                }
            }

            while (traverseOrder.Count > 0)
            {
                Estado p = traverseOrder.Dequeue();
                final.Add(p);
                //Console.WriteLine(p);
            }
            return final;
        }
    }
}
