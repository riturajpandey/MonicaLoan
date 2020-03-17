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
                                            await GetProfile();
                                            App.masterDetailPage.Master = new MenuPage();
                                            App.masterDetailPage.Detail = new NavigationPage(new YourLoanBalancePage());
                                            App.Current.MainPage = App.masterDetailPage;
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
        /// TO call Get profile data
        /// </summary>
        /// <returns></returns>
        public async Task GetProfile()
        {
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
                            await _businessCode.ProfileGetApi(new ProfileGetRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,

                            },
                            async (_obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (_obj as ProfileGetResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            Helpers.Constants.UserLoanbalance = requestList.loanbalance;
                                            Helpers.Constants.UserDuebalance = requestList.duesoon;
                                            Helpers.Constants.UserBvn = requestList.bvn;
                                            Helpers.Constants.UserCity = requestList.city;
                                            Helpers.Constants.UserBankname = requestList.bankname;
                                            Helpers.Constants.UserBankcode = requestList.bankcode;
                                            Helpers.Constants.UserAddressline1 = requestList.addressline1;
                                            Helpers.Constants.UserAddressline2 = requestList.addressline2;
                                            Helpers.Constants.UserBankaccountno = requestList.bankaccountno;
                                            Helpers.Constants.UserDateofbirth = requestList.dateofbirth;
                                            Helpers.Constants.UserEmailAddress = requestList.emailaddress;
                                            Helpers.Constants.UserEmployeenumber = requestList.employeenumber;
                                            Helpers.Constants.UserEmployercode = requestList.employercode;
                                            Helpers.Constants.UserEmployername = requestList.employername;
                                            Helpers.Constants.UserFirstname = requestList.firstname;
                                            Helpers.Constants.UserMiddlename = requestList.middlename;
                                            Helpers.Constants.UserLastname = requestList.lastname;
                                            Helpers.Constants.Usermobileno = requestList.mobileno;
                                            Helpers.Constants.Userprofilepic = requestList.profilepic;
                                            Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
                                            Helpers.Constants.UserSalary = requestList.salary;
                                            Helpers.Constants.UserStateName = requestList.statename;
                                            Helpers.Constants.UserStatecode = requestList.statecode;
                                            Helpers.Constants.UserStartdate = requestList.startdate;
                                            Helpers.Constants.Usergender = requestList.gender;

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
