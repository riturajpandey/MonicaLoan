using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Personal_Details : ContentPage
    {
        /// <summary>
        /// TODO: To define class level variable.
        /// </summary>
        protected Personal_DetailsVM PersonalDetailsVM;

        #region Constructor
        public Personal_Details()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            PersonalDetailsVM = new Personal_DetailsVM(this.Navigation);
            this.BindingContext = PersonalDetailsVM;

            //To Show Profile Pic
            MessagingCenter.Subscribe<string>("", "LoadImage", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(PersonalDetailsVM.UserProfileBase64))
                        {
                            imgUserProfile.Aspect = Aspect.AspectFill;
                            imgUserProfile.Margin = new Thickness(0);
                            imgUserProfile.Source = Helpers.Constants.imgFilePath;
                            PersonalDetailsVM.IsCamera = false;
                        }
                    }
                    catch (Exception)
                    { }
                });
            });

            //To Show Profile Pic
            MessagingCenter.Subscribe<string>("", "LoadApiImage", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(PersonalDetailsVM.UserProfileBase64))
                        {
                            imgUserProfile.Aspect = Aspect.AspectFill;
                            imgUserProfile.Margin = new Thickness(0);
                            imgUserProfile.Source = Utilities.Utility.GetImageFromBase64(PersonalDetailsVM.UserProfileBase64);
                        }
                    }
                    catch (Exception)
                    { }
                });
            });

        }
        #endregion

        #region Methods
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DtPckDOB_Tapped(object sender, EventArgs e)
        //{
        //    DtPckDOB.Focus();
        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (DtPckDOB.Date != null)
        //        {
        //            var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
        //            var DateBirth = date.Replace("-", "/");
        //            PersonalDetailsVM.DateOfBirth = DateBirth;
        //        }

        //    }
        //    catch (Exception ex)
        //    { }

        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        //{
        //    try
        //    {
        //        if (DtPckDOB.Date != null)
        //        {
        //            // RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("MM/dd/yyyy");
        //            var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
        //            var DateBirth = date.Replace("-", "/");
        //            PersonalDetailsVM.DateOfBirth = DateBirth;

        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}


        //private void MaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (PckMaritalStatus.SelectedIndex >= 0)
        //    {
        //        PersonalDetailsVM.MaritalStatus = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
        //    }
        //}

        //private void gender_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (PckGender.SelectedIndex >= 0)
        //    {
        //        PersonalDetailsVM.Gender = PckGender.Items[PckGender.SelectedIndex];
        //    }
        //}


        #endregion


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            PersonalDetailsVM.IsPageEnable = true;
            PersonalDetailsVM.FirstName = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            PersonalDetailsVM.Email = Helpers.Constants.UserEmailAddress;
            PersonalDetailsVM.Number = Helpers.Constants.Usermobileno;
            if (!string.IsNullOrEmpty(Helpers.Constants.UserDateofbirth))
            {
                var Day = Helpers.Constants.UserDateofbirth.Substring(0, 2);
                var Month = Helpers.Constants.UserDateofbirth.Substring(3, 2);
                var Year = Helpers.Constants.UserDateofbirth.Substring(6, 4);
                var monthname = Utilities.Utility.ConvertMonthIntoEnglishLanguage(Month);
                PersonalDetailsVM.DateOfBirth = monthname + " " + Day + ", " + Year;
            }
            
            PersonalDetailsVM.Gender = Helpers.Constants.Usergender;
            PersonalDetailsVM.MaritalStatus = Helpers.Constants.UserMaritalstatus;

            if (!string.IsNullOrEmpty(Helpers.Constants.Usergender))
            {
                if (PersonalDetailsVM.Gender == "M")
                {
                    PckGender.SelectedIndex = 0;
                }
                else
                {
                    PckGender.SelectedIndex = 1;
                }
                //PckGender.SelectedItem = Helpers.Constants.Usergender;
            }
            if (!string.IsNullOrEmpty(Helpers.Constants.UserMaritalstatus))
            {
                if (PersonalDetailsVM.MaritalStatus == "S")
                {
                    PckMaritalStatus.SelectedIndex = 0;
                }
                else
                {
                    PckMaritalStatus.SelectedIndex = 1;
                }
                //PckMaritalStatus.SelectedItem = Helpers.Constants.UserMaritalstatus;  
            }
            var c = Helpers.Settings.GeneralProfilePic;
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralProfilePic)) 
            {
                PersonalDetailsVM.UserProfileBase64 = Helpers.Settings.GeneralProfilePic;
                var p = PersonalDetailsVM.UserProfileBase64;
                imgUserProfile.Aspect = Aspect.AspectFill;
                imgUserProfile.Margin = new Thickness(0);
                imgUserProfile.Source = Utilities.Utility.GetImageFromBase64(PersonalDetailsVM.UserProfileBase64);
            }
        }
         
        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender = PckGender.Items[PckGender.SelectedIndex];
            if (gender == "Male")
            {
                PersonalDetailsVM.Gender = "M";
            }
            else
            {
                PersonalDetailsVM.Gender = "F";
            }
            //PersonalDetailsVM.Gender = PckGender.Items[PckGender.SelectedIndex];
        }

        private void PckMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
            if (status == "Single")
            {
                PersonalDetailsVM.MaritalStatus = "S";
            }
            else
            {
                PersonalDetailsVM.MaritalStatus = "M"; 
            }

            //PersonalDetailsVM.MaritalStatus = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
        }

        private void DropGender_Tapped(object sender, EventArgs e)
        {
            PckGender.Focus();
        }

        private void DropMarritalStatus_Tapped(object sender, EventArgs e)
        {
            PckMaritalStatus.Focus();
        }
    }
}