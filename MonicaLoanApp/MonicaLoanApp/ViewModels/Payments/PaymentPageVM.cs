using MonicaLoanApp.Models.Payments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Payments
{
    public class PaymentPageVM : BaseViewModel
    {
        #region Constructor
        public PaymentPageVM(INavigation nav)
        {
            Navigation = nav;
            PlusCommand = new Command(PlusCommandAsync);
            PaymentList = new ObservableCollection<PaymentsListModel>
            {
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
                new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            };
        }

       
        #endregion

        #region Properties
        private string _PaymentStatus= "No Payments Currently";
        public string PaymentStatus
        {
            get { return _PaymentStatus; }
            set
            {
                if(_PaymentStatus!= value)
                {
                    _PaymentStatus = value;
                    OnPropertyChanged("PaymentStatus");
                }
            }
        }
        private ObservableCollection<PaymentsListModel>_PaymentList;
        public ObservableCollection<PaymentsListModel> PaymentList
        {
            get { return _PaymentList; }
            set
            {
                if(_PaymentList!= value)
                {
                    _PaymentList = value;
                    OnPropertyChanged("PaymentList");
                }
            }
        }
        #endregion

        #region Commands
        public Command PlusCommand { get; set; }
        #endregion

        #region Methods
        private void PlusCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.Payments.PaymentListPage());
        }
        #endregion
    }
}
