using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BelazApp.Views;
using Nancy.TinyIoc;
using BelazApp.Services.Interfaces;
using BelazApp.Services;

namespace BelazApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new VehicleServiceOffline()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
