using RespiratorGraphDemo.Common;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Controllers
{
    public class SerialPortController
    {

        private SerialPort serialPort;
        private SerialPortSettings serialPortSettings = new SerialPortSettings();
        private StringBuilder stringBuilder = new StringBuilder();
        public event EventHandler<SerialPortDataEventArgs> NewSerialPortDataRecieved;

        public SerialPortController() { }

        public SerialPort Serialport { get => serialPort; set => serialPort = value; }
        public SerialPortSettings SerialPortSettings { get => serialPortSettings; set => serialPortSettings = value; }
        public StringBuilder StringBuilder { get => stringBuilder; set => stringBuilder = value; }

        public void Connect() 
        {
            if (serialPort != null && serialPort.IsOpen)
                serialPort.Close();

            serialPort = new SerialPort();
            serialPort.PortName = serialPortSettings.PortName;
            serialPort.BaudRate = serialPortSettings.BaudRate;
            serialPort.Parity = serialPortSettings.Parity;
            serialPort.DataBits = serialPortSettings.DataBits;
            serialPort.StopBits = serialPortSettings.StopBits;
            serialPort.Handshake = serialPortSettings.Handshake;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            try 
            {
                if (!serialPort.IsOpen)
                    serialPort.Open();
            }
            catch
            {
                Console.WriteLine("Error Opening Port.");
            }
        }

        public void Disconnect()
        {
            serialPort.Close();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                stringBuilder.Append(serialPort.ReadExisting());

                if (!stringBuilder.ToString().Contains(Constants.CHARACTER_END_CONTROL))
                    return;

                if (stringBuilder.ToString().Split(',').Length < 10)
                    return;

                var graph = new Models.Graph();
                graph.setModel(stringBuilder.ToString());

                stringBuilder.Clear();

                if (NewSerialPortDataRecieved != null)
                    NewSerialPortDataRecieved?.Invoke(this, new SerialPortDataEventArgs(graph));
            }
        }
    }
}
