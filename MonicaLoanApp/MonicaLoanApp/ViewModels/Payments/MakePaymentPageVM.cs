using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ObservableCollection<Staticdata> _SelectLoan;
        public ObservableCollection<Staticdata> SelectLoan
        {
            get { return _SelectLoan; }
            set
            {
                if (_SelectLoan != value)
                {
                    _SelectLoan = value;
                    OnPropertyChanged("SelectLoan");
                }
            }
        }

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

        /// <summary>
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            //Fileter Bank List From Static Data List..
            try
            {
                var EmployerList = Helpers.Constants.StaticDataList.Where(a => a.type == "EMPLOYER").ToList();
                SelectLoan = new ObservableCollection<Staticdata>(EmployerList);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion

    }
}
