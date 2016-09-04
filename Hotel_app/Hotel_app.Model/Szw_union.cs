using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Szw_union:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Szw_union
	{
		public Szw_union()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _union_bh="";
		private string _jzbh="";
		private string _id_app="";
		private bool _shsc= false;
		private DateTime _czsj= DateTime.Now;
		private bool _is_first= false;
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
		public string union_bh
		{
			set{ _union_bh=value;}
			get{return _union_bh;}
		}
		/// <summary>
		/// 记账、挂账拆账时会用
		/// </summary>
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
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
		/// <summary>
		/// 
		/// </summary>
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_first
		{
			set{ _is_first=value;}
			get{return _is_first;}
		}
		#endregion Model

	}
}

