using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhygl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhygl
	{
		public Hhygl()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _hyrx="";
		private string _hykh="";
		private string _hykh_bz="";
		private string _krxm="";
		private string _krgj="";
		private string _krmz="";
		private string _yxzj="";
		private string _zjhm="";
		private DateTime _krsr= Convert.ToDateTime("1800-01-01");
		private string _krxb="";
		private string _krdh="";
		private string _krsj="";
		private string _kremail="";
		private string _krdz="";
		private string _krzy="";
		private string _krdw="";
		private string _qzrx;
		private string _qzhm;
		private DateTime _zjyxq= Convert.ToDateTime("1800-01-01");
		private DateTime _tlyxq= Convert.ToDateTime("1800-01-01");
		private DateTime _tjrq= Convert.ToDateTime("1800-01-01");
		private string _lzka="";
		private string _bz="";
		private DateTime _djsj= DateTime.Now;
		private decimal _hyjf=0M;
		private decimal _dfjf=0M;
		private bool _shsc= false;
		private DateTime _scsj= DateTime.Now;
		private DateTime _xgsj= DateTime.Now;
		private bool _shxg= false;
		private bool _shqr= false;
		private bool _is_top= false;
		private bool _is_select= false;
		private decimal _fkje=0M;
		private string _parent_hykh="";
		private string _hymm="";
		private string _xsy="";
		private string _czy="";
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
		/// 会员类型
		/// </summary>
		public string hyrx
		{
			set{ _hyrx=value;}
			get{return _hyrx;}
		}
		/// <summary>
		/// 像ddbh那样生成
		/// </summary>
		public string hykh
		{
			set{ _hykh=value;}
			get{return _hykh;}
		}
		/// <summary>
		/// 显示的会员卡号
		/// </summary>
		public string hykh_bz
		{
			set{ _hykh_bz=value;}
			get{return _hykh_bz;}
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
		/// 有效证件，如身份证、军官证
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
		public DateTime krsr
		{
			set{ _krsr=value;}
			get{return _krsr;}
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
		public string krdh
		{
			set{ _krdh=value;}
			get{return _krdh;}
		}
		/// <summary>
		/// 手机
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
		/// 职业
		/// </summary>
		public string krzy
		{
			set{ _krzy=value;}
			get{return _krzy;}
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
		/// 签证类型
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
		/// 入境口岸
		/// </summary>
		public string lzka
		{
			set{ _lzka=value;}
			get{return _lzka;}
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
		public DateTime djsj
		{
			set{ _djsj=value;}
			get{return _djsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal hyjf
		{
			set{ _hyjf=value;}
			get{return _hyjf;}
		}
		/// <summary>
		/// 兑换积分
		/// </summary>
		public decimal dfjf
		{
			set{ _dfjf=value;}
			get{return _dfjf;}
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
		public DateTime scsj
		{
			set{ _scsj=value;}
			get{return _scsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime xgsj
		{
			set{ _xgsj=value;}
			get{return _xgsj;}
		}
		/// <summary>
		/// 如果有修改当SHSC为1时要把这个值改为1
		/// </summary>
		public bool shxg
		{
			set{ _shxg=value;}
			get{return _shxg;}
		}
		/// <summary>
		/// 申请完要通过这个值的修改成1来表示成为正式会员
		/// </summary>
		public bool shqr
		{
			set{ _shqr=value;}
			get{return _shqr;}
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
		public decimal fkje
		{
			set{ _fkje=value;}
			get{return _fkje;}
		}
		/// <summary>
		/// 父卡/也可以是协议号
		/// </summary>
		public string parent_hykh
		{
			set{ _parent_hykh=value;}
			get{return _parent_hykh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hymm
		{
			set{ _hymm=value;}
			get{return _hymm;}
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
		/// 
		/// </summary>
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
		}
		#endregion Model

	}
}

