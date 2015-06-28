﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using QJZ.Framework.Utility;

namespace WeiXin.Bll
{
    public class AuthorizeUrl
    {
        private const string Oauth2Base = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={1}&redirect_uri=http://m.jswxt.com/WeiXin/Oauth2Base?reurl={0}&response_type=code&scope=snsapi_base&state=1#wechat_redirect";

        private const string Oauth2UserInfo = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={1}&redirect_uri=http://m.jswxt.com/WeiXin/Oauth2?reurl={0}&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect";

        private const string AccessToken =
            "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        private const string MsgSend = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";

        private const string UserToken =
            "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        private const string UserInfo = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        private const string TemplateSend = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        private const string Ticket =
            "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";

        private const string CustomerSend = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";

        public static string Appid
        {
            get
            {
                return AppSettingsHelper.GetString("WeixinAppid");
            }
        }

        public static string AppSecret
        {
            get
            {
                return AppSettingsHelper.GetString("WeixinAppSecret");
            }
        }

        public static string GetOauth2BaseUrl()
        {
            //return string.Format(Oauth2Base, redirectUrl, Appid);
            return Oauth2Base;
        }

        public static string GetOauth2UserInfoUrl(string redirectUrl)
        {
            return string.Format(Oauth2UserInfo, redirectUrl, Appid);
        }

        public static string GetTokenUrl()
        {
            //return string.Format(AccessToken, Appid, AppSecret);
            return AccessToken;
        }

        public static string GetMsgSendUrl(string token)
        {
            return string.Format(MsgSend, token);
        }

        public static string GetUserTokenUrl(string code,string appid,string appSecret)
        {
            return string.Format(UserToken, appid, appSecret, code);
        }

        public static string GetUserInfoUrl(string token, string openId)
        {
            return string.Format(UserInfo, token, openId);
        }

        public static string GetTemplateSendUrl(string token)
        {
            return string.Format(TemplateSend, token);
        }

        public static string GetTicketUrl(string token)
        {
            return string.Format(Ticket, token);
        }

        public static string GetCustomerSendUrl(string token)
        {
            return string.Format(CustomerSend, token);
        }
    }
}
