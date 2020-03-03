using MonicaLoanApp.ViewModels.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.ResetPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePasswordPage : ContentPage
    {
        protected UpdatePasswordPageVM NewPasswordVM;
        public UpdatePasswordPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            NewPasswordVM = new UpdatePasswordPageVM(this.Navigation);
            this.BindingContext = NewPasswordVM;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}