using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.ResetPassword
{
    public class EmailResetPageVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables..
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        
        #region Constructor
        // <summary>
        /// Initializes a new instance of the <see cref="EmailResetPageVM"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public EmailResetPageVM(INavigation nav)
        {
            Navigation = nav;
            SubmitCommand = new Command(SubmitCommandAsync);
        }
        #endregion

        #region Properties
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        #endregion

        #region Commands 
        public Command SubmitCommand { get; set; }

        #endregion

        #region Methods
        //Submit Command
        private async void SubmitCommandAsync(object obj)
        {
            if (!await Validate()) return;
            //await Navigation.PushModalAsync(new Views);
        }

        /// <summary>
        /// TODO : To Validate reset password Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Email))
            {
                UserDialog.Alert("Please enter your email address.");
                return false;
            }
            bool isValid3 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid3)
            {
                UserDialogs.Instance.Alert("Invalid email", "Alert", "Ok");
                return false;
            }
            return true;
        }
        #endregion
    }
}
