using MonicaLoanApp.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourLoanBalancePage : ContentPage
    {
        //Define Properties Here...
        protected YourLoanBalancePageVM YourLoanBalancePageVM;
        public YourLoanBalancePage()
        {
            InitializeComponent();
            YourLoanBalancePageVM = new YourLoanBalancePageVM(this.Navigation);
            BindingContext = YourLoanBalancePageVM;
        }
    }
}