using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinI8n
{
    public partial class App : Application
    {
        public CultureInfo Culture { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new XamarinI8n.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
