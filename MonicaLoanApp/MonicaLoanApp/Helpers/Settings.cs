﻿using Plugin.Settings;
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

        private const string UserToken = "UserToken";
        private static readonly string UserTokenDefault = string.Empty;

        private const string ProfilePic = "ProfilePic";
        private static readonly string ProfilePicDefault = string.Empty;

        private const string AccessToken = "AccessToken";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string LoanNumber = "LoanNumber";
        private static readonly string LoanNumberDefault = string.Empty;

        private const string StaticDataResponse = "StaticDataResponse";
        private static readonly string StaticDataResponseDefault = string.Empty;

        private const string UserProfileResponse = "UserProfileResponse";
        private static readonly string UserProfileResponseDefault = string.Empty;

        private const string AllLoanResponse = "AllLoanResponse";
        private static readonly string AllLoanResponseDefault = string.Empty;

        private const string UserLoanDetailResponse = "UserLoanDetailResponse";
        private static readonly string UserLoanDetailResponseDefault = string.Empty;

        private const string AllPaymentResponse = "AllPaymentResponse";
        private static readonly string AllPaymentResponseDefault = string.Empty;

        public static string GeneralProfilePic
        {
            get
            {
                return AppSettings.GetValueOrDefault(ProfilePic, ProfilePicDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ProfilePic, value);
            }

        }
        public static string GeneralUserToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserToken, UserTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserToken, value);
            }
        }

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
        public static string GeneralStaticDataResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(StaticDataResponse, StaticDataResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(StaticDataResponse, value);
            }
        }

        public static string GeneralUserProfileResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserProfileResponse, UserProfileResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserProfileResponse, value);
            }
        }

        public static string GeneralAllLoanResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllLoanResponse, AllLoanResponseDefault); 
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllLoanResponse, value);
            }
        }

        public static string GeneralUserLoanDetailResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserLoanDetailResponse, UserLoanDetailResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserLoanDetailResponse, value);
            }
        }

        public static string GeneralAllPaymentResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllPaymentResponse, AllPaymentResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllPaymentResponse, value);
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


        #region JSONS

        private const string ProfileData = "ProfileData";
        private static readonly string ProfileDataDefault = string.Empty;

        public static string GeneralProfileDataJSON
        {
            get
            {
                return AppSettings.GetValueOrDefault(ProfileData, ProfileDataDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ProfileData, value);
            }
        }
        #endregion

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

        #region Notification Settings
        private const string IsNotification = "IsNotification";
        private static readonly string IsNotificationDefault = string.Empty;

        private const string IsSound = "IsSound";
        private static readonly string IsSoundDefault = string.Empty;

        private const string IsVibrate = "IsVibrate";
        private static readonly string IsVibrateDefault = string.Empty;

        public static string GeneralIsNotification
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsNotification, IsNotificationDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsNotification, value);
            }
        }

        public static string GeneralIsSound
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsSound, IsSoundDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsSound, value);
            }
        }

        public static string GeneralIsVibrate
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsVibrate, IsVibrateDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsVibrate, value);
            }
        }
        #endregion


    }
}
