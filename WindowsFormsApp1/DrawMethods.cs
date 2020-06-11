using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DrawMethods
    {
        Graphics gr;
        public DrawMethods(Form Form1)
        {
            gr = Form1.CreateGraphics();
        }
        public void DrawPoint(Color color, int X, int Y, int i)
        {
            string s = i.ToString();
            gr.DrawString(s, new Font("Arial", 10), new SolidBrush(color), X, Y);
            gr.FillRectangle(new SolidBrush(color), new Rectangle(X-2, Y-2, 5, 5));
        }

        public void DrawLine(Color color, int X1, int Y1, int X2, int Y2)
        {
            Pen pen = new Pen(color);
            gr.DrawLine(pen, X1, Y1, X2, Y2);
        }

        public void Clear()
        {
            gr.Clear(Color.White);
        }
    }
}
