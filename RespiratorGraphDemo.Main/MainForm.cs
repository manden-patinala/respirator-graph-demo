using LiveCharts;
using LiveCharts.Wpf;
using RespiratorGraphDemo.Common;
using RespiratorGraphDemo.Controllers;
using RespiratorGraphDemo.Models;
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
using System.Windows.Threading;

namespace RespiratorGraphDemo.Main
{
    public partial class MainForm : Form, IMainView
    {

        public SerialPortController serialPortController = new SerialPortController();
        public MainViewModel mainViewModel;

        public MainForm()
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

        public string LabelParameter4 
        {
            get { return labelParameter4.Text; }
        }

        public string LabelParameter5
        {
            get { return labelParameter5.Text; }
        }

        public string LabelParameter6
        {
            get { return labelParameter6.Text; }
        }

        public string LabelParameter7
        {
            get { return labelParameter7.Text; }
        }

        public string LabelParameter8
        {
            get { return labelParameter8.Text; }
        }

        public string LabelParameter9
        {
            get { return labelParameter9.Text; }
        }
        public string LabelParameter10
        {
            get { return labelParameter10.Text; }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            SelectPortForm selectPort = new SelectPortForm();
            serialPortController.SelectPortName(selectPort);

            this.mainViewModel = new MainViewModel(this);
            this.mainViewModel.CreateCharts();

            serialPortController.NewSerialPortDataRecieved += SerialPortController_NewSerialPortDataRecieved;
            serialPortController.Connect();
        }

        private void SerialPortController_NewSerialPortDataRecieved(object sender, Common.SerialPortDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialPortDataEventArgs>(SerialPortController_NewSerialPortDataRecieved), new object[] { sender, e });
                return;
            }

            Console.WriteLine(e.Graph.ToString());
            this.mainViewModel.AddModel(e.Graph);
            this.labelParameter4.Text = this.mainViewModel.labelParameter4;
            this.labelParameter5.Text = this.mainViewModel.labelParameter5;
            this.labelParameter6.Text = this.mainViewModel.labelParameter6;
            this.labelParameter7.Text = this.mainViewModel.labelParameter7;
            this.labelParameter8.Text = this.mainViewModel.labelParameter8;
            this.labelParameter9.Text = this.mainViewModel.labelParameter9;
            this.labelParameter10.Text = this.mainViewModel.labelParameter10;
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            serialPortController.Disconnect();
        }
    }
}
