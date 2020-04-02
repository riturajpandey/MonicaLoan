﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MonicaLoanApp.Utilities
{
    public static class Utility
    {
        public static string ConvertMonthIntoEnglishLanguage(string MonthNameInEnglish)
        {
            string MonthNameInTurkish = string.Empty;
            if (MonthNameInEnglish.Contains("01"))
                MonthNameInTurkish = "Jan";
            if (MonthNameInEnglish.Contains("02"))
                MonthNameInTurkish = "Feb";
            if (MonthNameInEnglish.Contains("03"))
                MonthNameInTurkish = "Mar";
            if (MonthNameInEnglish.Contains("04"))
                MonthNameInTurkish = "Apr";
            if (MonthNameInEnglish.Contains("05"))
                MonthNameInTurkish = "May";
            if (MonthNameInEnglish.Contains("06"))
                MonthNameInTurkish = "Jun";
            if (MonthNameInEnglish.Contains("07"))
                MonthNameInTurkish = "Jul";
            if (MonthNameInEnglish.Contains("08"))
                MonthNameInTurkish = "Aug";
            if (MonthNameInEnglish.Contains("09"))
                MonthNameInTurkish = "Sep";
            if (MonthNameInEnglish.Contains("10"))
                MonthNameInTurkish = "Oct";
            if (MonthNameInEnglish.Contains("11"))
                MonthNameInTurkish = "Nov";
            if (MonthNameInEnglish.Contains("12"))
                MonthNameInTurkish = "Dec";
            return MonthNameInTurkish;
        }

        /// <summary>
        /// TODO : To Generate Image through Base 64...
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static Xamarin.Forms.ImageSource GetImageFromBase64(string base64)
        {
            byte[] Base64Stream = Convert.FromBase64String(base64);
            var image = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            return image;
        }
    }
}
