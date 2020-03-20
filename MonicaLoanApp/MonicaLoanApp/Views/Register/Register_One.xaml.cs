using MonicaLoanApp.Models;
using MonicaLoanApp.ViewModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register_One : ContentPage
    {
        //TODO: TO define class level variable
        protected Register_OneVM RegisterOneVM;

        #region constructor
        public Register_One()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            RegisterOneVM = new Register_OneVM(this.Navigation);
            this.BindingContext = RegisterOneVM;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0;
            // await RegisterOneVM.AccessRegister();
            // await RegisterOneVM.AccessRegisterActivate();
            await RegisterOneVM.StaticDataSearch();
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO:To define back Tap Gesture...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //  //  Navigation.PopModalAsync();
        //}

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
                    RegisterOneVM.DateOfBirth = DateBirth;
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
                    RegisterOneVM.DateOfBirth = DateBirth;

                }
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// TODO :
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PckBank_Tapped(object sender, EventArgs e)
        {
            PckBank.Focus();
        }
        /// <summary>
        /// TODO :
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PckBankfrst_Tapped(object sender, EventArgs e)
        {
            PckBankfrst.Focus();
        }

        /// <summary>
        /// TODO : To Defeine Event Handelr To Focus Gender Pciker...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PckGender_Tapped(object sender, EventArgs e)
        {
            Pckgender.Focus();
        }
        #endregion

        private void PckSelectbankCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckBankfrst.SelectedIndex >= 0)
            {
                var code = PckBankfrst.SelectedItem as Staticdata;
                RegisterOneVM.Bankcode = code.key;
            }
        }

        private void Pckgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pckgender.SelectedIndex >= 0)
            {
                string gender = Pckgender.Items[Pckgender.SelectedIndex];
                if (gender == "Male")
                {
                    RegisterOneVM.Gender = "M"; 
                }
                else
                {
                    RegisterOneVM.Gender = "F";
                }
                //RegisterOneVM.Gender = Pckgender.Items[Pckgender.SelectedIndex];
            }
        }

        private void MaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckMaritalStatus.SelectedIndex >= 0)
            {
                string status = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
                if (status == "Single")
                {
                    RegisterOneVM.MaritalStatus = "S"; 
                }
                else
                {
                    RegisterOneVM.MaritalStatus = "M"; 
                }
                //RegisterOneVM.MaritalStatus = PckMaritalStatus.Items[PckMaritalStatus.SelectedIndex];
            }
        }
    }
}
