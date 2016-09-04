using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// F_ftfx_zkfx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class F_ftfx_zkfx
	{
		public F_ftfx_zkfx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zyzt;
		private decimal _zyfs=0M;
		private decimal _zyrs=0M;
		private bool _is_top= false;
		private bool _is_select= false;
		private string _czy;
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
		/// 输入的类型
		/// </summary>
		public string zyzt
		{
			set{ _zyzt=value;}
			get{return _zyzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zyfs
		{
			set{ _zyfs=value;}
			get{return _zyfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zyrs
		{
			set{ _zyrs=value;}
			get{return _zyrs;}
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
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
		}
		#endregion Model

	}
}

