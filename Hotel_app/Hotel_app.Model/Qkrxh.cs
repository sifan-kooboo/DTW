using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Qkrxh:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qkrxh
	{
		public Qkrxh()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zjhm;
		private string _krsj;
		private string _krxm;
		private string _hykh;
		private string _xhrx;
		private string _krxh;
		private string _bz="";
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _shsc= false;
		private string _czy;
		private DateTime _czsj;
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
		public string krsj
		{
			set{ _krsj=value;}
			get{return _krsj;}
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
		public string hykh
		{
			set{ _hykh=value;}
			get{return _hykh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xhrx
		{
			set{ _xhrx=value;}
			get{return _xhrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krxh
		{
			set{ _krxh=value;}
			get{return _krxh;}
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
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
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

