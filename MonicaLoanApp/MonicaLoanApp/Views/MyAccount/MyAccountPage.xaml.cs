using MonicaLoanApp.ViewModels.MyAccount;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        protected MyAccountPageVM MyAccountVM;
        #region Constructor
        public MyAccountPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            MyAccountVM = new MyAccountPageVM(this.Navigation);
            this.BindingContext = MyAccountVM;
        }
        #endregion
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MyAccountVM.TapCount = 0; 
            MyAccountVM.TapCount1 = 0; 
            MyAccountVM.TapCount2 = 0; 
            MyAccountVM.TapCount3 = 0; 
            MyAccountVM.TapCount4 = 0; 
            MyAccountVM.IsPageEnable = true; 
            MyAccountVM.PersonalDetails = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            MyAccountVM.Address = Helpers.Constants.UserAddressline1;

            if(!string.IsNullOrEmpty(Helpers.Constants.UserAddressline1))
                MyAccountVM.Address = MyAccountVM.Address + ", " + Helpers.Constants.UserAddressline2 + " " + Helpers.Constants.UserCity;
            MyAccountVM.Employement = Helpers.Constants.UserEmployername;
            MyAccountVM.BankDetails = Helpers.Constants.UserBankname + " " + Helpers.Constants.UserBankaccountno;
        }

        //TODO : To Define Device Back Button Tapped Event...
        protected override bool OnBackButtonPressed()
        {
            App.masterDetailPage.Master = new MenuPage();
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new YourLoanBalancePage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
            return true;
        }
    }
}