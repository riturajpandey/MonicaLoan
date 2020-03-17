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
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            YourLoanBalancePagevm = new YourLoanBalancePageVM(this.Navigation);
            BindingContext = YourLoanBalancePagevm;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await YourLoanBalancePagevm.GetProfile();
            YourLoanBalancePagevm.LoanAmount = Helpers.Constants.UserLoanbalance;
            YourLoanBalancePagevm.DueAmount = Helpers.Constants.UserDuebalance;
        }
        #endregion
    }
}