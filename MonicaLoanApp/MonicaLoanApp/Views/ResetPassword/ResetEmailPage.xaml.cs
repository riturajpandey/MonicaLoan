using MonicaLoanApp.ViewModels.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.ResetPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetEmailPage : ContentPage
    {
        protected EmailResetPageVM EmailResetVM;
        public ResetEmailPage()
        {
            InitializeComponent();
            EmailResetVM = new EmailResetPageVM(this.Navigation);
            this.BindingContext = EmailResetVM;

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}