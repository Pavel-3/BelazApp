using BelazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleReports : ContentPage
    {
        public VehicleReport vehicleReport { get; set; }
        public VehicleReports(int vehicleId)
        {
            Title = "Отчёты";
            InitializeComponent();
            vehicleReport = Data.GetReports(vehicleId);
            var listView = new ListView()
            {
                ItemsSource = vehicleReport.vehicleReporDatas,
                HasUnevenRows = true,
                SelectionMode = 0,
                ItemTemplate = new DataTemplate(() =>
                {
                    ReportCell cell = new ReportCell();
                    cell.SetBinding(ReportCell.DataProperty, "ReportDate");
                    cell.SetBinding(ReportCell.DescriptionProperty, "Text");
                    return cell;
                })
            };

            Layout1.Children.Add(listView);
        }
    }
}