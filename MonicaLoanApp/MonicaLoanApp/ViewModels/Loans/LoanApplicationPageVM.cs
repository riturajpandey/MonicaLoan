using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanApplicationPageVM : BaseViewModel
    {
        #region  Constructor
        public LoanApplicationPageVM(INavigation nav)
        {
            Navigation = nav;
           // BackCommand = new Command(OnBackAsync);

            //TODO : Dummy Data in list
            LoanDetailsList = new ObservableCollection<LoanDetailsModel>
            {
                 new LoanDetailsModel{Id="0", Amount="N500,000",Status="Paid",AmtDate="1 Feb 2020"},
                 new LoanDetailsModel{Id="1", Amount="N100,000",Status="Paid",AmtDate="1 Feb 2020"},
                 new LoanDetailsModel{Id="2", Amount="N100,000",Status="Pay",AmtDate="1 Feb 2020"},
                 new LoanDetailsModel{Id="2", Amount="N100,000",Status="Pay",AmtDate="1 Feb 2020"},
            };
        }

        #endregion

        #region DELEGATECOMMAND  
         
        #endregion

        #region Properties

        private ObservableCollection<LoanDetailsModel> _LoanDetailsList;
        public ObservableCollection<LoanDetailsModel> LoanDetailsList
        {
            get { return _LoanDetailsList; }
            set
            {
                if (_LoanDetailsList != value)
                {
                    _LoanDetailsList = value;
                    OnPropertyChanged("LoanDetailsList");
                }
            }
        }
        private string _Status = "Active";
        public string Status
        {
            get { return _Status; }
            set
            {
                if(_Status!= value)
                {
                    _Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private string _Date = "1 Dec 2019";
        public string Date
        {
            get { return _Date; }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        private string _LoanAmount = "N500,000";
        public string LoanAmount
        {
            get { return _LoanAmount; }
            set
            {
                if (_LoanAmount != value)
                {
                    _LoanAmount = value;
                    OnPropertyChanged("LoanAmount");
                }
            }
        }
        private string _LoanBalance = "N200,000";
        public string LoanBalance
        {
            get { return _LoanBalance; }
            set
            {
                if (_LoanBalance != value)
                {
                    _LoanBalance = value;
                    OnPropertyChanged("LoanBalance");
                }
            }
        }
        private string _UserCompany = "Coca Cola Limited";
        public string UserCompany
        {
            get { return _UserCompany; }
            set
            {
                if (_UserCompany != value)
                {
                    _UserCompany = value;
                    OnPropertyChanged("UserCompany");
                }
            }
        }
        private string _UserSalary = "N100,000";
        public string UserSalary
        {
            get { return _UserSalary; }
            set
            {
                if (_UserSalary != value)
                {
                    _UserSalary = value;
                    OnPropertyChanged("UserSalary");
                }
            }
        }
        private string _UserName = "ABC 1234";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        #endregion

        #region Methods

        #endregion

    }
}
