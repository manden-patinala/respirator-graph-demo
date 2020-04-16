using LiveCharts;
using LiveCharts.Wpf;
using RespiratorGraphDemo.Controllers;
using RespiratorGraphDemo.ViewModels;
using RespiratorGraphDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RespiratorGraphDemo.Main
{
    public partial class Main : Form, IMainView
    {

        private SerialPortController serialPortController = new SerialPortController();
        private MainViewModel mainViewModel;

        public Main()
        {
            InitializeComponent();
        }

        public CartesianChart CartesianChart1
        {
            get { return cartesianChart1; }
        }

        public CartesianChart CartesianChart2
        {
            get { return cartesianChart2; }
        }

        public CartesianChart CartesianChart3
        {
            get { return cartesianChart3; }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.mainViewModel = new MainViewModel(this);
            this.mainViewModel.CreateCharts();

            serialPortController.NewSerialPortDataRecieved += SerialPortController_NewSerialPortDataRecieved;
            serialPortController.Connect();
        }

        private void SerialPortController_NewSerialPortDataRecieved(object sender, Common.SerialPortDataEventArgs e)
        {
            Console.WriteLine(e.Graph.ToString());
            this.mainViewModel.AddModel(e.Graph);
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            serialPortController.Disconnect();
        }
    }
}
