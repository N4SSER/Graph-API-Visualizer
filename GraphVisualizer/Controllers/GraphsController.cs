using GraphVisualizer.Data;
using GraphVisualizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphVisualizer.Controllers
{
    [Route("[controller]")]
    [ApiController]

    /// <summary>Class <c>GraphsController</c>  es el controlador HTTP de los grafos</summary>
    public class GraphsController : ControllerBase
    {
        private readonly GraphVisualizerContext _context;

        public GraphsController(GraphVisualizerContext context)
        {
            _context = context;
        }

        // GET: graphs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Graph>>> GetGraph()
        {
            return await _context.Graph.ToListAsync();
        }

        // GET: graphs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Graph>> GetGraph(int id)
        {
            var graph = await _context.Graph.FindAsync(id);

            if (graph == null)
            {
                return NotFound();
            }

            return graph;
        }

        // PUT: graphs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraph(int id, Graph graph)
        {
            if (id != graph.Id)
            {
                return BadRequest();
            }

            _context.Entry(graph).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraphExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: graphs
        [HttpPost]
        public async Task<ActionResult<Graph>> PostGraph(Graph graph)
        {
            _context.Graph.Add(graph);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraph", new { id = graph.Id }, graph);
        }

        // DELETE: graphs
        [HttpDelete]
        public async Task<IActionResult> DeleteGraph()
        {
            foreach (Graph g in _context.Graph)
            {
                var graph = await _context.Graph.FindAsync(g.Id);
                if (graph == null)
                {
                    return NotFound();
                }

                _context.Graph.Remove(graph);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: graphs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraph(int id)
        {
            var graph = await _context.Graph.FindAsync(id);
            if (graph == null)
            {
                return NotFound();
            }

            _context.Graph.Remove(graph);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GraphExists(int id)
        {
            return _context.Graph.Any(e => e.Id == id);
        }
    }
}