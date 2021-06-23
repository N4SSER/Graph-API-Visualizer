namespace GraphVisualizer.Models
{
    /// <summary>Class <c>Node</c>  es el objeto nodo del grafo</summary>
    public class Node
    {
        private static int CurrentId = 0;
        private int id;
        private int inDegree;
        private int outDegree;
        private string entity;

        public Node(int id, int inDegree, int outDegree, string entity)
        {
            this.id = id;
            this.inDegree = inDegree;
            this.outDegree = outDegree;
            this.entity = entity;
        }

        public Node()
        {
            this.id = CurrentId++;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar al nodo</summary>
        public int Id { get; set; }

        /// <summary>Attribute <c>InDegree</c>  es el número entero que indica el grado entrante</summary>
        public int InDegree { get; set; }

        /// <summary>Attribute <c>OutDegree</c>  es el número entero que indica el grado saliente</summary>
        public int OutDegree { get; set; }

        /// <summary>Attribute <c>Entity</c>  es el objeto que contiene los datos de la entidad almacenada en el nodo</summary>
        public string Entity { get; set; }
    }
}