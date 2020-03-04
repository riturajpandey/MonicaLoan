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
    public partial class ResetEmailPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected EmailResetPageVM EmailResetVM;
        public ResetEmailPage()
        {
            InitializeComponent();
            EmailResetVM = new EmailResetPageVM(this.Navigation);
            this.BindingContext = EmailResetVM;
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PopModalAsync();
        //}
    }
}