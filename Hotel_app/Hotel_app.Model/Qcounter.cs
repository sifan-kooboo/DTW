using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Qcounter:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qcounter
	{
		public Qcounter()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private int _bh;
		private int _skydcounter;
		private DateTime _skyddate;
		private int _skdjcounter;
		private DateTime _skdjdate;
		private int _ttydcounter;
		private DateTime _ttyddate;
		private int _lsttdjcounter;
		private DateTime _ttdjdate;
		private int _ttdjcounter;
		private int _lfcounter;
		private DateTime _lfdate;
		private int _gzcounter;
		private DateTime _gzdate;
		private int _jzcounter;
		private DateTime _jzdate;
		private int _szcounter;
		private DateTime _szdate;
		private int _qs;
		private DateTime _qsdate;
		private DateTime _jbdate;
		private int _jbcounter;
		private bool _zdpf;
		private bool _shys;
		private DateTime _zhbbsj;
		private int _txftsl;
		private int _shgz;
		private int _ybtqts;
		private int _hycounter;
		private DateTime _hydate;
		private int _lsbhcounter;
		private DateTime _lsbhdate;
		private DateTime _scsj;
		private decimal _zjk;
		private decimal _zbjk;
		private DateTime _xzsj;
		private bool _shsc;
		private string _scbz;
		private DateTime _jsbtsj;
		private DateTime _jsqtsj;
		private int _tjkffs;
		private DateTime _xydwdate;
		private int _xydwcounter;
		private int _printzdpd;
		private int _hyjfrxpd;
		private int _eating_time;
		private int _xsws;
		private bool _shlz;
		private int _lsbhdfcounter;
		private DateTime _lsbhdfdate;
		private int _ff_xfsj_rx=1;
		private int _ysk_pc=0;
		private bool _ft_xs_krxm= true;
		private bool _ft_xs_fjjg= true;
		private bool _ft_auto_refresh= true;
		private int _jz_ts=90;
		private decimal _jz_ls_total=200000M;
		private bool _hhygl_qyqr= false;
		private string _versiontype;
		/// <summary>
		/// 
		/// </summary>
		public int ID
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
		public int bh
		{
			set{ _bh=value;}
			get{return _bh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int skydcounter
		{
			set{ _skydcounter=value;}
			get{return _skydcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime skyddate
		{
			set{ _skyddate=value;}
			get{return _skyddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int skdjcounter
		{
			set{ _skdjcounter=value;}
			get{return _skdjcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime skdjdate
		{
			set{ _skdjdate=value;}
			get{return _skdjdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ttydcounter
		{
			set{ _ttydcounter=value;}
			get{return _ttydcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ttyddate
		{
			set{ _ttyddate=value;}
			get{return _ttyddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lsttdjcounter
		{
			set{ _lsttdjcounter=value;}
			get{return _lsttdjcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ttdjdate
		{
			set{ _ttdjdate=value;}
			get{return _ttdjdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ttdjcounter
		{
			set{ _ttdjcounter=value;}
			get{return _ttdjcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lfcounter
		{
			set{ _lfcounter=value;}
			get{return _lfcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lfdate
		{
			set{ _lfdate=value;}
			get{return _lfdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int gzcounter
		{
			set{ _gzcounter=value;}
			get{return _gzcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime gzdate
		{
			set{ _gzdate=value;}
			get{return _gzdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int jzcounter
		{
			set{ _jzcounter=value;}
			get{return _jzcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime jzdate
		{
			set{ _jzdate=value;}
			get{return _jzdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int szcounter
		{
			set{ _szcounter=value;}
			get{return _szcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime szdate
		{
			set{ _szdate=value;}
			get{return _szdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int qs
		{
			set{ _qs=value;}
			get{return _qs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime qsdate
		{
			set{ _qsdate=value;}
			get{return _qsdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime jbdate
		{
			set{ _jbdate=value;}
			get{return _jbdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int jbcounter
		{
			set{ _jbcounter=value;}
			get{return _jbcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool zdpf
		{
			set{ _zdpf=value;}
			get{return _zdpf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shys
		{
			set{ _shys=value;}
			get{return _shys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime zhbbsj
		{
			set{ _zhbbsj=value;}
			get{return _zhbbsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int txftsl
		{
			set{ _txftsl=value;}
			get{return _txftsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shgz
		{
			set{ _shgz=value;}
			get{return _shgz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ybtqts
		{
			set{ _ybtqts=value;}
			get{return _ybtqts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hycounter
		{
			set{ _hycounter=value;}
			get{return _hycounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime hydate
		{
			set{ _hydate=value;}
			get{return _hydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lsbhcounter
		{
			set{ _lsbhcounter=value;}
			get{return _lsbhcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lsbhdate
		{
			set{ _lsbhdate=value;}
			get{return _lsbhdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime scsj
		{
			set{ _scsj=value;}
			get{return _scsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zjk
		{
			set{ _zjk=value;}
			get{return _zjk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zbjk
		{
			set{ _zbjk=value;}
			get{return _zbjk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime xzsj
		{
			set{ _xzsj=value;}
			get{return _xzsj;}
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
		public string scbz
		{
			set{ _scbz=value;}
			get{return _scbz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime jsbtsj
		{
			set{ _jsbtsj=value;}
			get{return _jsbtsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime jsqtsj
		{
			set{ _jsqtsj=value;}
			get{return _jsqtsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int tjkffs
		{
			set{ _tjkffs=value;}
			get{return _tjkffs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime xydwdate
		{
			set{ _xydwdate=value;}
			get{return _xydwdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int xydwcounter
		{
			set{ _xydwcounter=value;}
			get{return _xydwcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int printzdpd
		{
			set{ _printzdpd=value;}
			get{return _printzdpd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hyjfrxpd
		{
			set{ _hyjfrxpd=value;}
			get{return _hyjfrxpd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int eating_time
		{
			set{ _eating_time=value;}
			get{return _eating_time;}
		}
		/// <summary>
		/// 小数位数
		/// </summary>
		public int xsws
		{
			set{ _xsws=value;}
			get{return _xsws;}
		}
		/// <summary>
		/// 是否联账
		/// </summary>
		public bool shlz
		{
			set{ _shlz=value;}
			get{return _shlz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lsbhdfcounter
		{
			set{ _lsbhdfcounter=value;}
			get{return _lsbhdfcounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lsbhdfdate
		{
			set{ _lsbhdfdate=value;}
			get{return _lsbhdfdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ff_xfsj_rx
		{
			set{ _ff_xfsj_rx=value;}
			get{return _ff_xfsj_rx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ysk_pc
		{
			set{ _ysk_pc=value;}
			get{return _ysk_pc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ft_xs_krxm
		{
			set{ _ft_xs_krxm=value;}
			get{return _ft_xs_krxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ft_xs_fjjg
		{
			set{ _ft_xs_fjjg=value;}
			get{return _ft_xs_fjjg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ft_auto_refresh
		{
			set{ _ft_auto_refresh=value;}
			get{return _ft_auto_refresh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int jz_ts
		{
			set{ _jz_ts=value;}
			get{return _jz_ts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jz_ls_total
		{
			set{ _jz_ls_total=value;}
			get{return _jz_ls_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Hhygl_qyqr
		{
			set{ _hhygl_qyqr=value;}
			get{return _hhygl_qyqr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VersionType
		{
			set{ _versiontype=value;}
			get{return _versiontype;}
		}
		#endregion Model

	}
}

