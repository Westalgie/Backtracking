using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Edge
    {
        public int ID1 { get; set; }
        public int ID2 { get; set; }
        public bool inPath { get; set; }
        public Edge(int ID1, int ID2)
        {
            this.ID1 = ID1;
            this.ID2 = ID2;
            inPath = false;
        }
    }
}
