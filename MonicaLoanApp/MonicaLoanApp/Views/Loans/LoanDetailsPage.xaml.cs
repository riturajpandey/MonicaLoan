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
    public partial class LoanDetailsPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected LoanDetailsPageVM LoanDetailsVM;
        public LoanDetailsPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanDetailsVM = new LoanDetailsPageVM(this.Navigation);
            this.BindingContext = LoanDetailsVM;
        }

        /// <summary>
        /// TODO: To list tapped event open LoanDetail page..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoanDetail_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Loans.LoanApplicationPage());
        }
    }
}