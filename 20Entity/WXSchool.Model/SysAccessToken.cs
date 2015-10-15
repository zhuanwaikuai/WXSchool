
using System;
namespace WXSchool.Model
{
	/// <summary>
	/// SysAccessToken:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysAccessToken
	{
        public int TId
        {
            set;
            get;
        }

        public string access_token
        {
            set;
            get;
        }

        public int expires_in
        {
            set;
            get;
        }

        public DateTime LastTime
        {
            set;
            get;
        }
	}
}

