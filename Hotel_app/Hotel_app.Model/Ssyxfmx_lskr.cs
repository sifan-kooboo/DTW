using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ssyxfmx_lskr:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ssyxfmx_lskr
	{
		public Ssyxfmx_lskr()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _krxm;
		private string _zjhm;
		private string _id_app;
		private bool _shsc= false;
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
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjhm
		{
			set{ _zjhm=value;}
			get{return _zjhm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
		}
		#endregion Model

	}
}

