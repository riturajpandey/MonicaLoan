using MonicaLoanApp.ViewModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            RegisterOneVM = new Register_OneVM(this.Navigation);
            this.BindingContext = RegisterOneVM;
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
            RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

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
                RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Bank.Focus();
        }
        #endregion
    }
}