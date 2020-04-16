using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespiratorGraphDemo.Views
{
    public interface IMainView
    {
        CartesianChart CartesianChart1 { get; }
        CartesianChart CartesianChart2 { get; }
        CartesianChart CartesianChart3 { get; }
    }
}
