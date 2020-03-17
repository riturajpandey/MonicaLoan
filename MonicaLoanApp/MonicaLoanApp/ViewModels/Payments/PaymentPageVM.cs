﻿using Acr.UserDialogs;
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
    public class PaymentPageVM : BaseViewModel
    {
        #region Constructor
        public PaymentPageVM(INavigation nav)
        {
            Navigation = nav;
            MenuCommand = new Command(MenuCommandAsync);
            PlusCommand = new Command(PlusCommandAsync);
            PaymentPlusCommand = new Command(PaymentPlusCommandAsync);
            //PaymentList = new ObservableCollection<PaymentsListModel>
            //{
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //    new PaymentsListModel{Amount="N50,000", AmntDate="1 Dec 2019",SmsLabel="Payment recived for some text here eith lorium ipsum dolor alt amet, consecteur sed do."},
            //};
        }

       
        #endregion

        #region Properties
        private string _PaymentStatus= "No Payments Currently";
        public string PaymentStatus
        {
            get { return _PaymentStatus; }
            set
            {
                if(_PaymentStatus!= value)
                {
                    _PaymentStatus = value;
                    OnPropertyChanged("PaymentStatus");
                }
            }
        }
        private ObservableCollection<Payment> _PaymentList;
        public ObservableCollection<Payment> PaymentList
        {
            get { return _PaymentList; }
            set
            {
                if(_PaymentList!= value)
                {
                    _PaymentList = value;
                    OnPropertyChanged("PaymentList");
                }
            }
        }

        private bool _IsPaymentAvailable;
        public bool IsPaymentAvailable
        {
            get { return _IsPaymentAvailable; }
            set
            {
                if (_IsPaymentAvailable != value)
                {
                    _IsPaymentAvailable = value; 
                    OnPropertyChanged("IsPaymentAvailable");
                }
            }
        }

        private bool _IsPaymentNotAvailable;
        public bool IsPaymentNotAvailable
        {
            get { return _IsPaymentNotAvailable; }
            set
            {
                if (_IsPaymentNotAvailable != value)
                {
                    _IsPaymentNotAvailable = value; 
                    OnPropertyChanged("IsPaymentNotAvailable");
                }
            }
        }
        #endregion

        #region Commands
        public Command MenuCommand { get; set; } 
        public Command PlusCommand { get; set; }
        public Command PaymentPlusCommand { get; set; }
        #endregion

        #region Methods
        //TODO : To Call Api To Get All Payments...
        public async Task GetAllPayments()
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
                            await _businessCode.PaymentSearchApi(new PaymentSearchRequestModel()
                            {
                                usertoken = MonicaLoanApp.Helpers.Settings.GeneralAccessToken
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as PaymentSearchResponseModel).payments;
                                    if (requestList.Count > 0)
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        PaymentList = new ObservableCollection<Payment>(requestList);
                                        IsPaymentNotAvailable = false;
                                        IsPaymentAvailable = true; 
                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        IsPaymentNotAvailable = true;
                                        IsPaymentAvailable = false;
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
        /// TODO: To define PlusCommand for Navigate page..
        /// </summary>
        /// <param name="obj"></param>
        private void PlusCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.Payments.PaymentListPage());
        }
        /// <summary>
        /// TODO: To define PlusCommand for add Payment..
        /// </summary>
        /// <param name="obj"></param>
        private void PaymentPlusCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.Payments.MakePaymentPage());
        }

        private void MenuCommandAsync(object obj)   
        {
            App.masterDetailPage.IsPresented = true; 
        }
        #endregion
    }
}
