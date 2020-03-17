using MonicaLoanApp.Models;
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
    public partial class EmployementPage : ContentPage
    {
        /// <summary>
        /// TODO: TO define class level variable...
        /// </summary>
        protected EmployementPageVM EmployementVM;
        #region Constructor
        public EmployementPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            EmployementVM = new EmployementPageVM(this.Navigation);
            this.BindingContext = EmployementVM;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await EmployementVM.StaticDataSearch();
            EmployementVM.EnterEmpNo = Helpers.Constants.UserEmployeenumber;
            EmployementVM.EnterSalary = Helpers.Constants.UserSalary;
            EmployementVM.DateOfBirth=Helpers.Constants.UserDateofbirth;
            

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
                    EmployementVM.DateOfBirth = DateBirth;
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
                    EmployementVM.DateOfBirth = DateBirth;

                }
            }
            catch (Exception ex)
            { }
        }
        private void Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckEmployee.SelectedIndex >= 0)
            {
                var EmployerCode = PckEmployee.SelectedItem as Staticdata;
                EmployementVM.EmployerCode = EmployerCode.key;
            }
        }
        #endregion


    }
}