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
            if (!string.IsNullOrEmpty(Helpers.Settings.UserStatename))
            {
                var item = AddressVM.Statelist.Where(a => a.data == Helpers.Settings.UserStatename).FirstOrDefault();
                var index = AddressVM.Statelist.IndexOf(item);
                MaritalStatus.SelectedItem = index;
            } 
        }
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await AddressVM.StaticDataSearch();
        }
        #endregion

    }
}