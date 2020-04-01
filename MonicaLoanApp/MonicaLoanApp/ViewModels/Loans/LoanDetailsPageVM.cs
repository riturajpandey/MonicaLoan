using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanDetailsPageVM : BaseViewModel
    {

        #region  Constructor
        public LoanDetailsPageVM(INavigation nav)
        {
            Navigation = nav;
            MenuCommand = new Command(OnMenuAsync);
            PlusCommand = new Command(OnPlusAsync);

            ////TODO : Dummy Data in list
            //LoanDetailsList = new ObservableCollection<LoanDetailsModel>
            //{
            //     new LoanDetailsModel{Id="0", Amount="N500,000",Status="Pending approval",AmtDate="1 Feb 2020" ,},
            //     new LoanDetailsModel{Id="1", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="3", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="4", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="5", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="6", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="7", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="8", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="9", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //     new LoanDetailsModel{Id="10", Amount="N100,000",Status="Closed",AmtDate="1 Feb 2020", },
            //};
        }

        #endregion

        #region Commands  
        public Command MenuCommand { get; set; }
        public Command PlusCommand { get; set; }
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

        private ObservableCollection<AllLoan> _LoanDetailsList;
        public ObservableCollection<AllLoan> LoanDetailsList
        {
            get { return _LoanDetailsList; }
            set
            {
                if (_LoanDetailsList != value)
                {
                    _LoanDetailsList = value;
                    OnPropertyChanged("LoanDetailsList");
                }
            }
        }

        private bool _IsLoansAvailable;
        public bool IsLoansAvailable
        {
            get { return _IsLoansAvailable; }
            set
            {
                if (_IsLoansAvailable != value)
                {
                    _IsLoansAvailable = value;
                    OnPropertyChanged("IsLoansAvailable");
                }
            }
        }

        private bool _IsLoansNotAvailable;
        public bool IsLoansNotAvailable
        {
            get { return _IsLoansNotAvailable; }
            set
            {
                if (_IsLoansNotAvailable != value)
                {
                    _IsLoansNotAvailable = value;
                    OnPropertyChanged("IsLoansNotAvailable");
                }
            }
        }

        #endregion

        #region Methods
        public async Task GetAllLoans()
        {
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralAllLoanResponse))
            {
                var a = Helpers.Settings.GeneralAllLoanResponse;
                var allUserLoan = JsonConvert.DeserializeObject<AllLoanResponseModel>(a);
                if (allUserLoan != null)
                {
                    LoanDetailsList = new ObservableCollection<AllLoan>(allUserLoan.loans);
                } 
            }
            //Call api..
            try
            {
                if (string.IsNullOrEmpty(Helpers.Settings.GeneralAllLoanResponse))
                    UserDialogs.Instance.ShowLoading(); 
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.GetAllLoansApi(new AllLoanRequestModel()
                            {
                                usertoken = MonicaLoanApp.Helpers.Settings.GeneralAccessToken
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as AllLoanResponseModel).loans;
                                    if (requestList.Count > 0)
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        LoanDetailsList = new ObservableCollection<AllLoan>(requestList);
                                        IsLoansAvailable = true;
                                        IsLoansNotAvailable = false;
                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        IsLoansAvailable = false;
                                        IsLoansNotAvailable = true;
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
        /// TODO : To back Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnMenuAsync(object obj)
        {
            //await Navigation.PopModalAsync();
            App.masterDetailPage.IsPresented = true;
        }

        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPlusAsync(object obj)
        {
            IsPageEnable = false;
            await Navigation.PushModalAsync(new Views.Loans.LoanApplicationForm());
        }

        #endregion
    }
}
