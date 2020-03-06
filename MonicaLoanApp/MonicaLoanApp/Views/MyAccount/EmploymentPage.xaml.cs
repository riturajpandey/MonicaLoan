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
            EmployementVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        {
            if (DtPckDOB.Date != null)
            {
                EmployementVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

            }
        }
        #endregion
    }
}