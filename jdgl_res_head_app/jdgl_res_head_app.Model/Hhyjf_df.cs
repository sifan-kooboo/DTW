﻿using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhyjf_df:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_df
	{
		public Hhyjf_df()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _lsbh_df;
		private string _hykh="";
		private string _hykh_bz="";
		private string _krxm="";
		private decimal _dfjf=0M;
		private string _dfxm="";
		private decimal _dfsl=0M;
		private DateTime _xfrq;
		private DateTime _xfsj= DateTime.Now;
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
		/// 兑换记录识别码
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
		public decimal dfjf
		{
			set{ _dfjf=value;}
			get{return _dfjf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dfxm
		{
			set{ _dfxm=value;}
			get{return _dfxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal dfsl
		{
			set{ _dfsl=value;}
			get{return _dfsl;}
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
		/// 是否取消，取消相应记录不再生效
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
