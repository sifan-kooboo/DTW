using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BBfx_s_g_j_ye_ls:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BBfx_s_g_j_ye_ls
	{
		public BBfx_s_g_j_ye_ls()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _jzzt;
		private string _xydw;
		private decimal _ff_total;
		private decimal _ds_total;
		private decimal _qt_total;
		private decimal _ye_total;
		private string _czy_temp;
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
		public string jzzt
		{
			set{ _jzzt=value;}
			get{return _jzzt;}
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
		public decimal ff_total
		{
			set{ _ff_total=value;}
			get{return _ff_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ds_total
		{
			set{ _ds_total=value;}
			get{return _ds_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal qt_total
		{
			set{ _qt_total=value;}
			get{return _qt_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ye_total
		{
			set{ _ye_total=value;}
			get{return _ye_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czy_temp
		{
			set{ _czy_temp=value;}
			get{return _czy_temp;}
		}
		#endregion Model

	}
}

