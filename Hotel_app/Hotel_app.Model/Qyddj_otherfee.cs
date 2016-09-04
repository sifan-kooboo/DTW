using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Qyddj_otherfee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qyddj_otherfee
	{
		public Qyddj_otherfee()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private bool _is_select= false;
		private bool _is_top= false;
		private string _lsbh;
		private string _krxm;
		private string _sktt;
		private string _fjbh;
		private string _fyrx;
		private string _xfdr;
		private string _xfrb;
		private string _xfxm;
		private decimal _xfsl=1M;
		private decimal _jjje=0M;
		private decimal _xfje;
		private bool _shsc= false;
		private string _czy;
		private string _cznr;
		private DateTime _czsj= DateTime.Now;
		private bool _sdcz= false;
		private string _mxbh;
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
		public string lsbh
		{
			set{ _lsbh=value;}
			get{return _lsbh;}
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
		/// 比例类型（百分比或定额）
		/// </summary>
		public string fyrx
		{
			set{ _fyrx=value;}
			get{return _fyrx;}
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
		public decimal xfsl
		{
			set{ _xfsl=value;}
			get{return _xfsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jjje
		{
			set{ _jjje=value;}
			get{return _jjje;}
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
		public string mxbh
		{
			set{ _mxbh=value;}
			get{return _mxbh;}
		}
		#endregion Model

	}
}

