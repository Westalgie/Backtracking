using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    public class Graph
    {
        public List<Edge> Edges = new List<Edge>();
        public List<Vertex> Vertexes = new List<Vertex>();
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
        public bool isFullPathExist(ref List<Edge> res, int depth = 0, int prevVertexID = -1)
        {
            if (depth == Edges.Count)
                return true;
            foreach (Edge edge in Edges)
            {
                if (edge.inPath)
                    continue;
                edge.inPath = true;
                if (prevVertexID == edge.ID1 || prevVertexID == edge.ID2)
                {
                    if (isFullPathExist(ref res, depth + 1, edge.ID1 + edge.ID2 - prevVertexID))
                    {
                        //Добавить вершину в путь
                        res.Add(edge);
                        return true;

                    }
                }
                else if (prevVertexID == -1)
                {
                    if (isFullPathExist(ref res, depth + 1, edge.ID1))
                    {
                        //Добавить 2 вершины в путь
                        res.Add(edge);
                        return true;
                    }
                    else if (isFullPathExist(ref res, depth + 1, edge.ID2))
                    {
                        //Добавить 2 вершины в путь
                        int ID = edge.ID1;
                        edge.ID1 = edge.ID2;
                        edge.ID2 = ID;
                        res.Add(edge);
                        return true;
                    }
                }
                edge.inPath = false;
            }

            return false;
        }
    }
}

