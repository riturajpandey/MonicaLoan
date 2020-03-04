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
            BackCommand = new Command(OnBackAsync);

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

        public Command BackCommand { get; set; }

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

        #endregion

        #region Methods

        /// <summary>
        /// TODO : To back Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnBackAsync(object obj)
        {
            await Navigation.PopModalAsync();
        }

        #endregion

    }
}
