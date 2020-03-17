using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class YourLoanBalancePageVM : BaseViewModel
    {
        #region  Constructor
        public YourLoanBalancePageVM(INavigation nav)
        {
            Navigation = nav;
            PlusCommand = new Command(PlusCommandAsync);
            ListCommand = new Command(ListCommandAsync);
           
        }
        #endregion

        #region Commands  
        public Command PlusCommand { get; set; }
        public Command ListCommand { get; set; }
        #endregion

        #region Properties
        private string _LoanAmount;
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
        private string _DueAmount;
        public string DueAmount
        {
            get { return _DueAmount; }
            set
            {
                if (_DueAmount != value)
                {
                    _DueAmount = value;
                    OnPropertyChanged("DueAmount");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void ListCommandAsync(object obj)
        {
            
        }
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void PlusCommandAsync(object obj)
        {
            
        }
       
        #endregion
    }
}
