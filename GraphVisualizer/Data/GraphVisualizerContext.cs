using GraphVisualizer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphVisualizer.Data
{
    public class GraphVisualizerContext : DbContext
    {
        public GraphVisualizerContext(DbContextOptions<GraphVisualizerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Graph> Graph { get; set; }

        public DbSet<Node> Node { get; set; }

        public DbSet<Edge> Edge { get; set; }
    }
}