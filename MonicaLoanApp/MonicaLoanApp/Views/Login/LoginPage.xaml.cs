using MonicaLoanApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    { 
        //TODO : To Define class Level Variables...
        protected LoginPageVM LoginVm;
        public LoginPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoginVm = new LoginPageVM(this.Navigation);
            this.BindingContext = LoginVm;
        }
    }
}