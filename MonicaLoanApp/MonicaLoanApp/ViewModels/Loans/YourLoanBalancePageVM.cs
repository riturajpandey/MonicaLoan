using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Payments;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class YourLoanBalancePageVM : BaseViewModel
    {
        public int TapCount1 = 0;
        public int TapCount2 = 0;
        public int TapCount3 = 0;

        #region  Constructor
        public YourLoanBalancePageVM(INavigation nav)
        {
            Navigation = nav;
            PlusCommand = new Command(PlusCommandAsync);
            ListCommand = new Command(ListCommandAsync);
            LoansCommand = new Command(LoansCommandAsync); 
        }
        #endregion

        #region Commands  
        public Command PlusCommand { get; set; }
        public Command ListCommand { get; set; }
        public Command LoansCommand { get; set; }
        #endregion

        #region Properties
        private bool _IsPageEnable = true;   
        public bool IsPageEnable
        {
            get { return _IsPageEnable; }  
            set
            {
                if (_IsPageEnable != value)
                {
                    _IsPageEnable = value;
                    OnPropertyChanged("IsPageEnable");
                }
            }
        }

        private string _LoanAmount;
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
        private string _DueAmount;
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
        private async void ListCommandAsync(object obj)
        {
            if (TapCount1 == 0)
            {
                TapCount1++;
                App.masterDetailPage.IsPresented = false;
                App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new PaymentListPage());
                App.Current.MainPage = App.masterDetailPage;
                App.masterDetailPage.IsPresented = false;
                //await Navigation.PushModalAsync(new Views.Payments.MakePaymentPage(),false);
            }
        }
        /// <summary>
        /// TODO: To Go To Loans Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void LoansCommandAsync(object obj)
        {
            if (TapCount3 == 0)
            {
                TapCount3++;
                await Task.Delay(10);
                App.masterDetailPage.IsPresented = false;
                App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new LoanDetailsPage());
                App.Current.MainPage = App.masterDetailPage;
                App.masterDetailPage.IsPresented = false;
            }
        }

        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private async void PlusCommandAsync(object obj)
        {
            if (TapCount2 == 0)
            {
                TapCount2++;
                await Navigation.PushModalAsync(new Views.Loans.LoanApplicationForm(), false);
            }
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
                //To Load The Data From Cache...
                if (!string.IsNullOrEmpty(Helpers.Settings.GeneralProfileDataJSON))
                {
                    var requestList = JsonConvert.DeserializeObject<ProfileGetResponseModel>(Helpers.Settings.GeneralProfileDataJSON);
                    if (requestList != null)
                    {
                        if (requestList.responsecode == 100)
                        {
                            Helpers.Constants.ProfileNumber = requestList.profilenumber;
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
                            Helpers.Settings.GeneralProfilePic = requestList.profilepic;
                            var x = Helpers.Settings.GeneralProfilePic;
                            Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
                            Helpers.Constants.UserSalary = requestList.salary;
                            Helpers.Constants.UserStateName = requestList.statename;
                            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
                            {
                                var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                                Helpers.Constants.UserStatecode = item.key;
                            }
                            Helpers.Constants.UserStartdate = requestList.startdate;
                            Helpers.Constants.Usergender = requestList.gender;
                        }  
                    } 
                }
                //Call AccessRegister Api..  
                //UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
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
                                            Helpers.Constants.ProfileNumber = requestList.profilenumber;
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
                                            Helpers.Settings.GeneralProfilePic = requestList.profilepic;
                                            var x = Helpers.Settings.GeneralProfilePic;
                                            Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
                                            Helpers.Constants.UserSalary = requestList.salary;
                                            Helpers.Constants.UserStateName = requestList.statename;
                                            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
                                            {
                                                var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                                                Helpers.Constants.UserStatecode = item.key;
                                            }
                                            Helpers.Constants.UserStartdate = requestList.startdate;
                                            Helpers.Constants.Usergender = requestList.gender;
                                        }
                                        else
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");

                                        }

                                    }
                                    UserDialog.HideLoading();
                                });
                            }, (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    UserDialog.HideLoading();
                                    UserDialog.Alert("Something went wrong. Please try again later.", "", "Ok");
                                });
                            });
                        }
                    }).ConfigureAwait(false);
                }
                else
                {
                    //UserDialogs.Instance.Loading().Hide();
                    //await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
                }
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion
    }
}
