using GraphVisualizer.Data;
using GraphVisualizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GraphVisualizer.Controllers
{
    [Route("graphs/{id}/degree")]
    [ApiController]

    /// <summary>Class <c>DegreeController</c> es el controlador HTTP del grado del nodo del grafo</summary>
    public class DegreeController : ControllerBase
    {
        private readonly GraphVisualizerContext _context;

        public DegreeController(GraphVisualizerContext context)
        {
            _context = context;
        }

        // GET: graphs/{id}/degree
        [HttpGet]
        public async Task<ActionResult<Graph>> Degree([FromRoute] int id, [FromQuery] string sort)
        {
            var graph = await _context.Graph.FindAsync(id);

            if (GraphExists(id))
            {
                var averageDegree = AverageDegree(NodesCounter(), EdgesCounter());

                if (sort == "DESC")
                {
                    var degrees = await _context.Node.OrderByDescending(n => averageDegree).ToListAsync();
                    return Ok(degrees);
                }
                else if (sort == "ASC")
                {
                    var degrees = await _context.Node.OrderBy(n => averageDegree).ToListAsync();
                    return Ok(degrees);
                }

                return StatusCode(400, new JsonResult("ERROR 400: Graph getting degree process not completed"));
            }

            return StatusCode(404, new JsonResult("ERROR 404: Graph getting degree process not completed"));
        }

        private static int AverageDegree(int nodesCounter, int edgesCounter)
        {
            var averageDegree = (2 * (edgesCounter / nodesCounter));

            return averageDegree;
        }

        private int NodesCounter()
        {
            var dbNodes = _context.Node.ToList();
            var nodesCounter = dbNodes.Count;

            return nodesCounter;
        }

        private int EdgesCounter()
        {
            var dbEdges = _context.Edge.ToList();
            var edgesCounter = dbEdges.Count;

            return edgesCounter;
        }

        private bool GraphExists(int id)
        {
            return _context.Graph.Any(e => e.Id == id);
        }
    }
}