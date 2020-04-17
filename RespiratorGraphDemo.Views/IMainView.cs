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
        string LabelParameter4 { get; }
        string LabelParameter5 { get; }
        string LabelParameter6 { get; }
        string LabelParameter7 { get; }
        string LabelParameter8 { get; }
        string LabelParameter9 { get; }
        string LabelParameter10 { get; }
    }
}
