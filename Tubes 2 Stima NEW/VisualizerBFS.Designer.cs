﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tubes_2_Stima_NEW
{

    public partial class VisualizerBFS
    {
        public static void Initialize()
        {
            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            for (int i = 0; i < BFS.ListTetap.Count; i++)
            {
                if (BFS.ListTetap[i]._PreRequisite.Count == 0)
                {
                    graph.AddNode("Test");
                } else
                {
                    for(int j = 0; j < BFS.ListTetap[i]._PreRequisite.Count; j++)
                    {
                        graph.AddEdge(BFS.ListTetap[i]._PreRequisite[j], BFS.ListTetap[i]._NamaMatKul);
                    }
                }
            }
            /*
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond; 
            */
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();
        }
    }
}