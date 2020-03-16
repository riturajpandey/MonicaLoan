using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Loan
{
    public class LoanSearchRequestModel
    {
        public string usertoken { get; set; }
        public string loannumber { get; set; } 
    }

    public class LoanSearchResponseModel 
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<Loan> loans { get; set; }
    }

    public class Loan
    {
        public string loannumber { get; set; }
        public string loanamount { get; set; }
        public string datecreated { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }
        public string loaninterestrate { get; set; }
        public string loaninterest { get; set; }
        public string loanbalance { get; set; }
        public string loantotal { get; set; }
        public string purposecode { get; set; }
        public string purposename { get; set; }
        public string durationperiod { get; set; }
        public string durationtotal { get; set; }
        public string employeesalarymonthly { get; set; }
        public string employercode { get; set; }
        public string employername { get; set; }
        public string employeenumber { get; set; }
        public string __invalid_name__employeestartdate { get; set; }
        public string __invalid_name__repaymenttypecode { get; set; }
        public string repaymenttypename { get; set; }
        public string declinereasoncode { get; set; }
        public string declinereasonname { get; set; }
        public string declinereasoncomments { get; set; }
        public List<Schedule> schedules { get; set; }
    }

    public class Schedule
    {
        public string loanschedulenumber { get; set; }
        public string amounttotal { get; set; }
        public string duedate { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }
    }
}
