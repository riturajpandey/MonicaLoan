using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
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

        #endregion

        #region Methods
        public async Task GetAllLoans()
        {
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
        /// TODO : To back Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnMenuAsync(object obj)
        {
            await Navigation.PopModalAsync();
        }
       
        /// <summary>
        /// TODO: To validate Forgot Password Command..
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPlusAsync(object obj)
        {
            await Navigation.PushModalAsync(new Views.Loans.LoanApplicationForm());
        }

        #endregion
    }
}
