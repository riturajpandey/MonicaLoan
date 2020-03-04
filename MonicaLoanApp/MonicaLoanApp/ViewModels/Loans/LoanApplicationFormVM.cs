using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanApplicationFormVM :BaseViewModel
    {
        #region Constructor
        public LoanApplicationFormVM(INavigation nav)
        {
            Navigation = nav;
            Continue = new Command(ContinueCommandAsync);
            BckCommand = new Command(BckCommandAsync);
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
        private bool _GridOne= true;
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
        #endregion

        #region Method
        private void ContinueCommandAsync(object obj)
        {
            GridOne = false;
            GridSecond = true;
        }
        private void BckCommandAsync(object obj)
        {
            if (GridSecond == true)
            {
                GridOne = true;
                GridSecond = false;
            }else if (GridOne == true)
            {
                Navigation.PopModalAsync();
            }
        }
        #endregion
    }
}
