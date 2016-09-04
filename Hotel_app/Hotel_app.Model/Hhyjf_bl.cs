using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhyjf_bl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_bl
	{
		public Hhyjf_bl()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _krly="";
		private string _hyrx="";
		private decimal _jfbl=0M;
		private string _hyjfrx="";
		private bool _is_top= false;
		private bool _is_select= false;
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
		public string krly
		{
			set{ _krly=value;}
			get{return _krly;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hyrx
		{
			set{ _hyrx=value;}
			get{return _hyrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jfbl
		{
			set{ _jfbl=value;}
			get{return _jfbl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hyjfrx
		{
			set{ _hyjfrx=value;}
			get{return _hyjfrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_top
		{
			set{ _is_top=value;}
			get{return _is_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_select
		{
			set{ _is_select=value;}
			get{return _is_select;}
		}
		#endregion Model

	}
}

