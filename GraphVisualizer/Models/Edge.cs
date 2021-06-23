namespace GraphVisualizer.Models
{
    /// <summary>Class <c>Edge</c>  es el objeto arista del grafo</summary>
    public class Edge
    {
        private static int CurrentId = 0;
        private int id;
        private int start;
        private int end;
        private float magnitude;

        public Edge(int id, int start, int end, float magnitude)
        {
            this.id = id;
            this.start = start;
            this.end = end;
            this.magnitude = magnitude;
        }

        public Edge()
        {
            this.id = CurrentId++;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar a la arista</summary>
        public int Id { get; set; }

        /// <summary>Attribute <c>Start</c>  es el número entero que indica el id del nodo inicial</summary>
        public int Start { get; set; }

        /// <summary>Attribute <c>End</c>  es el número entero que indica el id del nodo final</summary>
        public int End { get; set; }

        /// <summary>Attribute <c>Magnitude</c>  es el número decimal que indica la magnitud de la arista</summary>
        public float Magnitude { get; set; }
    }
}