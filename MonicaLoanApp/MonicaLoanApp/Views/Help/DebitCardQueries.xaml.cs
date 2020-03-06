using MonicaLoanApp.Models.Help;
using MonicaLoanApp.ViewModels.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebitCardQueries : ContentPage
    {
        //TODO: To define class level variable
        protected DebitCardQueriesVM DebitCardVM;
        public HelpListModel _helpListModel;

        #region Constructor
        public DebitCardQueries(HelpListModel helpListModel)
        {
            InitializeComponent();
            DebitCardVM = new DebitCardQueriesVM(this.Navigation);
            this.BindingContext = DebitCardVM;
            _helpListModel = helpListModel;
            DebitCardVM.Question = _helpListModel.Question;
            DebitCardVM.Answer = _helpListModel.Answer;

        }
        #endregion
    }
}