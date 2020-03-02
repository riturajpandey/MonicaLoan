using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels
{
    public class LoginPageVM : BaseViewModel
    {   
        //TODO : To Define Local Class Level Variables..
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        
        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageVM"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public LoginPageVM(INavigation nav)
        {
            Navigation = nav;
            LoginCommand = new Command(LoginAsync);
            ForgotCommand = new Command(ForgotPasswordAasync);
            Register = new Command(RegisterAsync);
        }
        #endregion

        #region Properties
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if(_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if(_Password!= value)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        #endregion

        #region COMMANDS  
        public Command LoginCommand { get; set; }
        public Command ForgotCommand { get; set; }
        public Command Register { get; set; }
        #endregion

        #region Methods

        //Login method Method
        private void LoginAsync(object obj)
        {
            
        }
        //Forgot Password Method
        private void ForgotPasswordAasync(object obj)
        {
            
        }
       // Register Method
        private void RegisterAsync(object obj)
        {
          
        }
        #endregion

    }
}
