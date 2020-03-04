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
        }
        #endregion
        #region Properties
        private string _DateOfBirth = "Weeks";
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
    }
}
