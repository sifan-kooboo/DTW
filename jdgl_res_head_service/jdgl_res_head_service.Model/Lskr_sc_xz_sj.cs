using System;
namespace jdgl_res_head_service.Model
{
	/// <summary>
	/// Lskr_sc_xz_sj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lskr_sc_xz_sj
	{
		public Lskr_sc_xz_sj()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private DateTime _scsj;
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
		public DateTime scsj
		{
			set{ _scsj=value;}
			get{return _scsj;}
		}
		#endregion Model

	}
}

