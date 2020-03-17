using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class Personal_DetailsVM : BaseViewModel
    {
        #region Constructor
        public Personal_DetailsVM(INavigation nav)
        {
            Navigation = nav;
            SaveCommand = new Command(SaveCommandAsync);
            FirstName = Helpers.Settings.UserFirstname +" "+ Helpers.Settings.UserLastname;
            Email = Helpers.Settings.UserEmailaddress;
            DateOfBirth = Helpers.Settings.UserDateofbirth;
            Gender = Helpers.Settings.UserGender;
            MaritalStatus = Helpers.Settings.UserMaritalstatus;
        } 

       
        #endregion

        #region Properties
        private string _DateOfBirth = "Date of birth";
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if (_DateOfBirth != value)
                {
                    _DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set
            {
                if (_MaritalStatus != value)
                {
                    _MaritalStatus = value;
                    OnPropertyChanged("MaritalStatus");
                }
            }
        }
        #endregion

        #region Command
        public Command SaveCommand { get; set; }
        #endregion

        #region Method
        private void SaveCommandAsync(object obj)
        {
            
        }
        #endregion
    }
}
