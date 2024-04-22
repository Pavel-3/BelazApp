using BelazApp.Models;
using BelazApp.Services.Interfaces;
using BelazApp.ViewModels;
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
        private readonly IVehicleService _vehicleService;
        public VehicleReportsViewModel viewModel { get; set; }
        public VehicleReports(BasicVehicleInfo vehicle, IVehicleService vehicleService)
        {

            _vehicleService = vehicleService;
            Title = "Отчёты";
            InitializeComponent();
            viewModel = new VehicleReportsViewModel(vehicle, _vehicleService);
            BindingContext = viewModel;

            var listView = new ListView()
            {
                ItemsSource = viewModel.VehicleReport,
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
        //protected override async void OnAppearing()
        //{
        //    await MainPageViewModel.GetVehicles();
        //    base.OnAppearing();
        //}
    }
}