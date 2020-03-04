using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        protected MyAccountPageVM MyAccountVM;
        public MyAccountPage()
        {
            InitializeComponent();
            MyAccountVM = new MyAccountPageVM(this.Navigation);
            this.BindingContext = MyAccountVM;
        }
    }
}