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
        private float parameter1;
        private float parameter2;
        private float parameter3;
        private float parameter4;
        private float parameter5;
        private float parameter6;
        private float parameter7;
        private float parameter8;
        private float parameter9;
        private float parameter10;

        public Graph() 
        {
            this.DateTime = DateTime.Now;
        }

        public float Parameter1 { get => parameter1; set => parameter1 = value; }
        public float Parameter2 { get => parameter2; set => parameter2 = value; }
        public float Parameter3 { get => parameter3; set => parameter3 = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public float Parameter4 { get => parameter4; set => parameter4 = value; }
        public float Parameter5 { get => parameter5; set => parameter5 = value; }
        public float Parameter6 { get => parameter6; set => parameter6 = value; }
        public float Parameter7 { get => parameter7; set => parameter7 = value; }
        public float Parameter8 { get => parameter8; set => parameter8 = value; }
        public float Parameter9 { get => parameter9; set => parameter9 = value; }
        public float Parameter10 { get => parameter10; set => parameter10 = value; }

        public void setModel(string message)
        {
            var messageArray = message.Split(',');

            try
            {
                this.Parameter1 = float.Parse(messageArray[0]);
                this.Parameter2 = float.Parse(messageArray[1]);
                this.Parameter3 = float.Parse(messageArray[2]);
                this.Parameter4 = float.Parse(messageArray[3]);
                this.Parameter5 = float.Parse(messageArray[4]);
                this.Parameter6 = float.Parse(messageArray[5]);
                this.Parameter7 = float.Parse(messageArray[6]);
                this.Parameter8 = float.Parse(messageArray[7]);
                this.Parameter9 = float.Parse(messageArray[9]);
                this.Parameter10 = float.Parse(messageArray[10]);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public override string ToString()
        {
            return $"Graph Model: {this.Parameter1}, {this.Parameter2}, {this.Parameter3}";
        }
    }
}
