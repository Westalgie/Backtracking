using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        int drawMode = 0;
        int i = -1;
        int FirstVertexID = -1;
        Graph graph;
        public DrawMethods DM;
        public Form1()
        {
            InitializeComponent();
            DM = new DrawMethods(this);
            graph = new Graph();
        }

        private void DrawVertexes_Click(object sender, EventArgs e)
        {
            drawMode = 1;
        }

        private void DrawEdges_Click(object sender, EventArgs e)
        {
            drawMode = 2;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            i++;
            switch (drawMode)
            {
                case 1:
                    DM.DrawPoint(Color.Black, e.X, e.Y, i);
                    graph.AddVertex(new Vertex(e.X, e.Y));
                    break;
                case 2:
                    foreach (Vertex item in graph.Vertexes)
                    {
                        if (item.GetSquareDistance(e.X, e.Y) < 1000)
                        {
                            if (FirstVertexID == -1)
                            {
                                FirstVertexID = item.ID;
                            }
                            else
                            {
                                if (FirstVertexID != item.ID)
                                {
                                    graph.AddEdge(new Edge(FirstVertexID, item.ID));
                                    DM.DrawLine(Color.Black, graph.Vertexes[FirstVertexID].X, graph.Vertexes[FirstVertexID].Y, graph.Vertexes[item.ID].X, graph.Vertexes[item.ID].Y);
                                    FirstVertexID = -1;
                                }
                                else
                                    break;
                            }
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {
            List<Edge> res = new List<Edge>();
            if (graph.isFullPathExist(ref res))
            {
                if (res.Count == 0)
                {
                    textBox1.Text = "Всего одна вершина";
                }
                else
                {
                    string tmp = "Последовательность вершин: ";
                    tmp = tmp + res[res.Count - 1].ID2.ToString() + res[res.Count - 1].ID1.ToString();
                    int prev = res[res.Count - 1].ID1;
                    for (int i = res.Count - 2; i >= 0; i--)
                    {
                        prev = res[i].ID1 + res[i].ID2 - prev;
                        tmp = tmp + prev.ToString();

                    }
                    textBox1.Text = tmp;
                }
            }
            else
            {
                textBox1.Text = "Такой граф построить нельзя";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            graph = null;
            graph = new Graph();
            DM.Clear();
            FirstVertexID = -1;
            Vertex.size = 0;
            textBox1.Text = "";
            i = -1;
        }
    }
}
