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

        public Node(string entity)
        {
            this.id = CurrentId++;
            this.entity = entity;
        }

        /// <summary>Attribute <c>Id</c>  es el número único asignado para identificar al nodo</summary>
        public int Id { get => id; set => this.id = value; }

        /// <summary>Attribute <c>InDegree</c>  es el número entero que indica el grado entrante</summary>
        public int InDegree { get => inDegree; set => this.inDegree = value; }

        /// <summary>Attribute <c>OutDegree</c>  es el número entero que indica el grado saliente</summary>
        public int OutDegree { get => outDegree; set => this.outDegree = value; }

        /// <summary>Attribute <c>Entity</c>  es el objeto que contiene los datos de la entidad almacenada en el nodo</summary>
        public string Entity { get => entity; set => this.entity = value; }
    }
}