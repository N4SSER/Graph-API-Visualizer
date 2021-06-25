using GraphVisualizer.Data;
using GraphVisualizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphVisualizer.Controllers
{
    [Route("graphs/{id}/dijkstra")]
    [ApiController]

    /// <summary>Class <c>DijkstraController</c> es el controlador HTTP del dijkstra del nodo del grafo</summary>
    public class DijkstraController : ControllerBase
    {
        private readonly GraphVisualizerContext _context;

        public DijkstraController(GraphVisualizerContext context)
        {
            _context = context;
        }

        // GET: graphs/{id}/dijkstra
        [HttpGet]
        public async Task<ActionResult<Graph>> Dijkstra([FromRoute] int id, [FromQuery] int startNode, [FromQuery] int endNode)
        {
            var graph = await _context.Graph.FindAsync(id);

            if (GraphExists(id))
            {
                if (NodeExists(startNode) && NodeExists(endNode))
                {
                    var graphPathCounter = 0;
                    var graphPath = new List<Node>();
                    var dijkstra = new Dictionary<int, List<Node>>();
                    // CALC
                    dijkstra.Add(graphPathCounter, graphPath);
                    return Ok(dijkstra);
                }

                return StatusCode(404, new JsonResult("ERROR 404: Graph getting dijkstra process not completed"));
            }

            return StatusCode(404, new JsonResult("ERROR 404: Graph getting dijkstra process not completed"));
        }

        private bool GraphExists(int id)
        {
            return _context.Graph.Any(e => e.Id == id);
        }

        private bool NodeExists(int nodeId)
        {
            return _context.Node.Any(e => e.Id == nodeId);
        }
    }
}