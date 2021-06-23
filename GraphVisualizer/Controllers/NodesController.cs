using GraphVisualizer.Data;
using GraphVisualizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphVisualizer.Controllers
{
    [Route("graphs/{id}/[controller]")]
    [ApiController]

    /// <summary>Class <c>NodesController</c>  es el controlador HTTP de los nodos del grafo</summary>
    public class NodesController : ControllerBase
    {
        private readonly GraphVisualizerContext _context;

        public NodesController(GraphVisualizerContext context)
        {
            _context = context;
        }

        // GET: graphs/{id}/nodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetNode()
        {
            return await _context.Node.ToListAsync();
        }

        // GET: graphs/{id}/nodes/{nodeId}
        [HttpGet("{nodeId}")]
        public async Task<ActionResult<Node>> GetNode(int nodeId)
        {
            var node = await _context.Node.FindAsync(nodeId);

            if (node == null)
            {
                return NotFound();
            }

            return node;
        }

        // PUT: graphs/{id}/nodes/{nodeId}
        [HttpPut("{nodeId}")]
        public async Task<IActionResult> PutNode(int nodeId, Node node)
        {
            if (nodeId != node.Id)
            {
                return BadRequest();
            }

            _context.Entry(node).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(nodeId))
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

        // POST: graphs/{id}/nodes
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode(Node node)
        {
            _context.Node.Add(node);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNode", new { nodeId = node.Id }, node);
        }

        // DELETE: graphs/{id}/nodes
        [HttpDelete]
        public async Task<IActionResult> DeleteNode()
        {
            foreach (Node n in _context.Node)
            {
                var node = await _context.Node.FindAsync(n.Id);
                if (node == null)
                {
                    return NotFound();
                }

                _context.Node.Remove(node);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: graphs/{id}/nodes/{nodeId}
        [HttpDelete("{nodeId}")]
        public async Task<IActionResult> DeleteNode(int nodeId)
        {
            var node = await _context.Node.FindAsync(nodeId);
            if (node == null)
            {
                return NotFound();
            }

            _context.Node.Remove(node);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NodeExists(int nodeId)
        {
            return _context.Node.Any(e => e.Id == nodeId);
        }
    }
}