/**  版本信息模板在安装目录下，可自行修改。
* NoticeDetail.cs
*
* 功 能： N/A
* 类 名： NoticeDetail
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
	/// NoticeDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NoticeDetail
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public int DtlId
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int HeadId
		{
			set;
			get;
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set;
			get;
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			set;
			get;
		}
		/// <summary>
		/// 点击后跳转的链接
		/// </summary>
		public string Url
		{
			set;
			get;
		}
		/// <summary>
		/// 图文消息的图片链接
		/// </summary>
		public string PicUrl
		{
			set;
			get;
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int Sorting
		{
			set;
			get;
		}
		#endregion Model

	}
}

