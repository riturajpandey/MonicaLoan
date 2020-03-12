using MonicaLoanApp.Models;
using System;
using System.Threading.Tasks;

namespace MonicaLoanApp.BuisnessCode
{
    public interface IBusinessCode
    {
        //StaticDataSearch Api 
        Task<StaticDataSearchResponseModel> StaticDataSearch(StaticDataSearchRequestModel request, Action<object> success, Action<object> failed);

        #region Register Apis
        //AccessRegisterPreValidate 
        Task<AccessRegisterPreValidateResponseModel> AccessRegisterPreValidateApi(AccessRegisterPreValidateRequestModel request, Action<object> success, Action<object> failed);

        //AccessRegister 
        Task<AccessRegisterResponseModel> AccessRegisterApi(AccessRegisterRequestModel request, Action<object> success, Action<object> failed);
        //AccessRegisterActivateApi 
        Task<AccessRegisterActivateResponseModel> AccessRegisterActivateApi(AccessRegisterActivateRequestModel request, Action<object> success, Action<object> failed);

        #endregion    
    }
}