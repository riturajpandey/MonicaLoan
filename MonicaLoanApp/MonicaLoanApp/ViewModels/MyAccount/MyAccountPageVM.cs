using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class MyAccountPageVM : BaseViewModel
    {
        #region Constructor
        public MyAccountPageVM(INavigation nav)
        {
            Navigation = nav;
            PersonalDetailsCommand = new Command(PersonalDetailsCommandAsync);
            AddressCommand = new Command(AddressCommandAsync);
            EmployementCommand = new Command(EmployementCommandAsync);
            BankDetailsCommand = new Command(BankDetailsCommandAsync);
            logoutCommand = new Command(logoutCommandAsync);
        }

       
        #endregion

        #region Properties
        private string _PersonalDetails = "Joe Bloggs";
        public string PersonalDetails
        {
            get { return _PersonalDetails; }
            set
            {
                if(_PersonalDetails!= value)
                {
                    _PersonalDetails = value;
                    OnPropertyChanged("PersonalDetails");
                }
            }
        }

        private string _Address = "15, Bale Street, Lekki, London.";
        public string Address
        {
            get { return _Address; }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private string _Employement= "Joe Bloggs";
        public string Employement
        {
            get { return _Employement; }
            set
            {
                if(_Employement!= value)
                {
                    _Employement = value;
                    OnPropertyChanged("Employement");
                }
            }
        }

        private string _BankDetails = "Royal Bank 87413232";
        public string BankDetails
        {
            get { return _BankDetails; }
            set
            {
                if (_BankDetails != value)
                {
                    _BankDetails = value;
                    OnPropertyChanged("BankDetails");
                }
                
            }
        }
        #endregion

        #region Commands
        public Command PersonalDetailsCommand { get; set; }
        public Command AddressCommand { get; set; }
        public Command EmployementCommand { get; set; }
        public Command BankDetailsCommand { get; set; }
        public Command settingCommand { get; set; }
        public Command logoutCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// TODO: To define logoutCommand.
        /// </summary>
        /// <param name="obj"></param>
        private void logoutCommandAsync(object obj)
        {
            App.Current.MainPage = new Views.Login.LoginPage();
        }
        /// <summary>
        /// TODO: To define BankDetailsCommand.
        /// </summary>
        /// <param name="obj"></param>
        private void BankDetailsCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.MyAccount.BankPage());
        }
        /// <summary>
        /// TODO: To define EmployementCommand.
        /// </summary>
        /// <param name="obj"></param>
        private void EmployementCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.MyAccount.EmployementPage());
          
        }
        /// <summary>
        /// TODO: To define AddressCommand.
        /// </summary>
        /// <param name="obj"></param>
        private void AddressCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.MyAccount.AddressPage());
        }
        /// <summary>
        /// TODO: To define PersonalDetails.
        /// </summary>
        /// <param name="obj"></param>
        private void PersonalDetailsCommandAsync(object obj)
        {
            Navigation.PushModalAsync(new Views.MyAccount.Personal_Details());
        }
        #endregion
    }
}
