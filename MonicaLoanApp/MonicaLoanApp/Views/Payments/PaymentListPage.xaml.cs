using MonicaLoanApp.ViewModels.Payments;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentListPage : ContentPage
    {
        PopupMenu Popup;
        /// <summary>
        /// TODO: To define Class level variable.....
        /// </summary>
        protected PaymentPageVM PaymentVM;
        

        #region Constructor
        public PaymentListPage() 
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            PaymentVM = new PaymentPageVM(this.Navigation);
            this.BindingContext = PaymentVM; 
        }
        #endregion

        protected async override void OnAppearing()     
        {
            base.OnAppearing();
            PaymentVM.TapCount = 0;
            PaymentVM.TapCount1 = 0;
            PaymentVM.IsPageEnable = true;
            await PaymentVM.GetPaymentsFromCache(); 
        }

        //TODO : To Define Device Back Button Tapped Event...
        protected override bool OnBackButtonPressed()
        {
            App.masterDetailPage.Master = new MenuPage();
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new YourLoanBalancePage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
            return true;
        }
        private void More_Tapped(object sender, EventArgs e)
        {
            Popup = new PopupMenu()
            {
                BindingContext = PaymentVM.ContextMenu,
            }; 
            Popup.ItemsSource = PaymentVM.ContextMenu;
            Popup.ShowPopup(sender as Image);
            Popup.OnItemSelected += popup_onitemselected;
        }
        private async void popup_onitemselected(string item)
        {
            if (item == "Refresh Payments")
            {  await PaymentVM.GetAllPayments(); }
            if (item == "Make Payment")
            {
                await this.Navigation.PushModalAsync(new MakePaymentPage());
            } 
        } 
    }
}