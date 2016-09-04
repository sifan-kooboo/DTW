using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// VIEW_S_czzt_zwmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIEW_S_czzt_zwmx
	{
		public VIEW_S_czzt_zwmx()
		{}
		#region Model
		private string _jzbh;
		private string _czzt;
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
		public string czzt
		{
			set{ _czzt=value;}
			get{return _czzt;}
		}
		#endregion Model

	}
}

