using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ID { get; set; }
        static public int size = 0;

        public Vertex(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            ID = size++;
        }

        public int GetSquareDistance(int X, int Y)
        {
            return (X - this.X) * (X - this.X) + (Y - this.Y) * (Y - this.Y);
        }
    }
}
