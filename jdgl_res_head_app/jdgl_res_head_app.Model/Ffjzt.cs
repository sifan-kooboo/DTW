using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Ffjzt:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ffjzt
	{
		public Ffjzt()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _zyzt="干净房";
		private string _zyzt_second="";
		private string _zybz="";
		private string _fjrb_code="";
		private string _fjrb="";
		private string _fjbh="";
		private string _fjdh="";
		private string _dhfj="";
		private string _jdlh="";
		private string _jdlh_name="";
		private string _jdcs="";
		private string _jdcs_name="";
		private string _krxm="";
		private DateTime _ddsj= Convert.ToDateTime("1800-01-01");
		private DateTime _lksj= Convert.ToDateTime("1800-01-01");
		private DateTime _yd_ddsj= Convert.ToDateTime("1800-01-01");
		private DateTime _yd_lksj= Convert.ToDateTime("1800-01-01");
		private string _bz="";
		private bool _shlf= false;
		private bool _shts= false;
		private bool _shvip= false;
		private string _lsbh="";
		private string _sktt="";
		private bool _is_select= false;
		private bool _is_top= false;
		private decimal _use_time=0M;
		private bool _is_secret= false;
		private DateTime _czsj= DateTime.Now;
		private string _cznr="";
		private string _czy="";
		private bool _fjbm= false;
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
		public string zyzt
		{
			set{ _zyzt=value;}
			get{return _zyzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zyzt_second
		{
			set{ _zyzt_second=value;}
			get{return _zyzt_second;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zybz
		{
			set{ _zybz=value;}
			get{return _zybz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjrb_code
		{
			set{ _fjrb_code=value;}
			get{return _fjrb_code;}
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
		public string fjdh
		{
			set{ _fjdh=value;}
			get{return _fjdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dhfj
		{
			set{ _dhfj=value;}
			get{return _dhfj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdlh
		{
			set{ _jdlh=value;}
			get{return _jdlh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdlh_name
		{
			set{ _jdlh_name=value;}
			get{return _jdlh_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdcs
		{
			set{ _jdcs=value;}
			get{return _jdcs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdcs_name
		{
			set{ _jdcs_name=value;}
			get{return _jdcs_name;}
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
		public DateTime yd_ddsj
		{
			set{ _yd_ddsj=value;}
			get{return _yd_ddsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime yd_lksj
		{
			set{ _yd_lksj=value;}
			get{return _yd_lksj;}
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
		public bool shlf
		{
			set{ _shlf=value;}
			get{return _shlf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shts
		{
			set{ _shts=value;}
			get{return _shts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shvip
		{
			set{ _shvip=value;}
			get{return _shvip;}
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
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
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
		public bool is_top
		{
			set{ _is_top=value;}
			get{return _is_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal use_time
		{
			set{ _use_time=value;}
			get{return _use_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_secret
		{
			set{ _is_secret=value;}
			get{return _is_secret;}
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
		public string cznr
		{
			set{ _cznr=value;}
			get{return _cznr;}
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
		/// 房价保密
		/// </summary>
		public bool fjbm
		{
			set{ _fjbm=value;}
			get{return _fjbm;}
		}
		#endregion Model

	}
}

