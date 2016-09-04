using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// View_Xxfmx_zb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_Xxfmx_zb
	{
		public View_Xxfmx_zb()
		{}
		#region Model
		private string _mxbh;
		private decimal _zb_sl;
		private DateTime _zb_sj;
		private decimal _zb_jjje;
		private decimal _zb_total_cb;
		/// <summary>
		/// 
		/// </summary>
		public string mxbh
		{
			set{ _mxbh=value;}
			get{return _mxbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zb_sl
		{
			set{ _zb_sl=value;}
			get{return _zb_sl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime zb_sj
		{
			set{ _zb_sj=value;}
			get{return _zb_sj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zb_jjje
		{
			set{ _zb_jjje=value;}
			get{return _zb_jjje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal zb_Total_cb
		{
			set{ _zb_total_cb=value;}
			get{return _zb_total_cb;}
		}
		#endregion Model

	}
}

