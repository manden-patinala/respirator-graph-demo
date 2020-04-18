using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RespiratorGraphDemo.Views;

namespace RespiratorGraphDemo.Main
{
    public partial class SelectPortForm : Form, ISelectPortView
    {
        public SelectPortForm()
        {
            InitializeComponent();
            FillComboBoxSerialPort();
        }

        public bool Show()
        {
            DialogResult res = this.ShowDialog();

            if (res == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PortName
        {
            get
            {
                return comboBoxSerialPort.SelectedItem.ToString();
            }
        }

        private void FillComboBoxSerialPort()
        {
            comboBoxSerialPort.DataSource = SerialPort.GetPortNames();
        }

        private void SelectPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBoxSerialPort.SelectedIndex == -1)
                Application.Exit();
        }
    }
}
