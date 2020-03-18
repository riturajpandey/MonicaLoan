﻿using Acr.UserDialogs;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
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
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            MakePaymentVM = new MakePaymentPageVM(this.Navigation);
            this.BindingContext = MakePaymentVM;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MakePaymentVM.GetAllLoans();
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

        private async void PckLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckLoan.SelectedIndex >= 0)
            {
                var loan = PckLoan.SelectedItem as AllLoan; 
                MakePaymentVM.LoanNumber = loan.loannumber; 
                MakePaymentVM.LoanAmount = loan.loanamount; 
                MakePaymentVM.LoanPurpose = PckLoan.Items[PckLoan.SelectedIndex];
                await MakePaymentVM.GetLoans();
                //MakePaymentVM.SchedulesList = new ObservableCollection<Schedule>(loan.schedules); 
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