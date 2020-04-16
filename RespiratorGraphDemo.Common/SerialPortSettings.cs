using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Common
{
    public class SerialPortSettings
    {

        private string portName = "COM3";
        private int baudRate = 9600;
        private Parity parity = Parity.None;
        private int dataBits = 8;
        private StopBits stopBits = StopBits.One;
        private Handshake handshake = Handshake.None;

        public SerialPortSettings() { }

        public string PortName { get => portName; set => portName = value; }
        public int BaudRate { get => baudRate; set => baudRate = value; }
        public Parity Parity { get => parity; set => parity = value; }
        public int DataBits { get => dataBits; set => dataBits = value; }
        public StopBits StopBits { get => stopBits; set => stopBits = value; }
        public Handshake Handshake { get => handshake; set => handshake = value; }
    }
}
