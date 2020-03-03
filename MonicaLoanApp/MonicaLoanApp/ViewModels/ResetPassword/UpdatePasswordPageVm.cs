using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.ResetPassword
{
    public class UpdatePasswordPageVM : BaseViewModel
    {
        #region Constructor
        public UpdatePasswordPageVM(INavigation nav)
        {
            Navigation = nav;
            NewPasswordCommand = new Command(NewPasswordCommandAsync);
        }
        #endregion

        #region Properties
        private string _Token;
        public string Token
        {
            get { return _Token; }
            set
            {
                if (_Token != value)
                {
                    _Token = value;
                    OnPropertyChanged("Token");
                }
            }
        }

        private string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set
            {
                if (_NewPassword != value)
                {
                    _NewPassword = value;
                    OnPropertyChanged("NewPassword");
                }
            }
        }
        #endregion

        #region Commands 
        public Command NewPasswordCommand { get; set; }

        #endregion

        #region Methods
        /// <summary>
        ///  TODO : To Validate NewPasswordCommand...
        /// </summary>
        /// <param name="obj"></param>
        private async void NewPasswordCommandAsync(object obj)
        {
            if (!await Validate()) ;
        }

        /// <summary>
        /// TODO : To Validate reset password Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Token))
            {
                UserDialog.Alert("Please enter Token.");
                return false;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                UserDialog.Alert("Please enter new password.");
                return false;
            }
            return true;
        }
        #endregion

    }
}
