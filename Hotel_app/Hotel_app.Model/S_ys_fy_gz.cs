using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// S_ys_fy_gz:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_ys_fy_gz
	{
		public S_ys_fy_gz()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _ys_dh;
		private string _lsbh;
		private string _fjrb;
		private string _fjbh;
		private string _krxm;
		private string _sktt;
		private string _xydw;
		private string _krly;
		private string _start_sc;
		private string _end_sc;
		private DateTime _czrq;
		private DateTime _czsj;
		private string _czy;
		private string _bz;
		private DateTime _ddsj= Convert.ToDateTime("1800-01-01");
		private DateTime _lksj= Convert.ToDateTime("1800-01-01");
		private decimal _sjfjjg;
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
		public string ys_dh
		{
			set{ _ys_dh=value;}
			get{return _ys_dh;}
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
		public string fjrb
		{
			set{ _fjrb=value;}
			get{return _fjrb;}
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
		public string xydw
		{
			set{ _xydw=value;}
			get{return _xydw;}
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
		public string start_sc
		{
			set{ _start_sc=value;}
			get{return _start_sc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string end_sc
		{
			set{ _end_sc=value;}
			get{return _end_sc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime czrq
		{
			set{ _czrq=value;}
			get{return _czrq;}
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
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
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
		public DateTime ddsj
		{
			set{ _ddsj=value;}
			get{return _ddsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lksj
		{
			set{ _lksj=value;}
			get{return _lksj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sjfjjg
		{
			set{ _sjfjjg=value;}
			get{return _sjfjjg;}
		}
		#endregion Model

	}
}

