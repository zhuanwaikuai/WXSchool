/**  版本信息模板在安装目录下，可自行修改。
* NoticeHead.cs
*
* 功 能： N/A
* 类 名： NoticeHead
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
	/// NoticeHead:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NoticeHead
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public int NoticeId
		{
			set;
			get;
		}
		/// <summary>
		/// 公告标题
		/// </summary>
		public string NoticeTitle
		{
			set;
			get;
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set;
			get;
		}
		/// <summary>
		/// 创建人Id
		/// </summary>
		public int CreateUId
		{
			set;
			get;
		}
		/// <summary>
		/// 创建人姓名
		/// </summary>
		public string CreateUName
		{
			set;
			get;
		}
		#endregion Model

	}
}

