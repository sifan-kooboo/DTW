using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// X_update:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class X_update
	{
		public X_update()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _downloadurl;
		private string _preversion;
		private string _remoteurl;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yydh
		{
			set{ _yydh=value;}
			get{return _yydh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qymc
		{
			set{ _qymc=value;}
			get{return _qymc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string downloadURL
		{
			set{ _downloadurl=value;}
			get{return _downloadurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string preVersion
		{
			set{ _preversion=value;}
			get{return _preversion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remoteUrl
		{
			set{ _remoteurl=value;}
			get{return _remoteurl;}
		}
		#endregion Model

	}
}

