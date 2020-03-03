using MonicaLoanApp.ViewModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            RegisterOneVM = new Register_OneVM(this.Navigation);
            this.BindingContext = RegisterOneVM;
        }
        #endregion

        /// <summary>
        /// TODO:To define back Tap Gesture...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}