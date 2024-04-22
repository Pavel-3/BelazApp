using BelazApp.Models;
using BelazApp.Services.Interfaces;
using BelazApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehilcleParameter : ContentPage
    {
        public DetailedVehicleInfo DetailedVehicleInfo { get; set; }
        public DetailedVehicleInfoViewModel DetailedVehicleInfoViewModel { get; set; }
        private readonly IVehicleService _vehicleService;
        public List<ListView> listViews { get; set; }
        public VehilcleParameter(BasicVehicleInfo vehicle, IVehicleService vehicleService)
        {
            Title = "Телеметрия";
            _vehicleService = vehicleService;
            InitializeComponent();
            DetailedVehicleInfoViewModel = new DetailedVehicleInfoViewModel(vehicle, vehicleService);
            BindingContext = DetailedVehicleInfoViewModel;
            
            TimeLabel.Text = DetailedVehicleInfoViewModel.CurrentDateTime.ToString("MM/dd/yyyy HH:mm");
            listViews = new List<ListView>();
            List<Button> buttons = new List<Button>();
            foreach (var section in DetailedVehicleInfoViewModel.Vehicle.Sections)
            {
                var button = new Button()
                {
                    HeightRequest = 35,
                    Text = section.Key,
                    CornerRadius = 5,
                    BackgroundColor = Color.LightBlue,
                    Margin = 3
                };
                buttons.Add(button);
                button.Clicked += ExpandList;
                var list = new ListView()
                {
                    HasUnevenRows = true,
                    SelectionMode = 0,
                    Margin = 3,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        ParametersViewCell cell = new ParametersViewCell();
                        cell.BindingContext = section.Value;
                        cell.SetBinding(ParametersViewCell.TitleProperty, "Key");
                        cell.SetBinding(ParametersViewCell.ValueProperty, "Value");
                        return cell;
                    })
                };
                list.BindingContext = section;
                //list.SetBinding(ListView.ItemsSourceProperty, new Binding("Parameters"));
                list.ItemTapped += ParameterSelected;
                listViews.Add(list);
                Layout1.Children.Add(button);
                Layout1.Children.Add(list);
            }
        }
        private void ExpandList(object sender, EventArgs args)
        {
            var button = (Button)sender;

        }
        private async void ParameterSelected(object sender, ItemTappedEventArgs e)
        {
            var parameter = (Parameter)e.Item;
            await Navigation.PushAsync(new Chart(parameter));
        }
        protected override async void OnAppearing()
        {
            await DetailedVehicleInfoViewModel.GetDetailedVehicleInfo();
            base.OnAppearing();
        }
    }

}