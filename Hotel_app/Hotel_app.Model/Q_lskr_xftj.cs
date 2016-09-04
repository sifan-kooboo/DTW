using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Q_lskr_xftj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Q_lskr_xftj
	{
		public Q_lskr_xftj()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zjhm;
		private string _krxm;
		private decimal _lzcs=0M;
		private decimal _xfje_ff=0M;
		private decimal _xfje_cp=0M;
		private decimal _xfje_js=0M;
		private decimal _xfje_other=0M;
		private decimal _lzfs=0M;
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
		public string zjhm
		{
			set{ _zjhm=value;}
			get{return _zjhm;}
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
		public decimal lzcs
		{
			set{ _lzcs=value;}
			get{return _lzcs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje_ff
		{
			set{ _xfje_ff=value;}
			get{return _xfje_ff;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje_cp
		{
			set{ _xfje_cp=value;}
			get{return _xfje_cp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje_js
		{
			set{ _xfje_js=value;}
			get{return _xfje_js;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje_other
		{
			set{ _xfje_other=value;}
			get{return _xfje_other;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal lzfs
		{
			set{ _lzfs=value;}
			get{return _lzfs;}
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

