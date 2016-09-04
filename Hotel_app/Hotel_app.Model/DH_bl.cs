using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// DH_bl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DH_bl
	{
		public DH_bl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _bshm;
		private string _bshm_sec;
		private decimal _fy_m;
		private string _bz;
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
		public string bshm
		{
			set{ _bshm=value;}
			get{return _bshm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bshm_sec
		{
			set{ _bshm_sec=value;}
			get{return _bshm_sec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fy_m
		{
			set{ _fy_m=value;}
			get{return _fy_m;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		#endregion Model

	}
}

