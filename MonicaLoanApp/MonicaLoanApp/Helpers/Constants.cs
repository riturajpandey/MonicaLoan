using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MonicaLoanApp.Helpers
{
    public class Constants
    {
        //To maintain user toekn..
        public static string UserToken = string.Empty;
        //To maintain user toekn..
        public static string LoginUserToken = string.Empty;
        //To maintain user toekn..
        public static string LoginUserSecret = string.Empty;

        //To maintain variable for image from camera/gallery
        public static string imgFilePath = string.Empty;
        //To maintain variable for Media picker selected items
        public static string PartImageBase64 = string.Empty;
        public static string LoanSubmitSms = string.Empty;

        public static ObservableCollection<Staticdata> StaticDataList = new ObservableCollection<Staticdata>();
    }
}
