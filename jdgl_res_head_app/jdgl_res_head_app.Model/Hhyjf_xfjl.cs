using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhyjf_xfjl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_xfjl
	{
		public Hhyjf_xfjl()
		{}
		#region Model
		private int _id;
		private string _qymc="";
		private string _yydh="";
		private string _lsbh_df;
		private string _hykh="";
		private string _hykh_bz="";
		private string _krxm="";
		private string _id_app="";
		private string _lsbh="";
		private string _fjrb="";
		private string _fjbh="";
		private DateTime _xfrq;
		private DateTime _xfsj= DateTime.Now;
		private decimal _hyjf=0M;
		private string _bz="";
		private string _xfdr;
		private string _xfrb;
		private string _xfxm="";
		private decimal _sjxfje=0M;
		private bool _shsc= false;
		private DateTime _scsj= Convert.ToDateTime("1800-01-01");
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _shqx= false;
		private string _parent_hykh="";
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
		public string qymc
		{
			set{ _qymc=value;}
			get{return _qymc;}
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
		/// 积分记录识别码
		/// </summary>
		public string lsbh_df
		{
			set{ _lsbh_df=value;}
			get{return _lsbh_df;}
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
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
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
		public decimal hyjf
		{
			set{ _hyjf=value;}
			get{return _hyjf;}
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
		public decimal sjxfje
		{
			set{ _sjxfje=value;}
			get{return _sjxfje;}
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
		/// 是否取消，如果取消后这些积分就无效了
		/// </summary>
		public bool shqx
		{
			set{ _shqx=value;}
			get{return _shqx;}
		}
		/// <summary>
		/// 父卡/也可以是协议号
		/// </summary>
		public string parent_hykh
		{
			set{ _parent_hykh=value;}
			get{return _parent_hykh;}
		}
		#endregion Model

	}
}

