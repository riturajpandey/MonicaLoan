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
    public class LoanApplicationPageVM : BaseViewModel
    {
        public List<string> ContextMenu = new List<string>();
        

        #region  Constructor
        public LoanApplicationPageVM(INavigation nav)
        {
            Navigation = nav;
            ContextMenu.Add("Accept");
            ContextMenu.Add("Decline"); 

            ////TODO : Dummy Data in list
            //LoanDetailsList = new ObservableCollection<LoanDetailsModel>
            //{
            //     new LoanDetailsModel{Id="0", Amount="N500,000",Status="Paid",AmtDate="1 Feb 2020"},
            //     new LoanDetailsModel{Id="1", Amount="N100,000",Status="Paid",AmtDate="1 Feb 2020"},
            //     new LoanDetailsModel{Id="2", Amount="N100,000",Status="Pay",AmtDate="1 Feb 2020"},
            //     new LoanDetailsModel{Id="2", Amount="N100,000",Status="Pay",AmtDate="1 Feb 2020"},
            //}; 
        }

        #endregion

        #region DELEGATECOMMAND  
         
        #endregion

        #region Properties 

        private ObservableCollection<Schedule> _LoanDetailsList;    
        public ObservableCollection<Schedule> LoanDetailsList   
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
        private string _Status = "Active";    
        public string Status
        {
            get { return _Status; }
            set
            {
                if(_Status!= value)
                {
                    _Status = value;
                    OnPropertyChanged("Status"); 
                }
            }
        }
        private string _Date = "1 Dec 2019";  
        public string Date
        {
            get { return _Date; }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        private string _LoanAmount = "N500,000";
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
        private string _LoanBalance = "N200,000";
        public string LoanBalance
        {
            get { return _LoanBalance; }
            set
            {
                if (_LoanBalance != value)
                {
                    _LoanBalance = value;
                    OnPropertyChanged("LoanBalance");
                }
            }
        }
        private string _UserCompany = "Coca Cola Limited";
        public string UserCompany
        {
            get { return _UserCompany; }
            set
            {
                if (_UserCompany != value)
                {
                    _UserCompany = value;
                    OnPropertyChanged("UserCompany");
                }
            }
        }
        private string _UserSalary = "N100,000";
        public string UserSalary
        {
            get { return _UserSalary; }
            set
            {
                if (_UserSalary != value)
                {
                    _UserSalary = value;
                    OnPropertyChanged("UserSalary");
                }
            }
        }
        private string _UserName = "ABC 1234";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        private string _EmployeeLoanDate ;
        public string EmployeeLoanDate
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("EmployeeLoanDate");
                }
            }
        }

        #endregion

        #region Methods
        public async Task GetLoanDetail(AllLoan allLoan)  
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
                                loannumber = allLoan.loannumber
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as LoanSearchResponseModel).loans;
                                    if (requestList != null)
                                    {
                                        UserDialogs.Instance.HideLoading(); 
                                        LoanDetailsList = new ObservableCollection<Schedule>(requestList[0].schedules);
                                        Status = requestList[0].statusname;
                                        Date = requestList[0].LoanDate; 
                                        LoanAmount = "N" + requestList[0].loanamount;
                                        LoanBalance = "N" + requestList[0].loanbalance;
                                        UserCompany = requestList[0].employername;  
                                        UserSalary = "N" + requestList[0].employeesalarymonthly;  
                                        EmployeeLoanDate = requestList[0].EmployeeLoanDate;   
                                        UserName = requestList[0].employeenumber;
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
        #endregion

    }
}
