using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Flfsz_temp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Flfsz_temp
	{
		public Flfsz_temp()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _lfbh;
		private string _lsbh;
		private string _fjbh;
		private string _krxm;
		private string _sktt;
		private string _yddj;
		private string _czy;
		private string _cznr="";
		private DateTime _czsj;
		private bool _shlz;
		private bool _is_top;
		private bool _is_select;
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
		public string lfbh
		{
			set{ _lfbh=value;}
			get{return _lfbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lsbh
		{
			set{ _lsbh=value;}
			get{return _lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
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
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yddj
		{
			set{ _yddj=value;}
			get{return _yddj;}
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
		public string cznr
		{
			set{ _cznr=value;}
			get{return _cznr;}
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
		/// 是否联账,如果联账，结账时才显示一起结
		/// </summary>
		public bool shlz
		{
			set{ _shlz=value;}
			get{return _shlz;}
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

