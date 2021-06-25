using System.Collections.Generic;

namespace GraphVisualizer.Models
{
    /// <summary>Class <c>Graph</c>  es el objeto grafo que recibe y muestra la información de sus nodos y aristas</summary>
    public class Graph
    {
        private static int CurrentId = 0;
        private int id;
        private LinkedList<Node> nodes = new LinkedList<Node>();
        private LinkedList<Edge> edges = new LinkedList<Edge>();

        public Graph()
        {
            this.id = CurrentId++;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar el grafo</summary>
        public int Id { get => id; set => this.id = value; }

        /// <summary>Attribute <c>Nodes</c>  es una colección de objetos tipo Node</summary>
        public LinkedList<Node> Nodes { get => nodes; set => this.nodes = value; }

        /// <summary>Attribute <c>Edges</c>  es una colección de objetos tipo Edge</summary>
        public LinkedList<Edge> Edges { get => edges; set => this.edges = value; }
    }
}