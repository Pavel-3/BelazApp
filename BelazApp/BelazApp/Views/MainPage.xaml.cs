using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelazApp.Models;
using BelazApp.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ViewModels.BelazApp.ViewModels;
using System.Collections.ObjectModel;
using ViewModels;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly IVehicleService _vehicleService;
        public MainViewModel MainPageViewModel { get; set; }
        public ObservableCollection<BasicVehicleInfoViewModel> BasicVehicleInfos { get; set; }
        public MainPage(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;

            Title = "Список ТС";
            InitializeComponent();
            MainPageViewModel = new MainViewModel(vehicleService) { Navigation = this.Navigation };
            this.BindingContext = this;
        }
        protected override async void OnAppearing()
        {
            await MainPageViewModel.GetVehicles();
            BasicVehicleInfos = MainPageViewModel.Vehicles;
            base.OnAppearing();
        }
        private async void VehicleSelected(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (DetailedVehicleInfo)e.Item;
            await Navigation.PushAsync(new SelectedVehicle(vehicle, _vehicleService));
        }
    }
}