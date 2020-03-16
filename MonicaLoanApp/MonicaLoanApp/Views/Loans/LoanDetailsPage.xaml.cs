using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
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

        #region Constructor
        public LoanDetailsPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanDetailsVM = new LoanDetailsPageVM(this.Navigation);
            this.BindingContext = LoanDetailsVM;
        }
        #endregion

        /// <summary>
        /// TODO : TO Define OnAppearing Event...
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoanDetailsVM.GetAllLoans();
        }

        #region Methods
        /// <summary>
        /// TODO: To list tapped event open LoanDetail page..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoanDetail_Tapped(object sender, EventArgs e)
        {
            var item = (sender as Grid).BindingContext as AllLoan;    
            if (item != null) 
                await Navigation.PushModalAsync(new Views.Loans.LoanApplicationPage(item));   
        }
        #endregion
    }
}