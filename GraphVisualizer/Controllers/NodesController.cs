using GraphVisualizer.Data;
using GraphVisualizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphVisualizer.Controllers
{
    [Route("graphs/{id}/nodes")]
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
            var node = await _context.Node.ToListAsync();
            return Ok(node);
        }

        // GET: graphs/{id}/nodes/{nodeId}
        [HttpGet("{nodeId}")]
        public async Task<ActionResult<Node>> GetNode(int nodeId)
        {
            var node = await _context.Node.FindAsync(nodeId);

            if (node == null)
            {
                return StatusCode(404, new JsonResult("ERROR 404: Node getting process not completed"));
            }

            return Ok(node);
        }

        // PUT: graphs/{id}/nodes/{nodeId}
        [HttpPut("{nodeId}")]
        public async Task<IActionResult> PutNode(int nodeId, Node node)
        {
            if (nodeId != node.Id)
            {
                return StatusCode(400, new JsonResult("ERROR 400: Node putting process not completed"));
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
                    return StatusCode(404, new JsonResult("ERROR 404: Node putting process not completed"));
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: graphs/{id}/nodes
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode([FromRoute] int id, Node node)
        {
            var graph = await _context.Graph.FindAsync(id);

            if (graph == null || node == null )
            {
                return StatusCode(500, new JsonResult("ERROR 500: Node posting process not completed"));
            }
            else if (NodeExists(node.Id))
            {
                return StatusCode(400, new JsonResult("ERROR 400: Node posting process not completed"));
            }

            graph.Nodes.Append(node);
            _context.Graph.Update(graph);

            _context.Node.Add(node);
            await _context.SaveChangesAsync();

            return Ok(node.Id);
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
                    return StatusCode(404, new JsonResult("ERROR 404: Node deleting process not completed"));
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
                return StatusCode(404, new JsonResult("ERROR 404: Node deleting process not completed"));
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