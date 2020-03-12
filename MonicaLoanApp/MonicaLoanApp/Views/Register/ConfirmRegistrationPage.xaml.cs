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
    public partial class ConfirmRegistrationPage : ContentPage
    {
        protected ConfirmRegistrationVM ConfrmRegistrationvm;
        public ConfirmRegistrationPage()
        {
            InitializeComponent();
            ConfrmRegistrationvm = new ConfirmRegistrationVM(this.Navigation);
            this.BindingContext = ConfrmRegistrationvm;
        }
    }
}