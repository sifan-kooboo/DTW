using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// X_yw_xfmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class X_yw_xfmx
	{
		public X_yw_xfmx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _language_bh;
		private string _language_type;
		private string _xfmx_china;
		private string _xfmx_yw;
		private string _rx;
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
		public string language_bh
		{
			set{ _language_bh=value;}
			get{return _language_bh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string language_type
		{
			set{ _language_type=value;}
			get{return _language_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfmx_china
		{
			set{ _xfmx_china=value;}
			get{return _xfmx_china;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfmx_yw
		{
			set{ _xfmx_yw=value;}
			get{return _xfmx_yw;}
		}
		/// <summary>
		/// 判断是大类、小类、还是明细
		/// </summary>
		public string rx
		{
			set{ _rx=value;}
			get{return _rx;}
		}
		#endregion Model

	}
}

