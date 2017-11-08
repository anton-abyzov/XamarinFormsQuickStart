using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinI8n
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLanguage : ContentPage
    {
        public SelectLanguage()
        {
            InitializeComponent();
        }

        private void OnSpanish(object sender, EventArgs e)
        {
            SwitchLang("es-MX");
        }

        private void SwitchLang(string code)
        {
            var cultureInfo = new CultureInfo(code);
            ((App)Application.Current).Culture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            AppResources.Culture = cultureInfo;
            Navigation.PushAsync(new MainPage());
        }

        private void OnEnglish(object sender, EventArgs e)
        {
            SwitchLang("en-US");
        }
    }
}