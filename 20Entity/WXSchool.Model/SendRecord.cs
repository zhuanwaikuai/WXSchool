/**  版本信息模板在安装目录下，可自行修改。
* SendRecord.cs
*
* 功 能： N/A
* 类 名： SendRecord
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
	/// SendRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SendRecord
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public int SendId
		{
			set;
			get;
		}
		/// <summary>
		/// 消息类型：10 公告
		/// </summary>
		public int MgType
		{
			set;
			get;
		}
		/// <summary>
		/// 关联业务id
		/// </summary>
		public int RelateId
		{
			set;
			get;
		}
		/// <summary>
		/// 学生
		/// </summary>
		public int StudentId
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpenId
		{
			set;
			get;
		}
		/// <summary>
		/// 是否成功：0 否，1 是
		/// </summary>
		public int IsSuccessed
		{
			set;
			get;
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime SendTime
		{
			set;
			get;
		}
		#endregion Model

	}
}

