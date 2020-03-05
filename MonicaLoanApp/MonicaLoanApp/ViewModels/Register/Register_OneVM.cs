using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Register
{
    public class Register_OneVM: BaseViewModel
    {
        //TODO : To Define Local Class Level Variables..
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        
        #region Constructor
        public Register_OneVM(INavigation nav)
        {
            Navigation = nav;
            NextCommand = new Command(NextCommandAsync);
            SecondNextCommand = new Command(SecondNextCommandAsync);
            FinishCommand = new Command(FinishCommandAsync);
            BckCommand = new Command(BckCommandAsync);
        }
        #endregion

        #region Properties
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

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set
            {
                if (_NewPassword != value)
                {
                    _NewPassword = value;
                    OnPropertyChanged("NewPassword");
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
        private bool _FirstGrid = true;
        public bool FirstGrid
        {
            get { return _FirstGrid; }
            set
            {
                if (_FirstGrid != value)
                {
                    _FirstGrid = value;
                    OnPropertyChanged("FirstGrid");
                }
            }
        }

        private bool _SecondGrid = false;
        public bool SecondGrid
        {
            get { return _SecondGrid; }
            set
            {
                if (_SecondGrid != value)
                {
                    _SecondGrid = value;
                    OnPropertyChanged("SecondGrid");
                }
            }
        }
        private bool _FinalGrid = false;
        public bool FinalGrid
        {
            get { return _FinalGrid; }
            set
            {
                if (_FinalGrid != value)
                {
                    _FinalGrid = value;
                    OnPropertyChanged("FinalGrid");
                }
            }
        }
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



        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged("Number");
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

        private string _BusinessNumber;
        public string BusinessNumber
        {
            get { return _BusinessNumber; }
            set
            {
                if (_BusinessNumber != value)
                {
                    _BusinessNumber = value;
                    OnPropertyChanged("BusinessNumber");
                }
            }
        }

        private string _BankPicker;
        public string BankPicker
        {
            get { return _BankPicker; }
            set
            {
                if (_BankPicker != value)
                {
                    _BankPicker = value;
                    OnPropertyChanged("BankPicker");
                }
            }
        }

        private string _AccountNumber;
        public string AccountNumber
        {
            get { return _AccountNumber; }
            set
            {
                if (_AccountNumber != value)
                {
                    _AccountNumber = value;
                    OnPropertyChanged("AccountNumber");
                }
            }
        }




        #endregion

        #region Commands 
        public Command NextCommand { get; set; }
        public Command SecondNextCommand { get; set; }
        public Command FinishCommand { get; set; }
        public Command BckCommand { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// TODO: Define BackCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private void BckCommandAsync(object obj)
        {

            if (FinalGrid == true)
            {
                SecondGrid = true;
                FirstGrid = false;
                FinalGrid = false;
            }
            else if (SecondGrid == true)
            {
                FirstGrid = true;
                SecondGrid = false;
                FinalGrid = false;
            }
            else if (FirstGrid == true)
            {
                Navigation.PopModalAsync();
            }

        }

        /// <summary>
        /// TODO: Define NextCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private async void NextCommandAsync(object obj)
        {
            if (!await SignupValidate())
            {
                return;
            }
            else
            {
                FirstGrid = false;
                SecondGrid = true;
                FinalGrid = false;
            }
        }
        /// <summary>
        /// TODO: Define SecondNextCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private async void SecondNextCommandAsync(object obj)
        {
            if (!await SecondSignValidate())
            {
                return;
            }
            else
            {
                FirstGrid = false;
                SecondGrid = false;
                FinalGrid = true;
            }
        }
        /// <summary>
        /// TODO: Define FinishCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private async void FinishCommandAsync(object obj)
        {
            if (!await FinishSignUpValidate())
            {
                BusinessNumber = string.Empty;
                AccountNumber = string.Empty;
            };
        }
        #region Check Validate All Fields
        /// <summary>
        /// TODO : To Apply SignupValidations...
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SignupValidate()
        {
            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(NewPassword))
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("All fields are required.");
                return false;
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                UserDialog.HideLoading();
                UserDialogs.Instance.Alert("Please enter First Name");
                return false;
            }
            if (string.IsNullOrEmpty(MiddleName))
            {
                UserDialog.HideLoading();
                UserDialogs.Instance.Alert("Please enter Middle Name");
                return false;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                UserDialog.HideLoading();
                UserDialogs.Instance.Alert("Please enter Last Name");
                return false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter email.");
                return false;
            }
            bool isValid4 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid4)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Email is not valid.");
                return false;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter password.");
                return false;
            }
            UserDialogs.Instance.HideLoading();
            return true;
        }
        private async Task<bool> SecondSignValidate()
        {
            if (string.IsNullOrEmpty(Number))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Number.");
                return false;
            }
            UserDialogs.Instance.HideLoading();
            return true;
        }
        private async Task<bool> FinishSignUpValidate()
        {
            if (string.IsNullOrEmpty(BusinessNumber))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Bvn Number.");
                return false;
            }
            if (string.IsNullOrEmpty(AccountNumber))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Account Number.");
                return false;
            }
            UserDialogs.Instance.HideLoading();
            return true;
        }

        #endregion
        #endregion
    }
}
