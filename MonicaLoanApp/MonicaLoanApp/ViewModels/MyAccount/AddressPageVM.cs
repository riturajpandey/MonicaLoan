using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class AddressPageVM : BaseViewModel
    {
        #region Constructor
        public AddressPageVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _AddressOne;
        public string AddressOne
        {
            get { return _AddressOne; }
            set
            {
                if (_AddressOne != value)
                {
                    _AddressOne = value;
                    OnPropertyChanged("AddressOne");
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
