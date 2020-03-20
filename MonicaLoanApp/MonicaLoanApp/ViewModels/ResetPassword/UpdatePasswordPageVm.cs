using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.ResetPassword
{
    public class UpdatePasswordPageVm : BaseViewModel
    { 
        public string Email;
        #region Constructor
        public UpdatePasswordPageVm(INavigation nav, string _Email)
        {
            Navigation = nav;
            NewPasswordCommand = new Command(NewPasswordCommandAsync);
            Email = _Email;
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
                            await _businessCode.AccessPasswordChangeApi(new AccessPasswordChangeRequestModel()
                            {

                                validatetoken = Token,
                                password = NewPassword,
                                emailaddress = Email,
                            },
                            async (aobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (aobj as AccessPasswordChangeResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "Alert", "ok");
                                            App.Current.MainPage = new Views.Login.LoginPage(Email);
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
                            }) ;
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
            // UserDialog.Alert("Password reset successfully.!", "Alert", "Ok");
            //
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
