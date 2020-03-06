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
    public partial class BankPage : ContentPage
    {
        //TODO: To define class level variable...
        protected BankPageVM BankVM;

        #region Constructor
        public BankPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BankVM = new BankPageVM(this.Navigation);
            this.BindingContext = BankVM;
        }
        #endregion
    }
}