using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhy_sc_xz_sj:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhy_sc_xz_sj
	{
		public Hhy_sc_xz_sj()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private DateTime _hy_scsj;
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
		public DateTime hy_scsj
		{
			set{ _hy_scsj=value;}
			get{return _hy_scsj;}
		}
		#endregion Model

	}
}

