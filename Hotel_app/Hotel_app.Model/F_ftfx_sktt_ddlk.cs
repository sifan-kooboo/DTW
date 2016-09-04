using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// F_ftfx_sktt_ddlk:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class F_ftfx_sktt_ddlk
	{
		public F_ftfx_sktt_ddlk()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zyzt;
		private decimal _ydfs=0M;
		private decimal _ydrs=0M;
		private decimal _zdfs=0M;
		private decimal _zdrs=0M;
		private decimal _ylfs=0M;
		private decimal _ylrs=0M;
		private string _czy;
		private bool _is_top= false;
		private bool _is_select= false;
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
		public string zyzt
		{
			set{ _zyzt=value;}
			get{return _zyzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ydfs
		{
			set{ _ydfs=value;}
			get{return _ydfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ydrs
		{
			set{ _ydrs=value;}
			get{return _ydrs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zdfs
		{
			set{ _zdfs=value;}
			get{return _zdfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zdrs
		{
			set{ _zdrs=value;}
			get{return _zdrs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ylfs
		{
			set{ _ylfs=value;}
			get{return _ylfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ylrs
		{
			set{ _ylrs=value;}
			get{return _ylrs;}
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
		#endregion Model

	}
}

