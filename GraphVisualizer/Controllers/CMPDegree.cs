using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphVisualizer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphVisualizer.Controllers
{
    public class CMPDegree : ControllerBase
    {
        private readonly GraphVisualizerContext _context;
        private Dictionary<int, int> inDegree;
        public Dictionary<int, int> outDegree;
        public CMPDegree(GraphVisualizerContext context)
        {
            _context = context;
            _ = MakeDegrees();
        }
        private async Task MakeDegrees()
        {
            var edges = await _context.Edge.ToListAsync();
            var nodes = await _context.Node.ToListAsync();
            var startN = new int[edges.ToArray().Count()];
            var endN = new int[edges.ToArray().Count()];
            foreach(Models.Edge e in edges.ToArray())
            {
                startN.Append(e.StartNode);
                endN.Append(e.EndNode);
            }
            outDegree = TimesRepeated(startN);
            inDegree = TimesRepeated(endN);

        }
        public Dictionary<int, int> OutDegree()
        {
            return outDegree; 
        }
        public Dictionary<int, int> InDegree()
        {
            return inDegree;
        }
        private Dictionary<int,int> TimesRepeated(int[] x)
        {
            var  idDegree = new Dictionary<int, int>();
            for (int i = 0; i < x.Length - 1; i++)
            {
                int count = 1;
                for (int j = i + 1; j < x.Length; j++)
                {
                    if (x[i] == x[j])
                    {
                        count++;
                    }
                    idDegree.Add(x[i], count);
                }
            }
            return idDegree;
        }
    }

}
