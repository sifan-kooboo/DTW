using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Qtsjy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qtsjy
	{
		public Qtsjy()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _lsbh;
		private string _fjbh;
		private string _sktt;
		private string _krxm;
		private string _krsj;
		private string _zjhm;
		private string _xyh;
		private string _xydw;
		private string _hykh;
		private string _tsrx;
		private string _tsnr;
		private DateTime _tssj;
		private string _czy;
		private string _clbm;
		private string _clnr;
		private DateTime _clsj;
		private string _cly;
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _shsc;
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
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
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
		/// 散客的客人姓名,或团队的客人姓名
		/// </summary>
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string krsj
		{
			set{ _krsj=value;}
			get{return _krsj;}
		}
		/// <summary>
		/// 证件号码
		/// </summary>
		public string zjhm
		{
			set{ _zjhm=value;}
			get{return _zjhm;}
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
		public string hykh
		{
			set{ _hykh=value;}
			get{return _hykh;}
		}
		/// <summary>
		/// 投诉类型
		/// </summary>
		public string tsrx
		{
			set{ _tsrx=value;}
			get{return _tsrx;}
		}
		/// <summary>
		/// 投诉内容
		/// </summary>
		public string tsnr
		{
			set{ _tsnr=value;}
			get{return _tsnr;}
		}
		/// <summary>
		/// 投诉时间
		/// </summary>
		public DateTime tssj
		{
			set{ _tssj=value;}
			get{return _tssj;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
		}
		/// <summary>
		/// 处理部门
		/// </summary>
		public string clbm
		{
			set{ _clbm=value;}
			get{return _clbm;}
		}
		/// <summary>
		/// 处理内容
		/// </summary>
		public string clnr
		{
			set{ _clnr=value;}
			get{return _clnr;}
		}
		/// <summary>
		/// 处理时间
		/// </summary>
		public DateTime clsj
		{
			set{ _clsj=value;}
			get{return _clsj;}
		}
		/// <summary>
		/// 处理人员
		/// </summary>
		public string cly
		{
			set{ _cly=value;}
			get{return _cly;}
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
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
		}
		#endregion Model

	}
}

