using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// S_jbmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_jbmx
	{
		public S_jbmx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _lsbh;
		private string _syzd;
		private string _syy;
		private string _syy_rb_visible;
		private string _fkfs;
		private decimal _qtfk=0M;
		private decimal _ysk=0M;
		private decimal _t_ysk=0M;
		private decimal _qtsk_t_ysk=0M;
		private bool _shsc= false;
		private decimal _t_ysk_qt=0M;
		private decimal _ysk_fs=0M;
		private decimal _qt_yyk=0M;
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
		public string syzd
		{
			set{ _syzd=value;}
			get{return _syzd;}
		}
		/// <summary>
		/// 收银员
		/// </summary>
		public string syy
		{
			set{ _syy=value;}
			get{return _syy;}
		}
		/// <summary>
		/// 显示的收银员
		/// </summary>
		public string syy_rb_visible
		{
			set{ _syy_rb_visible=value;}
			get{return _syy_rb_visible;}
		}
		/// <summary>
		/// 付款方式
		/// </summary>
		public string fkfs
		{
			set{ _fkfs=value;}
			get{return _fkfs;}
		}
		/// <summary>
		/// 前台收款
		/// </summary>
		public decimal qtfk
		{
			set{ _qtfk=value;}
			get{return _qtfk;}
		}
		/// <summary>
		/// 预收款
		/// </summary>
		public decimal ysk
		{
			set{ _ysk=value;}
			get{return _ysk;}
		}
		/// <summary>
		/// 退_预收款
		/// </summary>
		public decimal t_ysk
		{
			set{ _t_ysk=value;}
			get{return _t_ysk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal qtsk_t_ysk
		{
			set{ _qtsk_t_ysk=value;}
			get{return _qtsk_t_ysk;}
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
		public decimal t_ysk_qt
		{
			set{ _t_ysk_qt=value;}
			get{return _t_ysk_qt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ysk_fs
		{
			set{ _ysk_fs=value;}
			get{return _ysk_fs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal qt_yyk
		{
			set{ _qt_yyk=value;}
			get{return _qt_yyk;}
		}
		#endregion Model

	}
}

