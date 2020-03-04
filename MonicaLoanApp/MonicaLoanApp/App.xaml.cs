using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp
{
    public partial class App : Application
    {
        //TODO : To Declare Global Variables.. 
        public static MasterDetailPage masterDetailPage = new MasterDetailPage();

        public App()
        {
            InitializeComponent();
            
          //  MainPage = new Views.Loans.LoanApplicationForm();
            MainPage = new Views.Loans.LoanPage();

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
