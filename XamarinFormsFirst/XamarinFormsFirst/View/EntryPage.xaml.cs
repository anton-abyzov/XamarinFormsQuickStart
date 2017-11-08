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
        }

        private void AddEntry(object sender, EventArgs e)
        {
            _entryPageViewModel.AddToPeople();
            Navigation.PushAsync(new MainPage());
        }
    }
}