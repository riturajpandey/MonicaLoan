using MonicaLoanApp.Views.Popup.LoanApplication;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanApplicationFormVM : BaseViewModel
    {
        /// <summary>
        /// TODO: To define class level variable...
        /// </summary>
        protected SubmittedLoanApplicationPopup SubmittedLoanApplicationPopup;

        #region Constructor
        public LoanApplicationFormVM(INavigation nav)
        {
            Navigation = nav;
            Continue = new Command(ContinueCommandAsync);
            BckCommand = new Command(BckCommandAsync);
            SubmitCommand = new Command(SubmitCommandAsync);
        }


        #endregion

        #region Properties
        private string _EnterAmount;
        public string EnterAmount
        {
            get { return _EnterAmount; }
            set
            {
                if (_EnterAmount != value)
                {
                    _EnterAmount = value;
                    OnPropertyChanged("EnterAmount");
                }
            }
        }
        private string _EnterEmployeeNumber;
        public string EnterEmployeeNumber
        {
            get { return _EnterEmployeeNumber; }
            set
            {
                if (_EnterEmployeeNumber != value)
                {
                    _EnterEmployeeNumber = value;
                    OnPropertyChanged("EnterEmployeeNumber");
                }
            }
        }
        private string _EnterSalary;
        public string EnterSalary
        {
            get { return _EnterSalary; }
            set
            {
                if (_EnterSalary != value)
                {
                    _EnterSalary = value;
                    OnPropertyChanged("EnterSalary");
                }
            }
        }
        private string _NumberOfWeek;
        public string NumberOfWeek
        {
            get { return _NumberOfWeek; }
            set
            {
                if (_NumberOfWeek != value)
                {
                    _NumberOfWeek = value;
                    OnPropertyChanged("NumberOfWeek");
                }
            }
        }
        private bool _GridOne = true;
        public bool GridOne
        {
            get { return _GridOne; }
            set
            {
                if (_GridOne != value)
                {
                    _GridOne = value;
                    OnPropertyChanged("GridOne");
                }
            }
        }
        private bool _GridSecond = false;
        public bool GridSecond
        {
            get { return _GridSecond; }
            set
            {
                if (_GridSecond != value)
                {
                    _GridSecond = value;
                    OnPropertyChanged("GridSecond");
                }
            }
        }

        private string _DateOfBirth = "Select Start date";
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if (_DateOfBirth != value)
                {
                    _DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        #endregion

        #region Command
        public Command Continue { get; set; }
        public Command BckCommand { get; set; }
        public Command SubmitCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// TODO: To define continue command for naviagtion to next page.
        /// </summary>
        /// <param name="obj"></param>
        private void ContinueCommandAsync(object obj)
        {
            GridOne = false;
            GridSecond = true;
        }
        /// <summary>
        /// TODO: To define SubmitCommand for naviagtion to next page.
        /// </summary>
        /// <param name="obj"></param>
        private async void SubmitCommandAsync(object obj)
        {
            SubmittedLoanApplicationPopup = new SubmittedLoanApplicationPopup();
            await Navigation.PushPopupAsync(SubmittedLoanApplicationPopup, true);

        }
        /// <summary>
        /// TODO: To define backCommand for hide and show grid .
        /// </summary>
        /// <param name="obj"></param>
        private void BckCommandAsync(object obj)
        {
            if (GridSecond == true)
            {
                GridOne = true;
                GridSecond = false;
            }
            else if (GridOne == true)
            {
                Navigation.PopModalAsync();
            }
        }
        #endregion
    }
}
