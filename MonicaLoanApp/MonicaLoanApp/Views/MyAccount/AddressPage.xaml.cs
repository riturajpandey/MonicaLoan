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
    public partial class AddressPage : ContentPage
    {//TODO: To define class level variable..
        protected AddressPageVM AddressVM;
        public AddressPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true); 
            AddressVM = new AddressPageVM(this.Navigation);
            this.BindingContext = AddressVM;

            //AddressVM.State = Helpers.Settings.UserStatename;
            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
            {
                var item = AddressVM.Statelist.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                var index = AddressVM.Statelist.IndexOf(item);
                pckstate.SelectedIndex = index; 
            } 
        }
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await AddressVM.StaticDataSearch();
            AddressVM.AddressOne = Helpers.Constants.UserAddressline1;
            AddressVM.AddressSecond = Helpers.Constants.UserAddressline2;
            AddressVM.City = Helpers.Constants.UserCity;
        }
        #endregion

        private void pckstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckstate.SelectedIndex >= 0)
            {
                var state = pckstate.SelectedItem as Staticdata;
                AddressVM.State = state.key;
            }
        }
    }
}