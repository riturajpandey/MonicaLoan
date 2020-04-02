using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettingPage : ContentPage
    {
        /// <summary>
        /// TODO: To define class level variable.
        /// </summary>
        protected AppSettingPageVM AppSettingVM;

        #region Constructor
        public AppSettingPage()
        {
            InitializeComponent(); 
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            AppSettingVM = new AppSettingPageVM(this.Navigation);
            this.BindingContext = AppSettingVM;


            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralIsNotification))
            {
                SwtchNotification.IsToggled = true;
            }
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralIsSound))
            {
                SwtchSound.IsToggled = true;
            }
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralIsVibrate))
            {
                SwtchVibrate.IsToggled = true;
            }
        }
        #endregion 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VersionTracking.Track();
            var currentVersion = VersionTracking.CurrentVersion;
            LblVersion.Text = "Version " + currentVersion.ToString();
        }

        /// <summary>
        /// TODO : To Define Event Handler For Notifications Toggled...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (AppSettingVM.IsNotification)
            {
                AppSettingVM.IsNotification = false;
                SwtchSound.IsEnabled = false;
                SwtchVibrate.IsEnabled = false;
                SwtchSound.IsToggled = false;
                SwtchVibrate.IsToggled = false;
                AppSettingVM.IsSound = false;
                AppSettingVM.IsVibrate = false;
                Helpers.Settings.GeneralIsNotification = string.Empty;
            }
            else
            {
                AppSettingVM.IsNotification = true;
                SwtchSound.IsEnabled = true;
                SwtchVibrate.IsEnabled = true;
                Helpers.Settings.GeneralIsNotification = "true";
            }
        }

        /// <summary>
        /// TODO : To Define Event Handler For Sound Toggled...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoundSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (AppSettingVM.IsSound)
            {
                AppSettingVM.IsSound = false;
                Helpers.Settings.GeneralIsSound = string.Empty;
            }
            else
            {
                AppSettingVM.IsSound = true;
                Helpers.Settings.GeneralIsSound = "true";
            }
        }

        /// <summary>
        /// TODO : To Define Event Handler For Vibrate Toggled...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VibrateSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (AppSettingVM.IsVibrate)
            {
                AppSettingVM.IsVibrate = false;
                Helpers.Settings.GeneralIsVibrate = string.Empty;
            }
            else
            {
                AppSettingVM.IsVibrate = true;
                Helpers.Settings.GeneralIsVibrate = "true";

            }
        }

    }
}