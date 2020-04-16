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
using System.Windows.Threading;

namespace RespiratorGraphDemo.ViewModels
{
    public class MainViewModel
    {

        public CartesianChart cartesianChart1;
        public CartesianChart cartesianChart2;
        public CartesianChart cartesianChart3;

        public ChartValues<Graph> CartesianChart1ChartValues { get; set; }
        public ChartValues<Graph> CartesianChart2ChartValues { get; set; }
        public ChartValues<Graph> CartesianChart3ChartValues { get; set; }

        public MainViewModel(IMainView mainView)
        {
            this.cartesianChart1 = mainView.CartesianChart1;
            this.cartesianChart2 = mainView.CartesianChart2;
            this.cartesianChart3 = mainView.CartesianChart3;
        }

        public void CreateCharts()
        {
            this.CartesianChart1ChartValues = new ChartValues<Graph>();

            var mapper1 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Flow);

            var lineSeries1 = new LineSeries
            {
                Values = this.CartesianChart1ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 2
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
            this.cartesianChart1.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });

            SetAxisLimits(DateTime.Now, this.cartesianChart1);

            this.CartesianChart2ChartValues = new ChartValues<Graph>();

            var mapper2 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Pressure);

            var lineSeries2 = new LineSeries
            {
                Values = this.CartesianChart2ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 2
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
            this.cartesianChart2.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });

            SetAxisLimits(DateTime.Now, this.cartesianChart2);

            this.CartesianChart3ChartValues = new ChartValues<Graph>();

            var mapper3 = Mappers.Xy<Graph>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Volume);

            var lineSeries3 = new LineSeries
            {
                Values = this.CartesianChart3ChartValues,
                PointGeometrySize = 1,
                StrokeThickness = 2
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
            this.cartesianChart3.AxisY.Add(new Axis
            {
                MaxValue = 70,
                MinValue = -70,
                LabelFormatter = value => value.ToString()
            });

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
        }

        private void SetAxisLimits(DateTime now, CartesianChart cartesianChart)
        {
            cartesianChart.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            cartesianChart.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(4).Ticks; //we only care about the last 8 seconds
        }

    }
}
