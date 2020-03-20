using Acr.UserDialogs;
using MonicaLoanApp.Helpers;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Register
{
    public class ConfirmRegistrationVM : BaseViewModel
    {
        public string Email;

        #region Constructor
        public ConfirmRegistrationVM(INavigation nav, string email)
        {
            Navigation = nav;
            Email = email;
            FinishCommand = new Command(FinishCommandAsync);
            BckCommand = new Command(BckCommandAsync);
        }
        //For cancel user registration varification...
        private async void BckCommandAsync(object obj)
        {
            var res = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to cancel registration varification", null, "No", "Yes");
            var text = (res ? "No" : "Yes");
            if (text == "Yes")
            App.Current.MainPage = new Views.Login.LoginPage(null);
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
        private async void FinishCommandAsync(object obj)
        {
            if (!await Validate()) return;

            //Call api..
            try
            {
                //Call AccessRegisterActivate Api..  
                UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.AccessRegisterActivateApi(new AccessRegisterActivateRequestModel()
                            {
                                usertoken = Constants.UserToken,
                                validatetoken = RegisterToken
                            },
                            async (aobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (aobj as AccessRegisterActivateResponseModel);

                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            UserDialog.Alert("Congratulations! You are registered successfully.!", "Success", "Ok");
                                            App.Current.MainPage = new Views.Login.LoginPage(Email);
                                        }
                                        else
                                        {
                                             UserDialogs.Instance.Alert(requestList.responsemessage, "Alert", "OK");
                                            // await App.Current.MainPage.DisplayAlert("Alert", requestList.responsemessage, "Ok");
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
        #endregion
    }
}
