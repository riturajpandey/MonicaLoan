using MonicaLoanApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    { 
        //TODO : To Define class Level Variables...
        protected LoginPageVM loginPageVm;
        public LoginPage()
        {
            InitializeComponent();
            loginPageVm = new LoginPageVM(this.Navigation);
            this.BindingContext = loginPageVm;
        }
    }
}