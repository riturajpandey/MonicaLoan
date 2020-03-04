using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.Models
{
    public class LoanDetailsModel : BindableObject
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string AmtDate { get; set; }

    }
}
