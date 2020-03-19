using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class AppSettingPageVM : BaseViewModel
    {
        #region Constructor
        public AppSettingPageVM(INavigation nav)
        {
            Navigation = nav;
            BackCommand = new Command(BackCommandAsync);
        }
        #endregion

        #region Properties
        #endregion

        #region Command 
        public Command BackCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// To Define Back Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void BackCommandAsync(object obj)
        {
            App.Current.MainPage = new Views.MyAccount.MyAccountPage();
        }
        #endregion
    }
}
