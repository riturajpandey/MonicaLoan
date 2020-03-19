using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Loan
{
    public class AllLoanRequestModel
    {
        public string usertoken { get; set; } 
    }

    public class AllLoanResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<AllLoan> loans { get; set; } 
    }
    public class AllLoan 
    {
        public string loannumber { get; set; }
        public string loanamount { get; set; }
        public string datecreated { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }

        //public string LoanDate
        //{
        //    get
        //    {
        //        DateTime date ;
        //        string loanDate = string.Empty;
        //        date = Convert.ToDateTime( datecreated);
        //        loanDate = date.ToString("d MMM yyyy"); 
        //        return loanDate;
        //    }
        //}
    }
}
