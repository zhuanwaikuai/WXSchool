/**  版本信息模板在安装目录下，可自行修改。
* SysOrganization.cs
*
* 功 能： N/A
* 类 名： SysOrganization
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
	/// SysOrganization:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysOrganization
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
		/// 机构编码
		/// </summary>
		public string OrgCode
		{
			set;
			get;
		}
		/// <summary>
		/// 机构名称
		/// </summary>
		public string OrgName
		{
			set;
			get;
		}
		/// <summary>
		/// 父机构Id
		/// </summary>
		public int ParentId
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
		/// <summary>
		/// 关注人数
		/// </summary>
		public int BindingNumbers
		{
			set;
			get;
		}
		/// <summary>
		/// 等级：1 学校，2 年级，3 班级
		/// </summary>
		public int OrgLevel
		{
			set;
			get;
		}
		/// <summary>
		/// 负责人，组长
		/// </summary>
		public string Leader
		{
			set;
			get;
		}
		/// <summary>
		/// 是否删除：0 否，1 是
		/// </summary>
		public int IsDeleted
		{
			set;
			get;
		}
		#endregion Model

	}
}

