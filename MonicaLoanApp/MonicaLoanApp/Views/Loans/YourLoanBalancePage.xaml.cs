using Acr.UserDialogs;
using MonicaLoanApp.Interfaces;
using MonicaLoanApp.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourLoanBalancePage : ContentPage
    {
        //Define Properties Here...
        protected YourLoanBalancePageVM YourLoanBalancePagevm;

        #region Constructor
        public YourLoanBalancePage()
        {
            try
            {
                InitializeComponent();
                // iOS Platform
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
                YourLoanBalancePagevm = new YourLoanBalancePageVM(this.Navigation);
                BindingContext = YourLoanBalancePagevm;
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            YourLoanBalancePagevm.TapCount1 = 0;
            YourLoanBalancePagevm.TapCount2 = 0;
            YourLoanBalancePagevm.TapCount3 = 0;
            Helpers.Constants.PageCount = 0;
            await YourLoanBalancePagevm.GetProfile();
            //YourLoanBalancePagevm.LoanAmount = "N"+ Helpers.Constants.UserLoanbalance;
            //YourLoanBalancePagevm.DueAmount = "N"+ Helpers.Constants.UserDuebalance;
            var LoanAmount = String.Format("{0:n0}", Convert.ToInt32(Helpers.Constants.UserLoanbalance));
            var DueAmount = String.Format("{0:n0}", Convert.ToInt32(Helpers.Constants.UserDuebalance));
            YourLoanBalancePagevm.LoanAmount = "N" + LoanAmount;
            YourLoanBalancePagevm.DueAmount = "N" + DueAmount;
        }

        //TODO : To Define Device Back Button Tapped Event...
        protected override bool OnBackButtonPressed()
        {
            CloseApp();
            return true;
        }

        //TODO : To Define Close App Event...
        public async void CloseApp()
        {
            var res = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to exit the app?", null, "No", "Yes");
            var text = (res ? "No" : "Yes");
            if (text == "Yes")
            {
                DependencyService.Get<ICloseAppService>().CloseApp();
            }
        }
        #endregion 
    }
}