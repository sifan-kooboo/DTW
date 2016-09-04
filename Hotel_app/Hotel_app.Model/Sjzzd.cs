using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Sjzzd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sjzzd
	{
		public Sjzzd()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _jzbh="";
		private string _lsbh="";
		private bool _is_top= false;
		private bool _is_select= false;
		private string _krxm="";
		private string _sktt="";
		private string _fjbh="";
		private string _xydw="";
		private string _krly="";
		private DateTime _tfsj= Convert.ToDateTime("1800-01-01");
		private DateTime _czsj= Convert.ToDateTime("1800-01-01");
		private string _czy="";
		private string _czzt="";
		private string _xyh="";
		private string _jzzt="";
		private bool _sdcz= false;
		private string _syzd="";
		private string _bz="";
		private int _fp_print=0;
		private bool _is_visible= true;
		private decimal _fkje=0M;
		private decimal _xfje=0M;
		private bool _shsc= false;
		private bool _shys= false;
		private DateTime _ddsj= Convert.ToDateTime("1800-01-01");
		private string _krxm_lz="";
		private string _fjbh_lz="";
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
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
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
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
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
		/// 退房时间
		/// </summary>
		public DateTime tfsj
		{
			set{ _tfsj=value;}
			get{return _tfsj;}
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
		/// 记账、挂账、结账、记账转结账、挂账转结账
		/// </summary>
		public string czzt
		{
			set{ _czzt=value;}
			get{return _czzt;}
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
		/// 结账主体，谁要付钱
		/// </summary>
		public string jzzt
		{
			set{ _jzzt=value;}
			get{return _jzzt;}
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
		/// 收银站点
		/// </summary>
		public string syzd
		{
			set{ _syzd=value;}
			get{return _syzd;}
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
		/// 发票打印次数
		/// </summary>
		public int fp_print
		{
			set{ _fp_print=value;}
			get{return _fp_print;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_visible
		{
			set{ _is_visible=value;}
			get{return _is_visible;}
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
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
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
		public DateTime ddsj
		{
			set{ _ddsj=value;}
			get{return _ddsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string krxm_lz
		{
			set{ _krxm_lz=value;}
			get{return _krxm_lz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjbh_lz
		{
			set{ _fjbh_lz=value;}
			get{return _fjbh_lz;}
		}
		#endregion Model

	}
}

