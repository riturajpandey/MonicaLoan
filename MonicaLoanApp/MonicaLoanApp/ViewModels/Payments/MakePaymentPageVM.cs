using Acr.UserDialogs;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.Models.Payments;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Payments
{
    public class MakePaymentPageVM : BaseViewModel
    {
        #region Constructor
        public MakePaymentPageVM(INavigation nav)
        {
            Navigation = nav;
            PaymentCommand = new Command(PaymentCommandAsync);
        }
        #endregion

        #region Properties
        private string _DateOfBirth = "Select schedule";
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
        private string _Amount;
        public string Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount != value)
                {
                    _Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        private string _LoanPurpose;
        public string LoanPurpose
        {
            get { return _LoanPurpose; }
            set
            {
                if (_LoanPurpose != value)
                {
                    _LoanPurpose = value; 
                    OnPropertyChanged("LoanPurpose"); 
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

        private string _LoanSchedule;
        public string LoanSchedule 
        {
            get { return _LoanSchedule; }
            set
            {
                if (_LoanSchedule != value)
                {
                    _LoanSchedule = value;
                    OnPropertyChanged("LoanSchedule"); 
                }
            }
        }

        private ObservableCollection<Loan> _LoansList;
        public ObservableCollection<Loan> LoansList
        {
            get { return _LoansList; } 
            set
            {
                if (_LoansList != value)
                {
                    _LoansList = value;
                    OnPropertyChanged("LoansList");
                }
            }
        }

        private ObservableCollection<Schedule> _SchedulesList;
        public ObservableCollection<Schedule> SchedulesList 
        {
            get { return _SchedulesList; }
            set
            {
                if (_SchedulesList != value)
                {
                    _SchedulesList = value;
                    OnPropertyChanged("SchedulesList");
                }
            }
        }
        #endregion

        #region Commands
        public Command PaymentCommand { get; set; }
        #endregion

        #region Methods
        public async Task GetLoans()
        {
            //Call api..
            try
            {
                //UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.LoanSearchApi(new LoanSearchRequestModel()
                            {
                                usertoken = MonicaLoanApp.Helpers.Settings.GeneralAccessToken,
                                loannumber = "1338806772"
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as LoanSearchResponseModel).loans;
                                    if (requestList != null)
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        LoansList = new ObservableCollection<Loan>(requestList); 
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
        /// TODO: To define Payment Complete Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void PaymentCommandAsync(object obj)
        {
            //Apply LoginValidations...
            if (!await PaymentValidate()) return;

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
                            await _businessCode.PaymentCreateApi(new PaymentCreateRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                                loannumber = "1338806772",
                                loanschedulenumber = LoanSchedule,
                                amount = Amount,
                                paymentmethodcode = "CARD"
                            },
                            async (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (objj as PaymentCreateResponseModel); 
                                    if (requestList != null) 
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        var alertConfig = new AlertConfig
                                        {
                                            Title = "Alert", 
                                            Message = "Payment created successfully!",   
                                            OkText = "OK",
                                            OnAction = () =>
                                            {
                                                App.Current.MainPage = new Views.Payments.PaymentListPage();
                                            }
                                        };
                                        UserDialogs.Instance.Alert(alertConfig);
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

            //UserDialog.Alert("Payment Complete successfully.!", "Success", "Ok");
            //App.Current.MainPage = new Views.Payments.PaymentListPage();
        }

        //TODO : To Apply SignupValidations...
        private async Task<bool> PaymentValidate()
        {
            if (string.IsNullOrEmpty(LoanPurpose))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please select loan.", "Alert", "Ok"); 
                return false;
            }
            if (string.IsNullOrEmpty(LoanSchedule))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please select schedule", "Alert", "Ok"); 
                return false;
            }
            if (string.IsNullOrEmpty(Amount))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter amount.", "Alert", "Ok");
                return false; 
            } 
            if(Convert.ToInt32(Amount) > (Convert.ToInt32(LoanAmount)))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Invalid amount", "Alert", "Ok");
                return false;
            }
            return true; 
        }
        #endregion

    }
}
