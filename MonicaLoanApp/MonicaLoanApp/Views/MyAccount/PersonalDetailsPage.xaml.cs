using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            PersonalDetailsVM = new Personal_DetailsVM(this.Navigation);
            this.BindingContext = PersonalDetailsVM;


            //if (!string.IsNullOrEmpty(Helpers.Constants.UserMaritalstatus))
            //{
            //    var item = PersonalDetailsVM.Statelist.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
            //    var index = PersonalDetailsVM.Statelist.IndexOf(item);
            //    MaritalStatus.SelectedItem = index;
            //}
        }
        #endregion

        #region Methods
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtPckDOB_Tapped(object sender, EventArgs e)
        {
            DtPckDOB.Focus();
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                if (DtPckDOB.Date != null)
                {
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    PersonalDetailsVM.DateOfBirth = DateBirth;
                }

            }
            catch (Exception ex)
            { }

        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (DtPckDOB.Date != null)
                {
                    // RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("MM/dd/yyyy");
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    PersonalDetailsVM.DateOfBirth = DateBirth;

                }
            }
            catch (Exception ex)
            { }
        }
        private void MaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckMaritalStatus.SelectedIndex >= 0)
            {
                PersonalDetailsVM.MaritalStatus = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckgender.SelectedIndex >= 0)
            {
                PersonalDetailsVM.Gender = pckgender.Items[pckgender.SelectedIndex];
            }
        }


        #endregion


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            PersonalDetailsVM.FirstName = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            PersonalDetailsVM.Email = Helpers.Constants.UserEmailAddress;
            PersonalDetailsVM.DateOfBirth = Helpers.Constants.UserDateofbirth;
            PersonalDetailsVM.Gender = Helpers.Constants.Usergender;
            PersonalDetailsVM.MaritalStatus = Helpers.Constants.UserMaritalstatus;
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonalDetailsVM.Gender = PckGender.Items[PckGender.SelectedIndex]; 
        }

        private void PckMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonalDetailsVM.MaritalStatus = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
        }
    }
}