using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using RespiratorGraphDemo.Models;
using RespiratorGraphDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace RespiratorGraphDemo.ViewModels
{
    public class MainViewModel
    {

        public CartesianChart cartesianChart1;
        public CartesianChart cartesianChart2;
        public CartesianChart cartesianChart3;
        public string labelParameter4;
        public string labelParameter5;
        public string labelParameter6;
        public string labelParameter7;
        public string labelParameter8;
        public string labelParameter9;
        public string labelParameter10;

        public ChartValues<Graph> CartesianChart1ChartValues { get; set; }
        public ChartValues<Graph> CartesianChart2ChartValues { get; set; }
        public ChartValues<Graph> CartesianChart3ChartValues { get; set; }

        public MainViewModel(IMainView mainView)
        {
            this.cartesianChart1 = mainView.CartesianChart1;
            this.cartesianChart2 = mainView.CartesianChart2;
            this.cartesianChart3 = mainView.CartesianChart3;
            this.labelParameter4 = mainView.LabelParameter4;
            this.labelParameter5 = mainView.LabelParameter5;
            this.labelParameter6 = mainView.LabelParameter6;
            this.labelParameter7 = mainView.LabelParameter7;
            this.labelParameter8 = mainView.LabelParameter8;
            this.labelParameter9 = mainView.LabelParameter9;
            this.labelParameter10 = mainView.LabelParameter10;
        }

        public void CreateCharts()
        {
            this.CartesianChart1ChartValues = new ChartValues<Graph>();

            var mapper1 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Parameter1);

            var lineSeries1 = new LineSeries
            {
                Values = this.CartesianChart1ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 1,
                Fill = new SolidColorBrush(Colors.White),
                Stroke = new SolidColorBrush(Colors.White)
            };

            var seriesCollection1 = new SeriesCollection(mapper1);
            seriesCollection1.Add(lineSeries1);

            this.cartesianChart1.Series = seriesCollection1;
            this.cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });
            /*this.cartesianChart1.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });*/

            SetAxisLimits(DateTime.Now, this.cartesianChart1);

            this.CartesianChart2ChartValues = new ChartValues<Graph>();

            var mapper2 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Parameter2);

            var lineSeries2 = new LineSeries
            {
                Values = this.CartesianChart2ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 1,
                Fill = new SolidColorBrush(Colors.White),
                Stroke = new SolidColorBrush(Colors.White)
            };

            var seriesCollection2 = new SeriesCollection(mapper2);
            seriesCollection2.Add(lineSeries2);

            this.cartesianChart2.Series = seriesCollection2;
            this.cartesianChart2.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });
            /*this.cartesianChart2.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });*/

            SetAxisLimits(DateTime.Now, this.cartesianChart2);

            this.CartesianChart3ChartValues = new ChartValues<Graph>();

            var mapper3 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Parameter3);

            var lineSeries3 = new LineSeries
            {
                Values = this.CartesianChart3ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 1,
                Fill = new SolidColorBrush(Colors.White),
                Stroke = new SolidColorBrush(Colors.White)
            };

            var seriesCollection3 = new SeriesCollection(mapper3);
            seriesCollection3.Add(lineSeries3);

            this.cartesianChart3.Series = seriesCollection3;
            this.cartesianChart3.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });
            /*this.cartesianChart3.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });*/

            SetAxisLimits(DateTime.Now, this.cartesianChart3);
        }

        public void AddModel(Graph graph) 
        {
            var now = DateTime.Now;

            CartesianChart1ChartValues.Add(graph);

            SetAxisLimits(now, this.cartesianChart1);

            //lets only use the last 30 values
            if (CartesianChart1ChartValues.Count > 30) CartesianChart1ChartValues.RemoveAt(0);

            CartesianChart2ChartValues.Add(graph);

            SetAxisLimits(now, this.cartesianChart2);

            //lets only use the last 30 values
            if (CartesianChart2ChartValues.Count > 30) CartesianChart2ChartValues.RemoveAt(0);

            CartesianChart3ChartValues.Add(graph);

            SetAxisLimits(now, this.cartesianChart3);

            //lets only use the last 30 values
            if (CartesianChart3ChartValues.Count > 30) CartesianChart3ChartValues.RemoveAt(0);

            this.labelParameter4 = graph.Parameter4.ToString();
            this.labelParameter5 = graph.Parameter5.ToString();
            this.labelParameter6 = graph.Parameter6.ToString();
            this.labelParameter7 = graph.Parameter7.ToString();
            this.labelParameter8 = graph.Parameter8.ToString();
            this.labelParameter9 = graph.Parameter9.ToString();
            this.labelParameter10 = graph.Parameter10.ToString();
        }

        private void SetAxisLimits(DateTime now, CartesianChart cartesianChart)
        {
            cartesianChart.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            cartesianChart.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(4).Ticks; //we only care about the last 8 seconds
        }

    }
}
