using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Sfkfssz:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sfkfssz
	{
		public Sfkfssz()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private bool _is_top= false;
		private bool _is_select= false;
		private string _jzbh="";
		private string _jzzt="";
		private string _lsbh="";
		private string _fjbh="";
		private string _krxm="";
		private string _fkfs="";
		private string _xfdr="";
		private string _xfrb="";
		private string _xfxm="";
		private decimal _xfje=0M;
		private decimal _sjxfje=0M;
		private DateTime _czrq= Convert.ToDateTime("1800-01-01");
		private DateTime _czsj= Convert.ToDateTime("1800-01-01");
		private DateTime _xfrq= Convert.ToDateTime("1800-01-01");
		private DateTime _xfsj= Convert.ToDateTime("1800-01-01");
		private string _czy="";
		private string _czy_bc="";
		private string _syzd="";
		private string _id_app="";
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
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
		}
		/// <summary>
		/// 结账状态
		/// </summary>
		public string jzzt
		{
			set{ _jzzt=value;}
			get{return _jzzt;}
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
		public string fkfs
		{
			set{ _fkfs=value;}
			get{return _fkfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfdr
		{
			set{ _xfdr=value;}
			get{return _xfdr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfrb
		{
			set{ _xfrb=value;}
			get{return _xfrb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfxm
		{
			set{ _xfxm=value;}
			get{return _xfxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sjxfje
		{
			set{ _sjxfje=value;}
			get{return _sjxfje;}
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
		/// 付款时间，用来识别预收款的收款时间
		/// </summary>
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime xfrq
		{
			set{ _xfrq=value;}
			get{return _xfrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime xfsj
		{
			set{ _xfsj=value;}
			get{return _xfsj;}
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
		/// 操作员班次
		/// </summary>
		public string czy_bc
		{
			set{ _czy_bc=value;}
			get{return _czy_bc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string syzd
		{
			set{ _syzd=value;}
			get{return _syzd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		#endregion Model

	}
}

