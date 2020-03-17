using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// Checking
    /// </summary> 
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string AccessToken = "AccessToken";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string LoanNumber = "LoanNumber";
        private static readonly string LoanNumberDefault = string.Empty;

        //private const string LoanBalance = "LoanBalance";
        //private static readonly string LoanBalanceDefault = string.Empty;

        //private const string DueBalance = "DueBalance";
        //private static readonly string DueBalanceDefault = string.Empty;

        //private const string Firstname = "Firstname";
        //private static readonly string FirstnameDefault = string.Empty;

        //private const string Middlename = "Middlename";
        //private static readonly string MiddlenameDefault = string.Empty;

        //private const string Lastname = "Lastname";
        //private static readonly string LastnameDefault = string.Empty;

        //private const string Emailaddress = "Emailaddress";
        //private static readonly string EmailaddressDefault = string.Empty;

        //private const string Mobileno = "Mobileno";
        //private static readonly string MobilenoDefault = string.Empty;

        //private const string Gender = "Gender";
        //private static readonly string GenderDefault = string.Empty;

        //private const string Maritalstatus = "Maritalstatus";
        //private static readonly string MaritalstatusDefault = string.Empty;

        //private const string Dateofbirth = "Dateofbirth";
        //private static readonly string DateofbirthDefault = string.Empty;

        //private const string Bvn = "Bvn";
        //private static readonly string BvnDefault = string.Empty;

        //private const string Bankcode = "Bankcode";
        //private static readonly string BankcodeDefault = string.Empty;

        //private const string Bankname = "Bankname";
        //private static readonly string BanknameDefault = string.Empty;

        //private const string Bankaccountno = "Bankaccountno";
        //private static readonly string BankaccountnoDefault = string.Empty;

        //private const string Addressline1 = "Addressline1";
        //private static readonly string Addressline1Default = string.Empty;

        //private const string Addressline2 = "Addressline2";
        //private static readonly string Addressline2Default = string.Empty;

        //private const string City = "City";
        //private static readonly string CityDefault = string.Empty;
        
        //private const string Statecode = "Statecode";
        //private static readonly string StatecodeDefault = string.Empty;
        
        //private const string Statename = "Statename";
        //private static readonly string StatenameDefault = string.Empty;
        
        //private const string Employercode = "Employercode";
        //private static readonly string EmployercodeDefault = string.Empty;
        
        //private const string Employername = "Employername";
        //private static readonly string EmployernameDefault = string.Empty;
        
        //private const string Employeenumber = "Employeenumber";
        //private static readonly string EmployeenumberDefault = string.Empty;
        
        //private const string Salary = "Salary";
        //private static readonly string SalaryDefault = string.Empty;
        
        //private const string Startdate = "Startdate";
        //private static readonly string StartdateDefault = string.Empty;
        
        //private const string Profilepic = "Profilepic";
        //private static readonly string ProfilepicDefault = string.Empty;


        public static string GeneralAccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessToken, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessToken, value);
            }
        }
        public static string GeneralLoanNumber
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoanNumber, LoanNumberDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoanNumber, value);
            }
        }
        //public static string UserLoanBalance
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(LoanBalance, LoanBalanceDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(LoanBalance, value);
        //    }
        //}
        //public static string UserDueBalance
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(DueBalance, DueBalanceDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(DueBalance, value);
        //    }
        //}
        //public static string UserFirstname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Firstname, FirstnameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Firstname, value);
        //    }
        //}
        //public static string UserMiddlename
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Middlename, MiddlenameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Middlename, value);
        //    }
        //}
        //public static string UserLastname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Lastname, LastnameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Lastname, value);
        //    }
        //}
        //public static string UserEmailaddress
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Emailaddress, EmailaddressDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Emailaddress, value);
        //    }
        //}
        //public static string UserMobileno
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Mobileno, MobilenoDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Mobileno, value);
        //    }
        //}
        //public static string UserGender
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Gender, GenderDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Gender, value);
        //    }
        //}
        //public static string UserMaritalstatus
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Maritalstatus, MaritalstatusDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Maritalstatus, value);
        //    }
        //}
        //public static string UserBvn
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bvn, BvnDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bvn, value);
        //    }

        //}
        //public static string UserDateofbirth
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Dateofbirth, DateofbirthDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Dateofbirth, value);
        //    }
        //}
        //public static string UserBankcode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankcode, BankcodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankcode, value);
        //    }
        //}
        //public static string UserBankname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankname, BanknameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankname, value);
        //    }
        //}
        //public static string UserBankaccountno
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankaccountno, BankaccountnoDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankaccountno, value);
        //    }
        //}
        //public static string UserAddressline1
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Addressline1, Addressline1Default);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Addressline1, value);
        //    }
        //}
        //public static string UserAddressline2
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Addressline2, Addressline2Default);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Addressline2, value);
        //    }
        //}
        //public static string UserCity
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(City, CityDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(City, value);
        //    }
        //}
        //public static string UserStatecode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Statecode, StatecodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Statecode, value);
        //    }
        //} 
        //public static string UserStatename
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Statename, StatenameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Statename, value);
        //    }
        //}
        //public static string UserEmployercode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employercode, EmployercodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employercode, value);
        //    }
        //}
        //public static string UserEmployername
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employername, EmployernameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employername, value);
        //    }
        //}
        //public static string UserEmployeenumber
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employeenumber, EmployeenumberDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employeenumber, value);
        //    }
        //}
        //public static string UserSalary
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Salary, SalaryDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Salary, value);
        //    }
        //}
        //public static string UserStartdate
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Startdate, StartdateDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Startdate, value);
        //    }
        //}
        //public static string UserProfilepic
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Profilepic, ProfilepicDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Profilepic, value);
        //    }
        //}
        #endregion

    }
}
