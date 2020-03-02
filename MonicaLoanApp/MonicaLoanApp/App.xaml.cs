using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Login.LoginPage();
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
