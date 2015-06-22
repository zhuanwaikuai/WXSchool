/**  版本信息模板在安装目录下，可自行修改。
* SysUser.cs
*
* 功 能： N/A
* 类 名： SysUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/22 11:01:58   N/A    初版
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
	/// SysUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysUser
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public int UId
		{
			set;
			get;
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set;
			get;
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set;
			get;
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set;
			get;
		}
		/// <summary>
		/// 所属机构ID
		/// </summary>
		public int OrgId
		{
			set;
			get;
		}
		/// <summary>
		/// 角色类型：90 系统管理员
		/// </summary>
		public int RoleType
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set;
			get;
		}
		/// <summary>
		/// 是否有效：1 是，0 否
		/// </summary>
		public int IsValid
		{
			set;
			get;
		}
		#endregion Model

	}
}

