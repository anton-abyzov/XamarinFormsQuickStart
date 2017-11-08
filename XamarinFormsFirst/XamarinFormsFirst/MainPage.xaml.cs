using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsFirst.Data;
using XamarinFormsFirst.Model;
using XamarinFormsFirst.View;
using XamarinFormsFirst.ViewModel;

namespace XamarinFormsFirst
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            _vm = new MainPageViewModel();
            BindingContext = _vm;
            MessagingCenter.Subscribe<MainPageViewModel>(new MainPageViewModel(), "ButtonClicked", (sender) =>
            {
                DisplayAlert("Message", "Button Clicked!", "OK");
            });
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //        return; // catch deselection
        //    var person = e.SelectedItem as Person;
        //    DisplayAlert("Selected Person", person.Name, "OK");
        //}
        private void HandleBackButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryPage());
        }

        public void OnStore(object o, EventArgs e)
        {
            var repo = new PersonRepository();
            repo.Save(_vm.People);
        }

        public void OnRestore(object o, EventArgs e)
        {
            var repo = new PersonRepository();
            var people = repo.GetAll();
            foreach (var person in people)
            {
                _vm.People.Add(person);
            }
        }
    }
}
