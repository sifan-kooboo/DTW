using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Yxydw:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Yxydw
	{
		public Yxydw()
		{}
		#region Model
		private int _id;
		private string _krly="";
		private string _yydh="";
		private string _qymc="";
		private string _xyrx="";
		private string _krgj="";
		private string _pq="";
		private string _xyh="";
		private string _xyh_inner="";
		private string _rx="";
		private string _xydw="";
		private string _zjm="";
		private string _nxr="";
		private string _krdh="";
		private string _krcz="";
		private string _kremail="";
		private string _krdz="";
		private string _xsy="";
		private bool _shsc= false;
		private string _bz="";
		private decimal _lzfs=0M;
		private decimal _fkje=0M;
		private decimal _xfje=0M;
		private DateTime _clsj= DateTime.Now;
		private string _xzxg="xz";
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _shsh= false;
		private byte[] _sign_image;
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
		public string krly
		{
			set{ _krly=value;}
			get{return _krly;}
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
		public string xyrx
		{
			set{ _xyrx=value;}
			get{return _xyrx;}
		}
		/// <summary>
		/// 国家
		/// </summary>
		public string krgj
		{
			set{ _krgj=value;}
			get{return _krgj;}
		}
		/// <summary>
		/// 片区
		/// </summary>
		public string pq
		{
			set{ _pq=value;}
			get{return _pq;}
		}
		/// <summary>
		/// 系统自动生成
		/// </summary>
		public string xyh
		{
			set{ _xyh=value;}
			get{return _xyh;}
		}
		/// <summary>
		/// 手写协议号，内部编
		/// </summary>
		public string xyh_inner
		{
			set{ _xyh_inner=value;}
			get{return _xyh_inner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rx
		{
			set{ _rx=value;}
			get{return _rx;}
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
		public string zjm
		{
			set{ _zjm=value;}
			get{return _zjm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nxr
		{
			set{ _nxr=value;}
			get{return _nxr;}
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
		public string krcz
		{
			set{ _krcz=value;}
			get{return _krcz;}
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
		public string xsy
		{
			set{ _xsy=value;}
			get{return _xsy;}
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
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 入住房数
		/// </summary>
		public decimal lzfs
		{
			set{ _lzfs=value;}
			get{return _lzfs;}
		}
		/// <summary>
		/// 付款金额
		/// </summary>
		public decimal fkje
		{
			set{ _fkje=value;}
			get{return _fkje;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime clsj
		{
			set{ _clsj=value;}
			get{return _clsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xzxg
		{
			set{ _xzxg=value;}
			get{return _xzxg;}
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
		/// 审核
		/// </summary>
		public bool shsh
		{
			set{ _shsh=value;}
			get{return _shsh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] sign_image
		{
			set{ _sign_image=value;}
			get{return _sign_image;}
		}
		#endregion Model

	}
}

