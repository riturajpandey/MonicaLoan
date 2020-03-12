using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Register
{
    public class ConfirmRegistrationVM: BaseViewModel
    {
        #region Constructor
        public ConfirmRegistrationVM(INavigation nav)
        {
            Navigation = nav;
           
            FinishCommand = new Command(FinishCommandAsync);
            BckCommand = new Command(BckCommandAsync);
        }

        private void BckCommandAsync(object obj)
        {
            UserDialog.Alert(" Registration varification failed.", "Failed", "Ok");
            App.Current.MainPage = new Views.Login.LoginPage();
        }

        private async void FinishCommandAsync(object obj)
        {
            if (!await Validate()) return;
            UserDialog.Alert("Congratulations! You are registered successfully.!", "Success", "Ok");
            App.Current.MainPage = new Views.Login.LoginPage();
        }
        #endregion

        #region Properties
        private string _RegisterToken;
        public string RegisterToken
        {
            get { return _RegisterToken; }
            set
            {
                if (_RegisterToken != value)
                {
                    _RegisterToken = value;
                    OnPropertyChanged("RegisterToken");
                }
            }
        }
        #endregion

        #region Commands 
        public Command FinishCommand { get; set; }
        public Command BckCommand { get; set; }

        #endregion
        #region Methods

        /// <summary>
        /// TODO : To Validate reset password Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(RegisterToken))
            {
                UserDialog.Alert("Please enter your token.");
                return false;
            }
           
            return true;
        }
        #endregion
    }
}
