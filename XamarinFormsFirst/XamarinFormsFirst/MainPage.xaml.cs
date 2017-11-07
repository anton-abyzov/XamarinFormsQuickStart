﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsFirst.Model;
using XamarinFormsFirst.ViewModel;

namespace XamarinFormsFirst
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return; // catch deselection
            var person = e.SelectedItem as Person;
            DisplayAlert("Selected Person", person.Name, "OK");
        }
    }
}