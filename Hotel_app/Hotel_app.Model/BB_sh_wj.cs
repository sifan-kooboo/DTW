using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BB_sh_wj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BB_sh_wj
	{
		public BB_sh_wj()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private DateTime _bbrq;
		private DateTime _ddsj;
		private DateTime _lksj;
		private string _krxm;
		private string _xydw;
		private string _krly;
		private string _fjrb;
		private string _fjbh;
		private string _sktt;
		private decimal _zfh;
		private decimal _ds;
		private decimal _qt;
		private decimal _zyye;
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
		public DateTime bbrq
		{
			set{ _bbrq=value;}
			get{return _bbrq;}
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
		public DateTime lksj
		{
			set{ _lksj=value;}
			get{return _lksj;}
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
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zfh
		{
			set{ _zfh=value;}
			get{return _zfh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ds
		{
			set{ _ds=value;}
			get{return _ds;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal qt
		{
			set{ _qt=value;}
			get{return _qt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zyye
		{
			set{ _zyye=value;}
			get{return _zyye;}
		}
		#endregion Model

	}
}

