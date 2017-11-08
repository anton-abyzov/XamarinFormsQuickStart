using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Customization
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            theButton.Effects.Add(new ButtonGradientEffect());
        }

        private void theSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Color gradientColor = new Color(
           e.NewValue / 255.0, e.NewValue / 255.0, e.NewValue / 255.0);
            ButtonGradientEffect.SetGradientColor(theButton, gradientColor);
        }
    }
}
