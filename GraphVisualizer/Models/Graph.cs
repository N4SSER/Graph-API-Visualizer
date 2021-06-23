using System.Collections.Generic;

namespace GraphVisualizer.Models
{
    /// <summary>Class <c>Graph</c>  es el objeto grafo que recibe y muestra la información de sus nodos y aristas</summary>
    public class Graph
    {
        private static int CurrentId = 0;
        private int id;
        private LinkedList<Node> nodes;
        private LinkedList<Edge> edges;

        public Graph(int id)
        {
            this.id = id;
        }

        public Graph()
        {
            this.id = CurrentId++;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar el grafo</summary>
        public int Id { get; set; }

        /// <summary>Attribute <c>Nodes</c>  es una colección de objetos tipo Node</summary>
        public LinkedList<Node> Nodes { get; set; }

        /// <summary>Attribute <c>Edges</c>  es una colección de objetos tipo Edge</summary>
        public LinkedList<Edge> Edges { get; set; }
    }
}