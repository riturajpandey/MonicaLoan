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
    public class BankPageVM : BaseViewModel
    {
        #region Constructor
        public BankPageVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _BankAccountNumber;
        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set
            {
                if (_BankAccountNumber != value)
                {
                    _BankAccountNumber = value;
                    OnPropertyChanged("BankAccountNumber");
                }
            }

        }
        private string _EnterBVN;
        public string EnterBVN
        {
            get { return _EnterBVN; }
            set
            {
                if (_EnterBVN != value)
                {
                    _EnterBVN = value;
                    OnPropertyChanged("EnterBVN");
                }
            }
        }
        private ObservableCollection<Staticdata> _Banklist;
        public ObservableCollection<Staticdata> Banklist
        {
            get { return _Banklist; }
            set
            {
                if (_Banklist != value)
                {
                    _Banklist = value;
                    OnPropertyChanged("Banklist");
                }
            }
        }
        public string Bankcode { get; set; }
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
                var filteredBankList = Helpers.Constants.StaticDataList.Where(a => a.type == "BANK").ToList();
                Banklist = new ObservableCollection<Staticdata>(filteredBankList);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion
    }
}
