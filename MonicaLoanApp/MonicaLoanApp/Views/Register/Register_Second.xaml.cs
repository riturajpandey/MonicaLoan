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
    public partial class Register_Second : ContentPage
    {
        public Register_Second()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}