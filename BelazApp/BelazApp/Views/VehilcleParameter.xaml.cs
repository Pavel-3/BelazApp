using BelazApp.Models;
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
        public int VehicleId { get; set; }
        public DateTime dateTime { get; set; }
        public List<ListView> listViews { get; set; }
        public TimeUnit timeUnit { get; set; }
        public Vehicle vehicle { get; set; }
        public VehilcleParameter(int vehicleId)
        {
            Title = "Телеметрия";
            InitializeComponent();
            dateTime = DateTime.Now;
            vehicle = Data.GetVehicles(dateTime.Minute).FirstOrDefault(x => x.Id == vehicleId);
            TimeLabel.Text = dateTime.ToString("MM/dd/yyyy HH:mm");
            listViews = new List<ListView>();
            List<Button> buttons = new List<Button>();
            foreach (var section in vehicle.Sections)
            {
                var button = new Button()
                {
                    HeightRequest = 35,
                    Text = section.Name,
                    CornerRadius = 5,
                    BackgroundColor = Color.LightBlue,
                    Margin = 3
                };
                buttons.Add(button);
                button.Clicked += ExpandList;
                var list = new ListView()
                {
                    //ItemsSource = section.Parameters,

                    HasUnevenRows = true,
                    SelectionMode = 0,
                    Margin = 3,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        ParametersViewCell cell = new ParametersViewCell();

                        cell.SetBinding(ParametersViewCell.TitleProperty, "ParameterName");
                        cell.SetBinding(ParametersViewCell.ValueProperty, new Binding("ParameterValue"));
                        return cell;
                    })
                };
                list.BindingContext = section;
                list.SetBinding(ListView.ItemsSourceProperty, new Binding("Parameters"));
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
        private void TimeBack(object sender, EventArgs args)
        {
            var unit = timeUnit;
            if (unit == TimeUnit.Minute)
            {
                dateTime = dateTime - new TimeSpan(0, 1, 0);
                TimeLabel.Text = dateTime.ToString("MM/dd/yyyy HH:mm");
                foreach (Section section in vehicle.Sections)
                {
                    foreach (Parameter parameter in section.Parameters)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            parameter.ParameterValue += 3;
                        });
                    }
                }
            }
            else
            {
                dateTime = dateTime - new TimeSpan(1, 0, 0);
                TimeLabel.Text = dateTime.ToString("MM/dd/yyyy HH:mm");
                foreach (Section section in vehicle.Sections)
                {
                    foreach (Parameter parameter in section.Parameters)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            parameter.ParameterValue += 5;
                        });

                    }
                }
            }
        }
        private void TimeForward(object sender, EventArgs args)
        {

            var unit = timeUnit;
            if (unit == TimeUnit.Minute)
            {
                dateTime = dateTime + new TimeSpan(0, 1, 0);
                if (dateTime >= DateTime.Now)
                    return;
                TimeLabel.Text = dateTime.ToString("MM/dd/yyyy HH:mm");
                foreach (Section section in vehicle.Sections)
                {
                    foreach (Parameter parameter in section.Parameters)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            parameter.ParameterValue -= 3;
                        });

                    }
                }
            }
            else
            {
                dateTime = dateTime + new TimeSpan(1, 0, 0);
                if (dateTime >= DateTime.Now)
                    return;
                TimeLabel.Text = dateTime.ToString("MM/dd/yyyy HH:mm");
                foreach (Section section in vehicle.Sections)
                {
                    foreach (Parameter parameter in section.Parameters)
                    {
                        Device.BeginInvokeOnMainThread(() => { parameter.ParameterValue -= 5; });
                    }
                }
            }
        }
        private void PickUnit(object sender, EventArgs args)
        {
            var string1 = Picker1.Items[Picker1.SelectedIndex];
            if (string1 == "Минуты")
                timeUnit = TimeUnit.Minute;
            else
                timeUnit = TimeUnit.Hour;
        }
        private async void ParameterSelected(object sender, ItemTappedEventArgs e)
        {
            var parameter = (Parameter)e.Item;
            await Navigation.PushAsync(new Chart(parameter));
        }
        public enum TimeUnit
        {
            Minute,
            Hour
        }
    }
}