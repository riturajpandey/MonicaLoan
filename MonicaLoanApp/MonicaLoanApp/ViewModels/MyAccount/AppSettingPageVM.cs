using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class AppSettingPageVM : BaseViewModel
    {
        #region Constructor
        public AppSettingPageVM(INavigation nav)
        {
            Navigation = nav;
            BackCommand = new Command(BackCommandAsync);
            ShareCommand = new Command(ShareAsync);
            FeedbackCommand = new Command(FeedBackAsync);
            PolicyCommand = new Command(TermsAsync);
            TermsCommand = new Command(PolicyAsync); 
        }
        #endregion

        #region Properties

        private bool _IsNotificationOn;
        public bool IsNotificationOn
        {
            get { return _IsNotificationOn; }
            set
            {
                if (_IsNotificationOn != value)
                {
                    _IsNotificationOn = value;
                    OnPropertyChanged("IsNotificationOn");
                }
            }
        }

        private bool _IsSoundOn;
        public bool IsSoundOn
        {
            get { return _IsSoundOn; }
            set
            {
                if (_IsSoundOn != value)
                {
                    _IsSoundOn = value;
                    OnPropertyChanged("IsSoundOn");
                }
            }
        }

        private bool _IsVibrateOn;
        public bool IsVibrateOn
        {
            get { return _IsVibrateOn; }
            set
            {
                if (_IsVibrateOn != value)
                {
                    _IsVibrateOn = value;
                    OnPropertyChanged("IsVibrateOn");
                }
            }
        }

        public bool IsNotification = false;
        public bool IsSound = false;
        public bool IsVibrate = false;

        #endregion

        #region Command 
        public Command BackCommand { get; set; }
        public Command ShareCommand { get; set; }
        public Command FeedbackCommand { get; set; }
        public Command PolicyCommand { get; set; }
        public Command TermsCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// To Define Back Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void BackCommandAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.MyAccount.MyAccountPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
            //App.Current.MainPage = new Views.MyAccount.MyAccountPage();
        }
        /// <summary>
        /// To Define Share Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void ShareAsync(object obj)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "My App Data",
                Text = "Moni’ca is the instant loan app: https://monica.ng",
            });
        }
        /// <summary>
        /// To Define FeedBack Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void FeedBackAsync(object obj)
        {
            Device.OpenUri(new Uri("https://monica.ng/feedback"));
        }
        
        /// <summary>
        /// To Define Terms And Condition Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void TermsAsync(object obj)
        {
            Device.OpenUri(new Uri("https://monica.ng/terms"));
        }

        /// <summary>
        /// To Define Privacy Policy Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void PolicyAsync(object obj)
        {
            Device.OpenUri(new Uri("https://monica.ng/privacy"));
        }

        #endregion
    }
}
