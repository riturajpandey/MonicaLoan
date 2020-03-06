using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Help
{
    public class DebitCardQueriesVM : BaseViewModel
    {
        #region Constructor
        public DebitCardQueriesVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _Question;
        public string Question
        {
            get { return _Question; }
            set
            {
                if(_Question != value)
                {
                    _Question = value;
                    OnPropertyChanged("Question");
                }
            }
        }
        private string _Answer;
        public string Answer
        {
            get { return _Answer; }
            set
            {
                if (_Answer != value)
                {
                    _Answer = value;
                    OnPropertyChanged("Answer");
                }
            }
        }
        #endregion

    }
}
