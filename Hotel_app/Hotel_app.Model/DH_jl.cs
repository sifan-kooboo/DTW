using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// DH_jl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DH_jl
	{
		public DH_jl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _rn;
		private string _call_no;
		private string _dn;
		private string _receive_no;
		private string _da;
		private DateTime _xfrq;
		private string _ti;
		private DateTime _xfsj;
		private string _ta="";
		private decimal _sjxfje=0M;
		private string _du;
		private string _xfsj_bz;
		private string _p;
		private string _lsbh="";
		private DateTime _czsj= DateTime.Now;
		private bool _shsc= false;
		private string _id_app="";
		private string _krxm="";
		private string _fjbh="";
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
		public string RN
		{
			set{ _rn=value;}
			get{return _rn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string call_no
		{
			set{ _call_no=value;}
			get{return _call_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DN
		{
			set{ _dn=value;}
			get{return _dn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string receive_no
		{
			set{ _receive_no=value;}
			get{return _receive_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DA
		{
			set{ _da=value;}
			get{return _da;}
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
		public string TI
		{
			set{ _ti=value;}
			get{return _ti;}
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
		public string TA
		{
			set{ _ta=value;}
			get{return _ta;}
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
		public string DU
		{
			set{ _du=value;}
			get{return _du;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfsj_bz
		{
			set{ _xfsj_bz=value;}
			get{return _xfsj_bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P
		{
			set{ _p=value;}
			get{return _p;}
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
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
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
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
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
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
		}
		#endregion Model

	}
}

