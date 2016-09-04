using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// VIEW_S_jzzt_czzt_jzmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_S_jzzt_czzt_jzmx
	{
		public VIEW_S_jzzt_czzt_jzmx()
		{}
		#region Model
		private string _jzbh;
		private string _jzzt;
		private string _czzt;
		private DateTime _czsj;
		/// <summary>
		/// 
		/// </summary>
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jzzt
		{
			set{ _jzzt=value;}
			get{return _jzzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czzt
		{
			set{ _czzt=value;}
			get{return _czzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
		}
		#endregion Model

	}
}

