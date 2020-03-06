using MonicaLoanApp.Views.Loans;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Menu
{
    public class MenuPageVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables...  

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPageViewModel"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public MenuPageVM(INavigation nav)
        {
            Navigation = nav;            
            HomeCommand = new Command(OnHomeAsync);
            LoansCommand = new Command(OnLoansAsync);
            PaymentsCommand = new Command(OnPaymentsAsync);
            MyAccountCommand = new Command(OnMyAccountAsync);
            HelpCommand = new Command(OnHelpAsync);
            SignOutCommand = new Command(OnSignOutAsync);
           
        }

        #endregion

        #region DELEGATECOMMAND  

        public Command HomeCommand { get; set; }
        public Command LoansCommand { get; set; }
        public Command PaymentsCommand { get; set; }
        public Command MyAccountCommand { get; set; }
        public Command HelpCommand { get; set; }
        public Command SignOutCommand { get; set; }

        #endregion

        #region PROPERTIES 
        private string _UserName = "Joe Bloggs";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
        private string _UserNumber= "87447197";
        public string UserNumber
        {
            get { return _UserNumber; }
            set
            {
                if (_UserNumber != value)
                {
                    _UserNumber = value;
                    OnPropertyChanged("UserNumber");
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// TODO : To navigate To Home Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnHomeAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new YourLoanBalancePage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform Loan Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnLoansAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new LoanPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform Loan Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPaymentsAsync(object obj)
        {
            //App.masterDetailPage.IsPresented = false;
            //App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new PaymentsPage());
            //App.Current.MainPage = App.masterDetailPage;
            //App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform Account Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnMyAccountAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.MyAccount.MyAccountPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform Help Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnHelpAsync(object obj)
        {
            //App.masterDetailPage.IsPresented = false;
            //App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new HelpPage());
            //App.Current.MainPage = App.masterDetailPage;
            //App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform SignOut Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnSignOutAsync(object obj)
        {
            App.Current.MainPage = new Views.Login.LoginPage();
        }

        #endregion
    }
}
