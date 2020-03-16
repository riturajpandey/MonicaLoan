using Acr.UserDialogs;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakePaymentPage : ContentPage
    {//TODO: To define class level variable
        protected MakePaymentPageVM MakePaymentVM;

        #region Constructor
        public MakePaymentPage()
        {
            InitializeComponent();
            MakePaymentVM = new MakePaymentPageVM(this.Navigation);
            this.BindingContext = MakePaymentVM;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MakePaymentVM.GetLoans();
        }
        #endregion

        #region Methods
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DtPckDOB_Tapped(object sender, EventArgs e)
        //{
        //    DtPckDOB.Focus();
        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        //{
        //    MakePaymentVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        //{
        //    if (DtPckDOB.Date != null)
        //    {
        //        MakePaymentVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        //    }
        //}
        #endregion

        private void PckLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckLoan.SelectedIndex >= 0)
            {
                var loan = PckLoan.SelectedItem as Loan;
                MakePaymentVM.LoanAmount = loan.loanamount; 
                MakePaymentVM.LoanPurpose = PckLoan.Items[PckLoan.SelectedIndex];
                MakePaymentVM.SchedulesList = new ObservableCollection<Schedule>(loan.schedules); 
            }
        }

        private void PckSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckSchedule.SelectedIndex >= 0)
            {
                var schedule = PckSchedule.SelectedItem as Schedule; 
                MakePaymentVM.LoanSchedule = PckSchedule.Items[PckSchedule.SelectedIndex];
            }
        }

        private void PickerSchedule_Tapped(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(MakePaymentVM.LoanPurpose))
            {
                UserDialogs.Instance.Alert("Please select loan.", "Alert", "Ok");   
                return;
            } 
            else
            {
                PckSchedule.Focus();  
            }
           
        }
    }
}