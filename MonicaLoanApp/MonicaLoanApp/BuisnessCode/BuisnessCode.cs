using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Providers;
using MonicaLoanApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonicaLoanApp.BuisnessCode
{
    public class BuisnessCode : IBusinessCode
    {
        IApiProvider _apiProvider;

        public BuisnessCode(IApiProvider apiProvider)
        {
            //To initialize service providers...
            _apiProvider = apiProvider;
        }

        

        #region StaticDataSearchApi
        public async Task<StaticDataSearchResponseModel> StaticDataSearchApi(StaticDataSearchRequestModel request, Action<object> success, Action<object> failed)
        {
            StaticDataSearchResponseModel resmodel = new StaticDataSearchResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/StaticDataSearch", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", "dcdscfdscds");
                var result = _apiProvider.Post<StaticDataSearchResponseModel, StaticDataSearchRequestModel>(url, request, dic);
                var response = result.Result;
                StaticDataSearchResponseModel objres = null;
                dynamic obj = "";
                StaticDataSearchResponseModel reg = new StaticDataSearchResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<StaticDataSearchResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
            }
            return resmodel;

        }
        #endregion

        #region Register Apis 
        /// <summary>
        /// Call This Api For AccessRegisterPreValidate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessRegisterPreValidateResponseModel> AccessRegisterPreValidateApi(AccessRegisterPreValidateRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterPreValidateResponseModel resmodel = new AccessRegisterPreValidateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegisterPreValidate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash","hS9NwfFvC; Z`~bUE'vqE7-#y");
                var result = _apiProvider.Post<AccessRegisterPreValidateResponseModel, AccessRegisterPreValidateRequestModel>(url, request, dic);

                var response = result.Result;
                AccessRegisterPreValidateResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterPreValidateResponseModel reg = new AccessRegisterPreValidateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterPreValidateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
            }
            return resmodel;

        }
        /// <summary>
        /// Call This Api For AccessRegisterApi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessRegisterResponseModel> AccessRegisterApi(AccessRegisterRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterResponseModel resmodel = new AccessRegisterResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegister", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", "xyz123");
                var result = _apiProvider.Post<AccessRegisterResponseModel, AccessRegisterRequestModel>(url, request, dic);
                var response = result.Result;
                AccessRegisterResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterResponseModel reg = new AccessRegisterResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
            }
            return resmodel;
        }

        public async Task<AccessRegisterActivateResponseModel> AccessRegisterActivateApi(AccessRegisterActivateRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterActivateResponseModel resmodel = new AccessRegisterActivateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegisterActivate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", "xyz123");
                var result = _apiProvider.Post<AccessRegisterActivateResponseModel, AccessRegisterActivateRequestModel>(url, request, dic);
                var response = result.Result;
                AccessRegisterActivateResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterActivateResponseModel reg = new AccessRegisterActivateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterActivateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
            }
            return resmodel;
        }

        public async Task<LoginResponseModel> AccessLoginApi(LoginRequestModel request, Action<object> success, Action<object> failed)
        {
            LoginResponseModel resmodel = new LoginResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessLogin", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", "xyz123");
                var result = _apiProvider.Post<LoginResponseModel, LoginRequestModel>(url, request, dic);
                var response = result.Result;
                LoginResponseModel objres = null;
                dynamic obj = "";
                LoginResponseModel reg = new LoginResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<LoginResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "Alert", "OK");
            }
            return resmodel;
        }
        #endregion
    }
}
