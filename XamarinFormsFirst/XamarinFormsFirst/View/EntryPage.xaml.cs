using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsFirst.ViewModel;

namespace XamarinFormsFirst.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        private readonly EntryPageViewModel _entryPageViewModel;

        public EntryPage()
        {
            InitializeComponent();
            _entryPageViewModel = new EntryPageViewModel();
            BindingContext = _entryPageViewModel;

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                DisplayAlert("Connect changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
            };
        }

        private void AddEntry(object sender, EventArgs e)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;
            DisplayAlert("Connected?", $"We are connected to internet: {isConnected}", "OK");
            _entryPageViewModel.AddToPeople();
            Navigation.PushAsync(new MainPage());
        }
    }
}