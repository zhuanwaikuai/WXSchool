using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using QJZ.Framework.Utility;
using TCBase.Saker.Core;
using WXSchool.Dal.Sys;
using WXSchool.Model;
using WXSchool.ViewModel;

namespace WeiXin.Bll
{
    public class WeiXinBiz
    {
        #region 服务器验证
        /// <summary>
        /// 成为开发者的第一步，验证并相应服务器的数据
        /// </summary>
        public static void Auth()
        {
            string token = AppSettingsHelper.GetString("WeixinToken");//从配置文件获取Token
            if (string.IsNullOrEmpty(token))
            {
                Log4Helper.Write(string.Format("WeixinToken 配置项没有配置！"), LogMessageType.Error);
            }

            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echoString))
                {
                    HttpContext.Current.Response.Write(echoString);
                    HttpContext.Current.Response.End();
                }
            }
        }

        /// <summary>
        /// 验证微信签名
        /// </summary>
        private static bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            //将token、timestamp、nonce三个参数进行字典序排序
            string[] arrTmp = { token, timestamp, nonce };
            Array.Sort(arrTmp);
            string tmpStr = string.Join("", arrTmp);

            //将三个参数字符串拼接成一个字符串进行sha1加密
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();

            //开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 全局Access_Token
        /// <summary>
        /// 根据当前日期 判断Access_Token 是否超期  如果超期返回新的Access_Token   否则返回之前的Access_Token 
        /// </summary>
        /// <returns></returns>
        public static string GetExistAccessToken(SysAccessToken exist)
        {
            string token = exist.access_token;
            DateTime lastTime = exist.LastTime;

            if (DateTime.Now >= lastTime)
            {
                //重新获取
                lastTime = DateTime.Now;
                var newToken = GetAccessToken(exist.AppID, exist.AppSecret);
                lastTime = lastTime.AddSeconds(newToken.expires_in);
                //入库
                exist.LastTime = lastTime;
                exist.access_token = newToken.access_token;
                exist.expires_in = newToken.expires_in;
                ClassFactory.GetInstance<SysAccessTokenRespository>().Modify(exist);

                token = newToken.access_token;
            }

            return token;
        }

        private static SysAccessToken GetAccessToken(string appId, string appSecret)
        {
            string url = string.Format(AuthorizeUrl.GetTokenUrl(),appId,appSecret);
            return NetHelper.HttpGet<SysAccessToken>(url, SerializationType.Json);
        }

        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <returns></returns>
        //private string GetJsApiTicket()
        //{
        //    string ticket = string.Empty;
        //    var cacheKey = "TCWIRELESS.OPERATION.WeiXin.JsApiTicket";
        //    //先从缓存取，并判断是否过期
        //    var cacheValue = CacheHelper.GetValue<WXTokenModel>(cacheKey);
        //    if (cacheValue != null
        //        && DateTime.Now < cacheValue.OverTime)
        //    {
        //        return cacheValue.Ticket;
        //    }

        //    var token = GetAccessToken();
        //    var now = DateTime.Now;
        //    var url = string.Format(TicketUrl, token);
        //    var request = new TCHttpRequest(url);
        //    var result = request.PostDataToServer(HttpRequestMethod.Get, "utf-8");
        //    var model = JsonConvert.DeserializeObject<WXTokenModel>(result);
        //    model.OverTime = now.AddSeconds(model.Expires_In);
        //    CacheHelper.Set(cacheKey, model, TimeSpan.FromSeconds(model.Expires_In));
        //    ticket = model.Ticket;
        //    return ticket;
        //}

        /// <summary>
        /// 获取JsApi配置信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        //public virtual WXJsApiTicketModel GetWXJsApiConfig(string url)
        //{
        //    var model = new WXJsApiTicketModel
        //    {
        //        AppId = AppId,
        //        TimeStamp = DateTime.Now.ToTimeStamp(),//1414587457,
        //        NonceStr = Guid.NewGuid().ToString("N")//"Wm3WZYTPz0wzccnW"
        //    };
        //    var ticket = GetJsApiTicket();//"sM4AOVdWfPE4DxkXGEs8VMCPGGVi4C3VM0P37wVUCFvkVAy_90u5h9nbSlYy3-Sl-HhTdfl2fzFy1AOcHKP7qg";
        //    //组装
        //    var sigStr = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", ticket, model.NonceStr,
        //        model.TimeStamp, url);
        //    //sha1加密
        //    model.Signature = FormsAuthentication.HashPasswordForStoringInConfigFile(sigStr, "SHA1").ToLower();//f4d90daf4b3bca3078ab155816175ba34c443a7b
        //    return model;
        //}

        #endregion

        #region 发送模板消息
        //public static void SendMsg(WeiXinMsg msg)
        //{
        //    string token = GetExistAccessToken();
        //    string url = AuthorizeUrl.GetMsgSendUrl(token);
        //    var result = NetHelper.HttpPost(url, msg, SerializationType.Json);
        //}

        public static void SendTemplateMsg(dynamic msg, SysAccessToken accessToken)
        {
            string token = GetExistAccessToken(accessToken);
            string url = AuthorizeUrl.GetTemplateSendUrl(token);
            var result = NetHelper.HttpPost(url, msg, SerializationType.Json);
        }
        #endregion

        #region 发送客服消息
        public static void SendCustomerMsg(dynamic msg, SysAccessToken accessToken)
        {
            string token = GetExistAccessToken(accessToken);
            string url = AuthorizeUrl.GetCustomerSendUrl(token);
            var result = NetHelper.HttpPost(url, msg, SerializationType.Json);
        }
        #endregion

        #region 获取用户信息
        //public static WeiXinUser GetUserInfo(string code)
        //{
        //    string url = AuthorizeUrl.GetUserTokenUrl(code);
        //    var token = NetHelper.HttpGet<WeiXinUserToken>(url, SerializationType.Json);
        //    if (token.errcode==0)
        //    {
        //        //成功
        //        url = AuthorizeUrl.GetUserInfoUrl(token.access_token, token.openid);
        //        var user = NetHelper.HttpGet<WeiXinUser>(url, SerializationType.Json);
        //        if (user.errcode==0)
        //        {
        //            return user;
        //        }
        //    }

        //    return null;
        //}

        public static string GetOpenId(string code, string appid, string appSecret)
        {
            string url = AuthorizeUrl.GetUserTokenUrl(code,appid,appSecret);
            var token = NetHelper.HttpGet<WeiXinUserToken>(url, SerializationType.Json);
            if (token.errcode == 0)
            {
                return token.openid;
            }

            return string.Empty;
        }
        #endregion
    }
}
