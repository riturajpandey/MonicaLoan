using MonicaLoanApp.Models;
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
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await BankVM.StaticDataSearch();
            
            BankVM.BankAccountNumber = Helpers.Constants.UserBankaccountno;
            BankVM.EnterBVN = Helpers.Constants.UserBvn;
        }
        #endregion

        private void PckSelectbankCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckBankfrst.SelectedIndex >= 0)
            {
                var code = PckBankfrst.SelectedItem as Staticdata;
                BankVM.Bankcode = code.key;
            }
        }
    }
}