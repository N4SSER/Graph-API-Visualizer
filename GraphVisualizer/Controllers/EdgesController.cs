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

    /// <summary>Class <c>EdgesController</c>  es el controlador HTTP de las aristas del grafo</summary>
    public class EdgesController : ControllerBase
    {
        private readonly GraphVisualizerContext _context;

        public EdgesController(GraphVisualizerContext context)
        {
            _context = context;
        }

        // GET: graphs/{id}/edges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edge>>> GetEdge()
        {
            var edge = await _context.Edge.ToListAsync();
            return Ok(edge);
        }

        // GET: graphs/{id}/edges/{edgeId}
        [HttpGet("{edgeId}")]
        public async Task<ActionResult<Edge>> GetEdge(int edgeId)
        {
            var edge = await _context.Edge.FindAsync(edgeId);

            if (edge == null)
            {
                return StatusCode(404, new JsonResult("ERROR 404: Edge getting process not completed"));
            }

            return Ok(edge);
        }

        // PUT: graphs/{id}/edges/{edgeId}
        [HttpPut("{edgeId}")]
        public async Task<IActionResult> PutEdge(int edgeId, Edge edge)
        {
            if (edgeId != edge.Id)
            {
                return StatusCode(400, new JsonResult("ERROR 400: Edge putting process not completed"));
            }

            _context.Entry(edge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdgeExists(edgeId))
                {
                    return StatusCode(404, new JsonResult("ERROR 404: Edge putting process not completed"));
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: graphs/{id}/edges/
        [HttpPost]
        public async Task<ActionResult<Edge>> PostEdge(Edge edge)
        {
            if (edge == null)
            {
                return StatusCode(500, new JsonResult("ERROR 500: Edge posting process not completed"));
            }
            else if (EdgeExists(edge.Id))
            {
                return StatusCode(400, new JsonResult("ERROR 400: Edge posting process not completed"));
            }

            _context.Edge.Add(edge);
            await _context.SaveChangesAsync();

            return Ok(edge.Id);
        }

        // DELETE: graphs/{id}/edges/
        [HttpDelete]
        public async Task<IActionResult> DeleteEdge()
        {
            foreach (Edge e in _context.Edge)
            {
                var edge = await _context.Edge.FindAsync(e.Id);
                if (edge == null)
                {
                    return StatusCode(404, new JsonResult("ERROR 404: Edge deleting process not completed"));
                }

                _context.Edge.Remove(edge);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: graphs/{id}/edges/{edgeId}
        [HttpDelete("{edgeId}")]
        public async Task<IActionResult> DeleteEdge(int edgeId)
        {
            var edge = await _context.Edge.FindAsync(edgeId);
            if (edge == null)
            {
                return StatusCode(404, new JsonResult("ERROR 404: Edge deleting process not completed"));
            }

            _context.Edge.Remove(edge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EdgeExists(int edgeId)
        {
            return _context.Edge.Any(e => e.Id == edgeId);
        }
    }
}