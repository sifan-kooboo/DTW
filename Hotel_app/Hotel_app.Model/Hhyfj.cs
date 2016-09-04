using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhyfj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyfj
	{
		public Hhyfj()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _hyrx="";
		private string _fjrb="";
		private decimal _hyfj=0M;
		private string _bz="";
		private bool _shsc= false;
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
		public string hyrx
		{
			set{ _hyrx=value;}
			get{return _hyrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjrb
		{
			set{ _fjrb=value;}
			get{return _fjrb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal hyfj
		{
			set{ _hyfj=value;}
			get{return _hyfj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
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

