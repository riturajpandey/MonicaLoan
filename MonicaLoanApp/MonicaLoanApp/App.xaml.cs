using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp
{
    public partial class App : Application
    {
        //TODO : To Declare Global Variables.. 
        public static MasterDetailPage masterDetailPage = new MasterDetailPage();
        //TODO : To Define Global Varialbes Here....
        private static Autofac.IContainer _container;
        public App()
        {
            InitializeComponent();
            //To initialize Containers..
            AppSetup appSetup = new AppSetup();
            _container = appSetup.CreateContainer();
            //  MainPage = new Views.Loans.LoanApplicationForm();
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
