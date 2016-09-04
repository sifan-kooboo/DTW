using System;
namespace jdgl_res_head_service.Model
{
	/// <summary>
	/// Q_zb_fs_fx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Q_zb_fs_fx
	{
		public Q_zb_fs_fx()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _lsbh="";
		private string _fjrb="";
		private string _fjbh="";
		private DateTime _ddrq= Convert.ToDateTime("1800-01-01");
		private DateTime _lkrq= Convert.ToDateTime("1800-01-01");
		private DateTime _ddsj= Convert.ToDateTime("1800-01-01");
		private DateTime _lksj= Convert.ToDateTime("1800-01-01");
		private decimal _lzfs=0M;
		private string _zyzt="";
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
		public DateTime ddrq
		{
			set{ _ddrq=value;}
			get{return _ddrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lkrq
		{
			set{ _lkrq=value;}
			get{return _lkrq;}
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
		public decimal lzfs
		{
			set{ _lzfs=value;}
			get{return _lzfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zyzt
		{
			set{ _zyzt=value;}
			get{return _zyzt;}
		}
		#endregion Model

	}
}

