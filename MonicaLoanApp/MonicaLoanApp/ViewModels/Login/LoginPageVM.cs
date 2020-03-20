using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Menu;
using MonicaLoanApp.Views.Popup.LoanApplication;
using Plugin.Connectivity;
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
            PasswordCommand = new Command(PasswordCommandAsync);
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

        private bool _IsPassword = true;
        public bool IsPassword
        {
            get { return _IsPassword; }
            set
            {
                if (_IsPassword != value)
                {
                    _IsPassword = value;
                    OnPropertyChanged("IsPassword");
                }
            }
        }

        private bool _IsPasswordShow = true;
        public bool IsPasswordShow
        {
            get { return _IsPasswordShow; }
            set
            {
                if (_IsPasswordShow != value)
                {
                    _IsPasswordShow = value;
                    OnPropertyChanged("IsPasswordShow");
                }
            }
        }

        private bool _IsPasswordNotShow = false;
        public bool IsPasswordNotShow
        {
            get { return _IsPasswordNotShow; }
            set
            {
                if (_IsPasswordNotShow != value)
                {
                    _IsPasswordNotShow = value;
                    OnPropertyChanged("IsPasswordNotShow");
                }
            }
        }
        #endregion

        #region Commands 
        public Command LoginCommand { get; set; }
        public Command PasswordCommand { get; set; }
        public Command ForgotCommand { get; set; }
        public Command Register { get; set; }
        #endregion

        #region Methods

        private async void PasswordCommandAsync(object obj) 
        {
            if(IsPasswordShow == true)
            {
                IsPasswordShow = false;
                IsPasswordNotShow = true;
                IsPassword = false;
            } 
            else
            {
                IsPasswordNotShow = false;
                IsPasswordShow = true;
                IsPassword = true;
            }
        }

        /// <summary>
        /// TODO: To validate Login Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void LoginAsync(object obj)
        {
            //Apply LoginValidations...
            if (!await Validate()) return;
            //Call api..
            try
            {
                //Call AccessRegister Api..  
                UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.AccessLoginApi(new LoginRequestModel()
                            {

                                emailaddress = Email,
                                password = Password,

                            },
                            async (aobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (aobj as LoginResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            //Helpers.Constants.LoginUserToken = requestList.usertoken;
                                            Helpers.Settings.GeneralAccessToken = requestList.usertoken;
                                            Helpers.Constants.LoginUserSecret = requestList.usersecret;
                                            App.masterDetailPage.Master = new MenuPage();
                                            App.masterDetailPage.Detail = new NavigationPage(new YourLoanBalancePage());
                                            App.Current.MainPage = App.masterDetailPage;
                                            App.masterDetailPage.IsPresented = false;
                                        }
                                        else
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "Alert", "ok");

                                        }

                                    }

                                    UserDialog.HideLoading();
                                });
                            }, (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    UserDialog.HideLoading();
                                    UserDialog.Alert("Something went wrong. Please try again later.", "Alert", "Ok");
                                });
                            });
                        }
                    }).ConfigureAwait(false);
                }
                else
                {
                    UserDialogs.Instance.Loading().Hide();
                    await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "Alert", "Okay");
                }
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }

        }

        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void ForgotPasswordAsync(object obj)
        {
            if (Helpers.Constants.PageCount == 0)
            {
                Helpers.Constants.PageCount++;
                await Navigation.PushModalAsync(new Views.ResetPassword.ResetEmailPage());
            }
                
        }
        // 
        /// <summary>
        /// TODO: To validate Register Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void RegisterAsync(object obj)
        {
            if (Helpers.Constants.PageCount == 0)
            {
                Helpers.Constants.PageCount++;
                await Navigation.PushModalAsync(new Views.Register.Register_One());
            }
                
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
            if (Email.Length<= 5 && Email.Length>=100)
            {
                UserDialog.Alert("Email should contain at least 5 charcter.");
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                UserDialog.Alert("Please enter your password.");
                return false;
            }
            if (Password.Length <= 6 && Password.Length >= 50)
            {
                UserDialog.Alert("Password should contain at least 6 charcter.");
                return false;
            }
            return true;
        }
        #endregion

    }
}
