using Acr.UserDialogs;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Menu;
using MonicaLoanApp.Views.Popup.LoanApplication;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels
{
    public class LoginPageVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables..
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        protected SubmittedLoanApplicationPopup SubmittedLoanApplicationPopup;

        #region  Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageVM"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public LoginPageVM(INavigation nav)
        {
            Navigation = nav;
            LoginCommand = new Command(LoginAsync);
            ForgotCommand = new Command(ForgotPasswordAsync);
            Register = new Command(RegisterAsync);
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
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        #endregion                                                                                      
                                                                                                                                                                                                                                                                                                
        #region Commands 
        public Command LoginCommand { get; set; }
        public Command ForgotCommand { get; set; }
        public Command Register { get; set; }
        #endregion

        #region Methods

        //
        /// <summary>
        /// TODO: To validate Login Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void LoginAsync(object obj)
        {
            //Apply LoginValidations...
               if (!await Validate()) return;

            //To Set The First Page...
            App.masterDetailPage.Master = new MenuPage();
            App.masterDetailPage.Detail = new NavigationPage(new YourLoanBalancePage());
            App.Current.MainPage = App.masterDetailPage;

            //SubmittedLoanApplicationPopup = new SubmittedLoanApplicationPopup();
            //await Navigation.PushPopupAsync(SubmittedLoanApplicationPopup, true);
        }
        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void ForgotPasswordAsync(object obj)
        {
            await Navigation.PushModalAsync(new Views.ResetPassword.ResetEmailPage());
        }
        // 
        /// <summary>
        /// TODO: To validate Register Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void RegisterAsync(object obj)
        {
            await Navigation.PushModalAsync(new Views.Register.Register_One());
        }
        /// <summary>
        /// TODO : To Validate User Login Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Email))
            {
                UserDialog.Alert("Please enter your email.");
                return false;
            }
            bool isValid3 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid3)
            {
                UserDialogs.Instance.Alert("Please enter valid email", "Alert", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                UserDialog.Alert("Please enter your password.");
                return false;
            }

            return true;
        }
        #endregion

    }
}
