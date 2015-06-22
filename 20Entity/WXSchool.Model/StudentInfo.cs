/**  版本信息模板在安装目录下，可自行修改。
* StudentInfo.cs
*
* 功 能： N/A
* 类 名： StudentInfo
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
	/// StudentInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StudentInfo
	{
		#region Model
		/// <summary>
		/// 
		/// </summary>
		public int StudentId
		{
			set;
			get;
		}
		/// <summary>
		/// 学号
		/// </summary>
		public string StudentNo
		{
			set;
			get;
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string IDCardNo
		{
			set;
			get;
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string StudentName
		{
			set;
			get;
		}
		/// <summary>
		/// 学校ID
		/// </summary>
		public int SchoolId
		{
			set;
			get;
		}
		/// <summary>
		/// 学校名称
		/// </summary>
		public string SchoolName
		{
			set;
			get;
		}
		/// <summary>
		/// 年级编码
		/// </summary>
		public string GradeCode
		{
			set;
			get;
		}
		/// <summary>
		/// 年级名称
		/// </summary>
		public string GradeName
		{
			set;
			get;
		}
		/// <summary>
		/// 班级名称
		/// </summary>
		public string ClassName
		{
			set;
			get;
		}
		/// <summary>
		/// 手机号1
		/// </summary>
		public string Mobile1
		{
			set;
			get;
		}
		/// <summary>
		/// 手机号2
		/// </summary>
		public string Mobile2
		{
			set;
			get;
		}
		/// <summary>
		/// 是否邦定
		/// </summary>
		public int IsBinding
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
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set;
			get;
		}
		#endregion Model

	}
}

