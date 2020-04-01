using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class AddressPageVM : BaseViewModel
    {
        #region Constructor
        public AddressPageVM(INavigation nav)
        {
            Navigation = nav;
            SaveCommand = new Command(SaveCommandAsync);
        }
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

        private string _AddressOne;
        public string AddressOne
        {
            get { return _AddressOne; }
            set
            {
                if (_AddressOne != value)
                {
                    _AddressOne = value;
                    OnPropertyChanged("AddressOne");
                }
            }
        }
        private string _AddressSecond;
        public string AddressSecond
        {
            get { return _AddressSecond; }
            set
            {
                if (_AddressSecond != value)
                {
                    _AddressSecond = value;
                    OnPropertyChanged("AddressSecond");
                }
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged("City");
                }
            }
        }
        private string _StateCode;
        public string StateCode
        {
            get { return _StateCode; }
            set
            {
                if (_StateCode != value)
                {
                    _StateCode = value;
                    OnPropertyChanged("StateCode");
                }
            }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged("State");
                }
            }
        }

        private ObservableCollection<Staticdata> _Statelist;
        public ObservableCollection<Staticdata> Statelist
        {
            get { return _Statelist; }
            set
            {
                if (_Statelist != value)
                {
                    _Statelist = value;
                    OnPropertyChanged("Statelist");
                }
            }
        }
        #endregion

        #region Commands
        public Command SaveCommand { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// To Call Api To Save Profile...
        /// </summary>
        /// <param name="obj"></param>
        private async void SaveCommandAsync(object obj)
        {
            //Apply LoginValidations...
            if (!await ValidateAddress()) return;
            //Call api..
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.ProfileSaveApi(new ProfileSaveRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                                mobileno = Helpers.Constants.Usermobileno,
                                gender = Helpers.Constants.Usergender,
                                maritalstatus = Helpers.Constants.UserMaritalstatus,
                                bankcode = Helpers.Constants.UserBankcode,
                                bankaccountno = Helpers.Constants.UserBankaccountno,
                                addressline1 = AddressOne,
                                addressline2 = AddressSecond,
                                City = City,
                                Statecode = StateCode,
                                employercode = Helpers.Constants.UserEmployercode,
                                employeenumber = Helpers.Constants.UserEmployeenumber,
                                Salary = Helpers.Constants.UserSalary,
                                Startdate = Helpers.Constants.UserStartdate,
                                Profilepic = Helpers.Constants.Userprofilepic
                            },
                            async (_obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (_obj as ProfileSaveResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            await GetProfile();
                                            UserDialogs.Instance.HideLoading();
                                            var alertConfig = new AlertConfig
                                            {
                                                Title = "Alert",
                                                Message = "Your address updated successfully!",
                                                OkText = "OK",
                                                OnAction = () =>
                                                {
                                                    App.Current.MainPage = new Views.MyAccount.MyAccountPage();
                                                }
                                            };
                                            UserDialogs.Instance.Alert(alertConfig);
                                        }
                                        else
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "Alert", "ok");
                                        }

                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
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
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralUserProfileResponse))
            {
                var b = Helpers.Settings.GeneralUserProfileResponse;
                var userDetail = JsonConvert.DeserializeObject<ProfileGetResponseModel>(b);
                if (userDetail != null)
                {
                    Helpers.Constants.UserLoanbalance = userDetail.loanbalance;
                    Helpers.Constants.UserDuebalance = userDetail.duesoon;
                    Helpers.Constants.UserBvn = userDetail.bvn;
                    Helpers.Constants.UserCity = userDetail.city;
                    Helpers.Constants.UserBankname = userDetail.bankname;
                    Helpers.Constants.UserBankcode = userDetail.bankcode;
                    Helpers.Constants.UserAddressline1 = userDetail.addressline1;
                    Helpers.Constants.UserAddressline2 = userDetail.addressline2;
                    Helpers.Constants.UserBankaccountno = userDetail.bankaccountno;
                    Helpers.Constants.UserDateofbirth = userDetail.dateofbirth;
                    Helpers.Constants.UserEmailAddress = userDetail.emailaddress;
                    Helpers.Constants.UserEmployeenumber = userDetail.employeenumber;
                    Helpers.Constants.UserEmployercode = userDetail.employercode;
                    Helpers.Constants.UserEmployername = userDetail.employername;
                    Helpers.Constants.UserFirstname = userDetail.firstname;
                    Helpers.Constants.UserMiddlename = userDetail.middlename;
                    Helpers.Constants.UserLastname = userDetail.lastname;
                    Helpers.Constants.Usermobileno = userDetail.mobileno;
                    Helpers.Constants.Userprofilepic = userDetail.profilepic;
                    Helpers.Constants.UserMaritalstatus = userDetail.maritalstatus;
                    Helpers.Constants.UserSalary = userDetail.salary;
                    Helpers.Constants.UserStateName = userDetail.statename;
                    if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
                    {
                        var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                        Helpers.Constants.UserStatecode = item.key;
                    }
                    Helpers.Constants.UserStartdate = userDetail.startdate;
                    Helpers.Constants.Usergender = userDetail.gender;
                }
            }
            //Call api..
            try
            {
                if (string.IsNullOrEmpty(Helpers.Settings.GeneralUserProfileResponse))
                    UserDialogs.Instance.ShowLoading();
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
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "Alert", "ok");
                                        }

                                    }
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
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            //Fileter Bank List From Static Data List..
            try
            {
                var filteredStatelist = Helpers.Constants.StaticDataList.Where(a => a.type == "STATE").ToList();
                Statelist = new ObservableCollection<Staticdata>(filteredStatelist);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }

        /// <summary>
        /// TODO : To Validate User ValidateAddress Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateAddress()
        {
            if (string.IsNullOrEmpty(AddressOne))
            {
                UserDialog.Alert("Please enter address line 1");
                return false;
            }
            if (string.IsNullOrEmpty(AddressSecond))
            {
                UserDialog.Alert("Please enter your address line 2.");
                return false;
            }
            if (string.IsNullOrEmpty(City))
            {
                UserDialog.Alert("Please enter your city.");
                return false;
            }
            if(string.IsNullOrEmpty(State))
            {
                UserDialog.Alert("Please select state.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
