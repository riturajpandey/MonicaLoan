using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanPageVM : BaseViewModel
    {

        #region  Constructor
        public LoanPageVM(INavigation nav)
        {
            Navigation = nav;
            MenuCommands = new Command(OnMenuAsync);
            PlusCommand = new Command(OnPlusAsync);
        }
        #endregion

        #region DELEGATECOMMAND  

        public Command MenuCommands { get; set; }
        public Command PlusCommand { get; set; }


        #endregion
 
        #region Properties

        #endregion

        #region Methods
        /// <summary>
        /// TODO : To Open Menu Page...
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuAsync(object obj)
        {
            App.masterDetailPage.IsPresented = true;
        }

        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPlusAsync(object obj)
        {
            await Navigation.PushModalAsync(new Views.Loans.LoanDetailsPage());
        }

        #endregion
    }
}
