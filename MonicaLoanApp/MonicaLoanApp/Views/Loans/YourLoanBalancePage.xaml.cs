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
        protected YourLoanBalancePageVM YourLoanBalancePageVM;

        #region Constructor
        public YourLoanBalancePage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            YourLoanBalancePageVM = new YourLoanBalancePageVM(this.Navigation);
            BindingContext = YourLoanBalancePageVM;
        }
        #endregion
    }
}