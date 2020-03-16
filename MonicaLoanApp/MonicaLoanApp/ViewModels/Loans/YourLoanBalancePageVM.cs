using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class YourLoanBalancePageVM : BaseViewModel
    {
        #region  Constructor
        public YourLoanBalancePageVM(INavigation nav)
        {
            Navigation = nav;
            PlusCommand = new Command(PlusCommandAsync);
            ListCommand = new Command(ListCommandAsync);
        }
        #endregion

        #region Commands  
        public Command PlusCommand { get; set; }
        public Command ListCommand { get; set; }
        #endregion

        #region Properties
        private string _LoanAmount= "N500,000.00";
        public string LoanAmount
        {
            get { return _LoanAmount; }
            set
            {
                if (_LoanAmount != value)
                {
                    _LoanAmount = value;
                    OnPropertyChanged("LoanAmount");
                }
            }
        }
        private string _DueAmount= "N8,250,500.00";
        public string DueAmount
        {
            get { return _DueAmount; }
            set
            {
                if (_DueAmount != value)
                {
                    _DueAmount = value;
                    OnPropertyChanged("DueAmount");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void ListCommandAsync(object obj)
        {
            
        }
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void PlusCommandAsync(object obj)
        {
            
        }
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
                                            Helpers.Settings.UserLoanBalance = requestList.loanbalance;
                                            Helpers.Settings.UserDueBalance = requestList.duesoon;
                                            Helpers.Settings.UserBvn = requestList.bvn;
                                            Helpers.Settings.UserCity = requestList.city;
                                            Helpers.Settings.UserBankname = requestList.bankname;
                                            Helpers.Settings.UserBankcode = requestList.bankcode;
                                            Helpers.Settings.UserAddressline1 = requestList.addressline1;
                                            Helpers.Settings.UserAddressline2 = requestList.addressline2;
                                            Helpers.Settings.UserBankaccountno = requestList.bankaccountno;
                                            Helpers.Settings.UserDateofbirth = requestList.dateofbirth;
                                            Helpers.Settings.UserEmailaddress = requestList.emailaddress;
                                            Helpers.Settings.UserEmployeenumber = requestList.employeenumber;
                                            Helpers.Settings.UserEmployercode = requestList.employercode;
                                            Helpers.Settings.UserEmployername = requestList.employername;
                                            Helpers.Settings.UserFirstname = requestList.firstname;
                                            Helpers.Settings.UserMiddlename = requestList.middlename;
                                            Helpers.Settings.UserLastname = requestList.lastname;
                                            Helpers.Settings.UserMobileno = requestList.mobileno;
                                            Helpers.Settings.UserProfilepic = requestList.profilepic;
                                            Helpers.Settings.UserMaritalstatus = requestList.maritalstatus;
                                            Helpers.Settings.UserSalary = requestList.salary;
                                            Helpers.Settings.UserStartdate = requestList.startdate;
                                            Helpers.Settings.UserStatename = requestList.statename;
                                            Helpers.Settings.UserStatecode = requestList.statecode;
                                            Helpers.Settings.UserGender = requestList.gender;
                                            //Helpers.Settings.GeneralLoanNumber = requestList.loannumber;
                                            //Helpers.Constants.LoanSubmitSms = requestList.responsemessage;
                                            //SubmittedLoanApplicationPopup = new SubmittedLoanApplicationPopup();
                                            //await Navigation.PushPopupAsync(SubmittedLoanApplicationPopup, true);

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
        #endregion
    }
}
