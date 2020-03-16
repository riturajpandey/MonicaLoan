using MonicaLoanApp.Models;
using System;
using System.Threading.Tasks;

namespace MonicaLoanApp.BuisnessCode
{
    public interface IBusinessCode
    {
        //StaticDataSearch Api 
        Task<StaticDataSearchResponseModel> StaticDataSearchApi(StaticDataSearchRequestModel request, Action<object> success, Action<object> failed);

        #region Register Apis
        //AccessRegisterPreValidate 
        Task<AccessRegisterPreValidateResponseModel> AccessRegisterPreValidateApi(AccessRegisterPreValidateRequestModel request, Action<object> success, Action<object> failed);

        //AccessRegister 
        Task<AccessRegisterResponseModel> AccessRegisterApi(AccessRegisterRequestModel request, Action<object> success, Action<object> failed);
        //AccessRegisterActivateApi 
        Task<AccessRegisterActivateResponseModel> AccessRegisterActivateApi(AccessRegisterActivateRequestModel request, Action<object> success, Action<object> failed);

        #endregion

        #region Login
        //Login Api
        Task<LoginResponseModel> AccessLoginApi(LoginRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region resetpassword
        //StaticDataSearch Api 
        Task<AccessPasswordReminderResponseModel> AccessPasswordReminderApi(AccessPasswordReminderRequestModel request, Action<object> success, Action<object> failed);
        //StaticDataSearch Api 
        Task<AccessPasswordChangeResponseModel> AccessPasswordChangeApi(AccessPasswordChangeRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region Logout
        // Logout Api...
        Task<AccessLogOutResponseModel> AccessLogOutApi(AccessLogOutRequestModel request, Action<object> success, Action<object> failed);
        #endregion
        #region Loan Create Api
        //
        Task<LoanCreateResponseModel> LoanCreateApi(LoanCreateRequestModel request, Action<object> success, Action<object> failed);
        #endregion
    }

}