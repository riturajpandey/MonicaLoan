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
    public class AddressPageVM : BaseViewModel
    {
        #region Constructor
        public AddressPageVM(INavigation nav)
        {
            Navigation = nav;
            //AddressOne = Helpers.Constants.UserAddressline1;
            //AddressSecond = Helpers.Constants.UserAddressline2;
            //City = Helpers.Constants.UserCity;
           // State = Helpers.Settings.UserStatename;
        }
        #endregion

        #region Properties
        private string _AddressOne;
        public string AddressOne
        {
            get { return _AddressOne; }
            set
            {
                if (_AddressOne != value)
                {
                    _AddressOne = value;
                    OnPropertyChanged("AddressOne");
                }
            }
        }
        private string _AddressSecond;
        public string AddressSecond
        {
            get { return _AddressSecond; }
            set
            {
                if (_AddressSecond != value)
                {
                    _AddressSecond = value;
                    OnPropertyChanged("AddressSecond");
                }
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged("City");
                }
            }
        }
        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged("State");
                }
            }
        }

        private ObservableCollection<Staticdata> _Statelist;
        public ObservableCollection<Staticdata> Statelist
        {
            get { return _Statelist; }
            set
            {
                if (_Statelist != value)
                {
                    _Statelist = value;
                    OnPropertyChanged("Statelist");
                }
            }
        }
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
                var filteredStatelist = Helpers.Constants.StaticDataList.Where(a => a.type == "STATE").ToList();
                Statelist = new ObservableCollection<Staticdata>(filteredStatelist);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion
    }
}
