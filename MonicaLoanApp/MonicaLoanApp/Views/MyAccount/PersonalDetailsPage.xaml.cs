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
            PersonalDetailsVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

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
                PersonalDetailsVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

            }
        }
        #endregion
    }
}