using BelazApp.Models;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BelazApp;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chart : ContentPage
    {
        public Chart(Parameter parameter)
        {
            //InitializeComponent();
            //List<Models.Point> points = Data.GetPoints(parameter);
            //List<ChartEntry> entries = new List<ChartEntry>();
            //foreach (var point in points)
            //{
            //    entries.Add(new ChartEntry(point.value)
            //    {
            //        Label = $"{point.time.ToString(@"hh\:mm")}",
            //        ValueLabel = point.value.ToString()
            //    }) ;
            //}
            //var chart = new LineChart
            //{
            //    Entries = entries,
            //    LineMode = LineMode.Straight,
            //    LabelTextSize = 20,
            //    LabelOrientation = Orientation.Horizontal,
            //    ValueLabelOrientation = Orientation.Horizontal
            //};
            //Layout1.Children.Add(new ChartView()
            //{
            //    Chart = chart,
            //    HeightRequest = 400,
            //    WidthRequest = 200
            //});
        }
    }
}