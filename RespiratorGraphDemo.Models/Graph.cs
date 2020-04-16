using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Models
{
    public class Graph
    {

        private System.DateTime dateTime;
        private float flow;
        private float pressure;
        private float volume;

        public Graph() 
        {
            this.DateTime = DateTime.Now;
        }

        public float Flow { get => flow; set => flow = value; }
        public float Pressure { get => pressure; set => pressure = value; }
        public float Volume { get => volume; set => volume = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }

        public void setModel(string message)
        {
            var messageArray = message.Split(',');

            try
            {
                this.Flow = float.Parse(messageArray[0]);
                this.Pressure = float.Parse(messageArray[1]);
                this.Volume = float.Parse(messageArray[2]);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public override string ToString()
        {
            return $"Graph Model: {this.Flow}, {this.Pressure}, {this.Volume}";
        }
    }
}
