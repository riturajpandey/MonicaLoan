using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class BankPageVM : BaseViewModel
    {
        #region Constructor
        public BankPageVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _BankAccountNumber;
        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set
            {
                if (_BankAccountNumber != value)
                {
                    _BankAccountNumber = value;
                    OnPropertyChanged("BankAccountNumber");
                }
            }

        }
        private string _EnterBVN;
        public string EnterBVN
        {
            get { return _EnterBVN; }
            set
            {
                if (_EnterBVN != value)
                {
                    _EnterBVN = value;
                    OnPropertyChanged("EnterBVN");
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
