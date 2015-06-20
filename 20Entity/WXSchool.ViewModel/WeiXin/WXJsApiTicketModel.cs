using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXSchool.ViewModel
{
    /// <summary>
    /// 微信 js api
    /// </summary>
    public class WXJsApiTicketModel
    {
        /// <summary>
        /// 开发者账号
        /// </summary>
        public string AppId;
        /// <summary>
        /// 时间戳
        /// </summary>
        public double TimeStamp;
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr;
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature;
    }
}
