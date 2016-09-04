using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhyjf_jp_Class:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_jp_Class
	{
		public Hhyjf_jp_Class()
		{}
		#region Model
		private int _id;
		private string _title="";
		private string _yydh;
		private string _qymc;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		#endregion Model

	}
}

