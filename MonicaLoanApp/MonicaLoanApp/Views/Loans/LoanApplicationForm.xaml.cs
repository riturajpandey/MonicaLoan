using MonicaLoanApp.Models;
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
            PckEmployee.Focus();
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
            try
            {
                if (DtPckDOB.Date != null)
                {
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    LoanApplication_Form.DateOfBirth = DateBirth;
                }

            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (DtPckDOB.Date != null)
                {
                    // RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("MM/dd/yyyy");
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    LoanApplication_Form.DateOfBirth = DateBirth;
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        private void Purpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckPurpose.SelectedIndex >= 0)
            {
                var purposecode = PckPurpose.SelectedItem as Staticdata;
                LoanApplication_Form.PurposeCode = purposecode.key;
            }

        }

        private void Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckEmployee.SelectedIndex >= 0)
            {
                var EmployerCode = PckEmployee.SelectedItem as Staticdata;
                LoanApplication_Form.EmployerCode = EmployerCode.key;
            }
        }

        private void pckWeeks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckWeeks.SelectedIndex >= 0)
            {
                LoanApplication_Form.LoanDuration = pckWeeks.Items[pckWeeks.SelectedIndex];
            }
        }

        private void GrdSelectPurpose_Tapped(object sender, EventArgs e)
        {
            PckPurpose.Focus();
        }
    }
}