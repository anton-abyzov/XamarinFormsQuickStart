using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Xamarin.Forms;
using XamarinFormsFirst.Data;
using XamarinFormsFirst.View;

namespace XamarinFormsFirst
{
    public partial class App : Application
    {
        private static PersonDatabase database;

        public static PersonDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PersonDatabase(DependencyService.Get<IFileHelper>()
                        .GetLocalFilePath("PersonSQLite.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EntryPage());
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
