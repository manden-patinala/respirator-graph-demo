using RespiratorGraphDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Common
{
    public class SerialPortDataEventArgs : EventArgs
    {

        private Graph graph;

        public SerialPortDataEventArgs(Graph graph) 
        {
            this.graph = graph;
        }

        public Graph Graph { get => graph; set => graph = value; }
    }
}
