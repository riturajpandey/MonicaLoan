using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class EmployementPageVM : BaseViewModel
    {
        #region Constructor
        public EmployementPageVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _DateOfBirth = "Date of Birth";
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
        private string _EnterEmpNo;
        public string EnterEmpNo
        {
            get { return _EnterEmpNo; }
            set
            {
                if (_EnterEmpNo != value)
                {
                    _EnterEmpNo = value;
                    OnPropertyChanged("EnterEmpNo");
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
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}