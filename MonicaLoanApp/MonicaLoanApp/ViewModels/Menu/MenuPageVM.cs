using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Menu
{
    class MenuPageVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables...  

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPageViewModel"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public MenuPageVM(INavigation nav)
        {
            Navigation = nav; 
        }

        #endregion

        #region DELEGATECOMMAND  

        #endregion

        #region PROPERTIES 
         
        #endregion

        #region Methods

        /// <summary>
        /// TODO : To navigate To Home Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnHomeAsync(object obj)
        {
            //App.masterDetailPage.IsPresented = false;
            //App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new HomePage());
            //App.Current.MainPage = App.masterDetailPage;
            //App.masterDetailPage.IsPresented = false;
        }

        /// <summary>
        /// TODO : To Perform Probe Operations...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnProbeAsync(object obj)
        {
            //    App.masterDetailPage.IsPresented = false;
            //    App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new ProbePage());
            //    App.Current.MainPage = App.masterDetailPage;
            //    App.masterDetailPage.IsPresented = false;
            //}
        }
        #endregion
    }
}
