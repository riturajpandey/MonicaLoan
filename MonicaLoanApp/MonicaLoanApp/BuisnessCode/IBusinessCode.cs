﻿using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.Models.Payments;
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
        Task<AccessLogOutResponseModel> AccessLogOutApi(AccessLogOutRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region LoanSearch 
        Task<LoanSearchResponseModel> LoanSearchApi(LoanSearchRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region Payment 
        Task<PaymentCreateResponseModel> PaymentCreateApi(PaymentCreateRequestModel request, Action<object> success, Action<object> failed);
        #endregion
    }

}