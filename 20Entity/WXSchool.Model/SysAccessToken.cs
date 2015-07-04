/**  版本信息模板在安装目录下，可自行修改。
* SysAccessToken.cs
*
* 功 能： N/A
* 类 名： SysAccessToken
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/22 11:01:57   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：嘉为电子　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace WXSchool.Model
{
	/// <summary>
	/// SysAccessToken:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysAccessToken
	{
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int OrgId
        {
            set;
            get;
        }
		/// <summary>
		/// 
		/// </summary>
		public string AppID
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppSecret
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppToken
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string access_token
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int expires_in
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LastTime
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string TemplateId1
		{
			set;
			get;
		}
		#endregion Model

	}
}

