namespace GraphVisualizer.Models
{
    /// <summary>Class <c>Edge</c>  es el objeto arista del grafo</summary>
    public class Edge
    {
        private static int CurrentId = 0;
        private int id;
        private int startNode;
        private int endNode;
        private float weight;

        public Edge(int startNode, int endNode, float weight)
        {
            this.id = CurrentId++;
            this.startNode = startNode;
            this.endNode = endNode;
            this.weight = weight;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar a la arista</summary>
        public int Id { get => id; set => this.id = value; }

        /// <summary>Attribute <c>Start</c>  es el número entero que indica el id del nodo inicial</summary>
        public int StartNode { get => startNode; set => this.startNode = value; }

        /// <summary>Attribute <c>End</c>  es el número entero que indica el id del nodo final</summary>
        public int EndNode { get => endNode; set => this.endNode = value; }

        /// <summary>Attribute <c>Magnitude</c>  es el número decimal que indica la magnitud de la arista</summary>
        public float Weight { get => weight; set => this.weight = value; }
    }
}