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
    public partial class LoanApplicationPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected LoanApplicationPageVM LoanApplicationVM;
        public LoanApplicationPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanApplicationVM = new LoanApplicationPageVM(this.Navigation);
            this.BindingContext = LoanApplicationVM;
        }
    }
}