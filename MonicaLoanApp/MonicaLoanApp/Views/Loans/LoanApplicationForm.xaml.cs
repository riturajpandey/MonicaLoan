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
    public partial class LoanApplicationForm : ContentPage
    {
        //TODO: To define class level variable
        protected LoanApplicationFormVM LoanApplication_Form;

        #region Constructor
        public LoanApplicationForm()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanApplication_Form = new LoanApplicationFormVM(this.Navigation);
            this.BindingContext = LoanApplication_Form;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoanApplication_Form.StaticDataSearch();
        }
        #endregion

        #region Methods
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtPckDOB_Tapped(object sender, EventArgs e)
        {
            DtPckDOB.Focus();
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        {
            LoanApplication_Form.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        {
            if (DtPckDOB.Date != null)
            {
                LoanApplication_Form.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

            }
        }
        #endregion

    }
}