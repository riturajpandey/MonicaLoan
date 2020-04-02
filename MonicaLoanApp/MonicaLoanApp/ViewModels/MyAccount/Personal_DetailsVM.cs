using Acr.UserDialogs;
using MonicaLoanApp.Helpers;
using MonicaLoanApp.Interfaces;
using MonicaLoanApp.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class Personal_DetailsVM : BaseViewModel
    {
        #region Constructor
        public Personal_DetailsVM(INavigation nav)
        {
            Navigation = nav;
            SaveCommand = new Command(SaveCommandAsync);
            CameraCommand = new Command(OnCameraAsync);
            GalleryCommand = new Command(OnGalleryAsync);
            MediaCommand = new Command(OnMediaAsync);
            CloseMediaCommand = new Command(OnCloseMediaAsync);
        }


        #endregion

        #region Properties

        private bool _IsCamera;
        public bool IsCamera
        {
            get { return _IsCamera; }
            set
            {
                if (_IsCamera != value)
                {
                    _IsCamera = value;
                    OnPropertyChanged("IsCamera");
                }
            }
        }
        private string _UserProfileBase64 = string.Empty;
        public string UserProfileBase64
        {
            get { return _UserProfileBase64; }
            set
            {
                if (_UserProfileBase64 != value)
                {
                    _UserProfileBase64 = value;
                    OnPropertyChanged("UserProfileBase64");
                }
            }
        }

        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

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

        private string _DateOfBirth = "Date of birth";
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if (_DateOfBirth != value)
                {
                    _DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
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
        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set
            {
                if (_MaritalStatus != value)
                {
                    _MaritalStatus = value;
                    OnPropertyChanged("MaritalStatus");
                }
            }
        }
        #endregion

        #region Command
        public Command CameraCommand { get; set; }
        public Command GalleryCommand { get; set; }
        public Command MediaCommand { get; set; }
        public Command CloseMediaCommand { get; set; }
        public Command SaveCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// To Call Api To Save Profile...
        /// </summary>
        /// <param name="obj"></param>
        private async void SaveCommandAsync(object obj)
        {
            IsPageEnable = false;

            if (string.IsNullOrEmpty(Number))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Mobile Number.");
                IsPageEnable = true;
                return ;
            }
            if (Number.Length > 15)
            {
                UserDialog.Alert("Mobile Number should not be more than 15 digit.");
                IsPageEnable = true;
                return ;
            }
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
                                mobileno = Number,
                                gender = Gender,
                                maritalstatus = MaritalStatus,
                                bankcode = Helpers.Constants.UserBankcode,
                                bankaccountno = Helpers.Constants.UserBankaccountno,
                                addressline1 = Helpers.Constants.UserAddressline1,
                                addressline2 = Helpers.Constants.UserAddressline2,
                                City = Helpers.Constants.UserCity,
                                Statecode = Helpers.Constants.UserStatecode,
                                employercode = Helpers.Constants.UserEmployercode,
                                employeenumber = Helpers.Constants.UserEmployeenumber,
                                Salary = Helpers.Constants.UserSalary,
                                Startdate = Helpers.Constants.UserStartdate,
                                Profilepic = UserProfileBase64
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
                                                Title = "",
                                                Message = "Your personal details have been successfully updated.", 
                                                OkText = "OK",
                                                OnAction = async() =>
                                                {
                                                    await Navigation.PopModalAsync();
                                                }
                                            };
                                            UserDialogs.Instance.Alert(alertConfig);
                                        }
                                        else
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");
                                        }

                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
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
                    UserDialogs.Instance.Loading().Hide();
                    await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
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
                    Helpers.Settings.GeneralProfilePic = userDetail.profilepic;
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
                    UserProfileBase64 = userDetail.profilepic;
                    MessagingCenter.Send<string>("", "LoadApiImage");
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
                                            Helpers.Settings.GeneralProfilePic = requestList.profilepic;
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


        /// <summary>
        /// TODO : To Camera Action ...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnCameraAsync(object obj)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync
                                             (Plugin.Permissions.Abstractions.Permission.Camera);

                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    var result = await CrossPermissions.Current.RequestPermissionsAsync(new[] {
                                                                                  Plugin.Permissions.Abstractions.Permission.Camera });
                    status = result[Plugin.Permissions.Abstractions.Permission.Camera];
                }

                if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    UserProfileBase64 = string.Empty;
                    if (!CrossMedia.Current.IsCameraAvailable)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert("No camera avaialble.", null, "OK");
                        return;
                    }
                    if (Device.OS == TargetPlatform.Android)
                        UserDialogs.Instance.ShowLoading("Please Wait…");
                    var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.png",
                    });
                    if (file == null)
                    {
                        UserDialogs.Instance.HideLoading();
                        return;
                    }
                    Constants.imgFilePath = file.Path;
                    string filepath = file.Path;
                    var ImageByteData = await DependencyService.Get<IMediaService>().ResizeImage(await DependencyService.Get<IMediaService>().GetMediaInBytes(file.Path), 120, 120);
                    UserProfileBase64 = Convert.ToBase64String(ImageByteData);
                    Helpers.Settings.GeneralProfilePic = UserProfileBase64;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        UserDialogs.Instance.HideLoading();
                        MessagingCenter.Send<string>("", "LoadImage");
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        UserDialogs.Instance.Alert("Camera permission denied. Make sure you have given us camera permission, go to settings and enable camera permission for us.", "", "Ok");
                        UserDialogs.Instance.HideLoading();
                    });
                }

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            { UserDialogs.Instance.HideLoading(); }
        }

        /// <summary>
        /// TODO : To Gallery Action ...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnGalleryAsync(object obj)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync
                                             (Plugin.Permissions.Abstractions.Permission.Photos);

                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    var result = await CrossPermissions.Current.RequestPermissionsAsync(new[] {
                                                                                  Plugin.Permissions.Abstractions.Permission.Photos });
                    status = result[Plugin.Permissions.Abstractions.Permission.Photos];
                }

                if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {

                    UserProfileBase64 = string.Empty;
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        return;
                    }
                     
                    var file = await CrossMedia.Current.PickPhotoAsync();
                    if (file == null)
                    {
                        UserDialogs.Instance.HideLoading();
                        return;
                    }
                    Helpers.Constants.imgFilePath = file.Path;
                    string filepath = file.Path; 

                    var ImageByteData = await DependencyService.Get<IMediaService>().ResizeImage(await DependencyService.Get<IMediaService>().GetMediaInBytes(file.Path), 120, 120);
                    UserProfileBase64 = Convert.ToBase64String(ImageByteData);
                    Helpers.Settings.GeneralProfilePic = UserProfileBase64;
                     
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        UserDialogs.Instance.HideLoading();

                        MessagingCenter.Send<string>("", "LoadImage");
                    });
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        /// <summary>
        /// TODO : To Open Media Popup Async ...
        /// </summary>
        /// <param name="obj"></param>
        public async void OnMediaAsync()
        {
            IsCamera = true;
        }

        /// <summary>
        /// TODO : To Open Media Popup Async ...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnCloseMediaAsync(object obj)
        {
            IsCamera = false;
        } 
        #endregion
    }
}
