using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanDetailsPageVM : BaseViewModel
    {
        #region  Constructor

        public LoanDetailsPageVM(INavigation nav)
        {
            Navigation = nav;
            MenuCommand = new Command(OnMenuAsync);           
            PlusCommand = new Command(OnPlusAsync);
             
            //TODO : Dummy Data in list
            LoanDetailsList = new ObservableCollection<LoanDetailsModel>
            {
                 new LoanDetailsModel{Id="0", Amount="N500,000",Status="Pending approval",AmtDate="1 Feb 2020" ,},
                 new LoanDetailsModel{Id="1", Amount="N100,000",Status="Close",AmtDate="1 Feb 2020", },
                 new LoanDetailsModel{Id="2", Amount="N100,000",Status="Close",AmtDate="1 Feb 2020", },
                 new LoanDetailsModel{Id="2", Amount="N100,000",Status="Close",AmtDate="1 Feb 2020", },
            };
        }
      
        #endregion

        #region DELEGATECOMMAND  

        public Command MenuCommand { get; set; }     
        public Command PlusCommand { get; set; }

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
        private async void OnMenuAsync(object obj)
        {
            await Navigation.PopModalAsync();
        }
       
        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPlusAsync(object obj)
        {
            await Navigation.PushModalAsync(new Views.Loans.LoanApplicationForm());
        }

        #endregion
    }
}
