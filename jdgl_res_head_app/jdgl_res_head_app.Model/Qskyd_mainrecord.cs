using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Qskyd_mainrecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qskyd_mainrecord
	{
		public Qskyd_mainrecord()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _lsbh="";
		private string _ddbh="";
		private bool _is_top= false;
		private bool _is_select= false;
		private string _hykh="";
		private string _hyrx="";
		private string _krxm="";
		private string _tlkr="";
		private string _krgj="";
		private string _krmz="";
		private string _yxzj="";
		private string _zjhm="";
		private string _krxb="";
		private DateTime _krsr= Convert.ToDateTime("1800-01-01");
		private string _krdh="";
		private string _krsj="";
		private string _kremail="";
		private string _krdz="";
		private string _krjg="";
		private string _krdw="";
		private string _krzy="";
		private string _cxmd="";
		private string _qzrx="";
		private string _qzhm="";
		private DateTime _zjyxq= Convert.ToDateTime("1800-01-01");
		private DateTime _tlyxq= Convert.ToDateTime("1800-01-01");
		private DateTime _tjrq= Convert.ToDateTime("1800-01-01");
		private string _lzka="";
		private string _krly="";
		private string _xyh="";
		private string _xydw="";
		private string _xsy="";
		private string _ddrx="";
		private string _ddwz="";
		private string _ddyy="";
		private string _zyzt="";
		private string _krrx="";
		private int _kr_children=0;
		private DateTime _ddsj;
		private int _lzts=0;
		private DateTime _lksj= Convert.ToDateTime("1800-01-01");
		private string _qtyq="";
		private string _czy="";
		private DateTime _czsj= DateTime.Now;
		private string _cznr="";
		private bool _shsc= false;
		private string _sktt="";
		private string _yddj="";
		private bool _ffshys= true;
		private bool _ffzf= false;
		private string _main_sec="main";
		private bool _sdcz= false;
		private string _syzd="";
		private string _vip_type="";
		private string _tsyq="";
		private string _ddly;
		private string _hykh_bz="";
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
		public string lsbh
		{
			set{ _lsbh=value;}
			get{return _lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ddbh
		{
			set{ _ddbh=value;}
			get{return _ddbh;}
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
		public string hykh
		{
			set{ _hykh=value;}
			get{return _hykh;}
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
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tlkr
		{
			set{ _tlkr=value;}
			get{return _tlkr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krgj
		{
			set{ _krgj=value;}
			get{return _krgj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krmz
		{
			set{ _krmz=value;}
			get{return _krmz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yxzj
		{
			set{ _yxzj=value;}
			get{return _yxzj;}
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
		public string krxb
		{
			set{ _krxb=value;}
			get{return _krxb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime krsr
		{
			set{ _krsr=value;}
			get{return _krsr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krdh
		{
			set{ _krdh=value;}
			get{return _krdh;}
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
		public string krEmail
		{
			set{ _kremail=value;}
			get{return _kremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krdz
		{
			set{ _krdz=value;}
			get{return _krdz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krjg
		{
			set{ _krjg=value;}
			get{return _krjg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krdw
		{
			set{ _krdw=value;}
			get{return _krdw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krzy
		{
			set{ _krzy=value;}
			get{return _krzy;}
		}
		/// <summary>
		/// 出行目的
		/// </summary>
		public string cxmd
		{
			set{ _cxmd=value;}
			get{return _cxmd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qzrx
		{
			set{ _qzrx=value;}
			get{return _qzrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qzhm
		{
			set{ _qzhm=value;}
			get{return _qzhm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime zjyxq
		{
			set{ _zjyxq=value;}
			get{return _zjyxq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime tlyxq
		{
			set{ _tlyxq=value;}
			get{return _tlyxq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime tjrq
		{
			set{ _tjrq=value;}
			get{return _tjrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lzka
		{
			set{ _lzka=value;}
			get{return _lzka;}
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
		public string xyh
		{
			set{ _xyh=value;}
			get{return _xyh;}
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
		public string xsy
		{
			set{ _xsy=value;}
			get{return _xsy;}
		}
		/// <summary>
		/// 抵达类型
		/// </summary>
		public string ddrx
		{
			set{ _ddrx=value;}
			get{return _ddrx;}
		}
		/// <summary>
		/// 抵达位置
		/// </summary>
		public string ddwz
		{
			set{ _ddwz=value;}
			get{return _ddwz;}
		}
		/// <summary>
		/// 到达原因
		/// </summary>
		public string ddyy
		{
			set{ _ddyy=value;}
			get{return _ddyy;}
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
		/// 客人类型
		/// </summary>
		public string krrx
		{
			set{ _krrx=value;}
			get{return _krrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int kr_children
		{
			set{ _kr_children=value;}
			get{return _kr_children;}
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
		public int lzts
		{
			set{ _lzts=value;}
			get{return _lzts;}
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
		public string qtyq
		{
			set{ _qtyq=value;}
			get{return _qtyq;}
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
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
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
		/// 房费是否过夜审
		/// </summary>
		public bool ffshys
		{
			set{ _ffshys=value;}
			get{return _ffshys;}
		}
		/// <summary>
		/// 房费是否自付，主要是针对团体或会议成员
		/// </summary>
		public bool ffzf
		{
			set{ _ffzf=value;}
			get{return _ffzf;}
		}
		/// <summary>
		/// 主次
		/// </summary>
		public string main_sec
		{
			set{ _main_sec=value;}
			get{return _main_sec;}
		}
		/// <summary>
		/// 锁定操作
		/// </summary>
		public bool sdcz
		{
			set{ _sdcz=value;}
			get{return _sdcz;}
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
		/// VIP类型设置
		/// </summary>
		public string vip_type
		{
			set{ _vip_type=value;}
			get{return _vip_type;}
		}
		/// <summary>
		/// 特殊要求，主要在登录界面时弹出提醒
		/// </summary>
		public string tsyq
		{
			set{ _tsyq=value;}
			get{return _tsyq;}
		}
		/// <summary>
		/// 抵达理由
		/// </summary>
		public string ddly
		{
			set{ _ddly=value;}
			get{return _ddly;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hykh_bz
		{
			set{ _hykh_bz=value;}
			get{return _hykh_bz;}
		}
		#endregion Model

	}
}

