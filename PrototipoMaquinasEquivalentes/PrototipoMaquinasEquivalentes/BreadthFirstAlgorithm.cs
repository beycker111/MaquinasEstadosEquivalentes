using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMaquinasEquivalentes
{
    public class BreadthFirstAlgorithm
    {
        public State construirGrafo()
        {

            //

            State Aaron = new State("Aaron");
            State Betty = new State("Betty");
            State Brian = new State("Brian");
            Aaron.setEstadoAdyacente(Betty);
            Aaron.setEstadoAdyacente(Brian);

            State Catherine = new State("Catherine");
            State Carson = new State("Carson");
            State Darian = new State("Darian");
            State Derek = new State("Derek");
            State Luis = new State("Luis");
            State Beycker = new State("Beycker");
            State Angie = new State("Angie");

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
        public State Search(State origen, string destino)
        {
            Queue<State> Q = new Queue<State>();
            HashSet<State> S = new HashSet<State>();
            Q.Enqueue(origen);
            S.Add(origen);

            while (Q.Count > 0)
            {
                State p = Q.Dequeue();
                if (p.name == destino)
                    return p;
                foreach (State friend in p.getAdyacentStates)
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

        public List<State> Traverse(State root)
        {
            List<State> final = new List<State>();
            Queue<State> traverseOrder = new Queue<State>();

            Queue<State> Q = new Queue<State>();
            HashSet<State> S = new HashSet<State>();
            Q.Enqueue(root);
            S.Add(root);

            while (Q.Count > 0)
            {
                State p = Q.Dequeue();
                traverseOrder.Enqueue(p);

                foreach (State friend in p.getAdyacentStates)
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
                State p = traverseOrder.Dequeue();
                final.Add(p);
                //Console.WriteLine(p);
            }
            return final;
        }
    }
}
