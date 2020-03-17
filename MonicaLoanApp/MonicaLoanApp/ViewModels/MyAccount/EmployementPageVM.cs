using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class EmployementPageVM : BaseViewModel
    {
        #region Constructor
        public EmployementPageVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _DateOfBirth = "Date of Birth";
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
        private string _EnterEmpNo;
        public string EnterEmpNo
        {
            get { return _EnterEmpNo; }
            set
            {
                if (_EnterEmpNo != value)
                {
                    _EnterEmpNo = value;
                    OnPropertyChanged("EnterEmpNo");
                }
            }
        }
        private string _EnterSalary;
        public string EnterSalary
        {
            get { return _EnterSalary; }
            set
            {
                if (_EnterSalary != value)
                {
                    _EnterSalary = value;
                    OnPropertyChanged("EnterSalary");
                }
            }
        }
        private ObservableCollection<Staticdata> _EmpCode;
        public ObservableCollection<Staticdata> EmpCode
        {
            get { return _EmpCode; }
            set
            {
                if (_EmpCode != value)
                {
                    _EmpCode = value;
                    OnPropertyChanged("EmpCode");
                }
            }
        }
        public string EmployerCode { get; set; }
        #endregion

        #region Commands
        #endregion

        #region Methods
        /// <summary>
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            //Fileter Bank List From Static Data List..
            try
            {
                var EmployerList = Helpers.Constants.StaticDataList.Where(a => a.type == "EMPLOYER").ToList();
                EmpCode = new ObservableCollection<Staticdata>(EmployerList);

            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion
    }
}