using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Payments
{
    public class MakePaymentPageVM : BaseViewModel
    {
        #region Constructor
        public MakePaymentPageVM(INavigation nav)
        {
            Navigation = nav;
            PaymentCommand = new Command(PaymentCommandAsync);
        }
        #endregion

        #region Properties
        private string _DateOfBirth = "Select schedule";
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
        private string _Amount;
        public string Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount != value)
                {
                    _Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        #endregion

        #region Commands
        public Command PaymentCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// TODO: To define Payment Complete Command...
        /// </summary>
        /// <param name="obj"></param>
        private void PaymentCommandAsync(object obj)
        {
            UserDialog.Alert("Payment Complete successfully.!", "Success", "Ok");
            App.Current.MainPage = new Views.Payments.PaymentListPage();
        }
        #endregion

    }
}
