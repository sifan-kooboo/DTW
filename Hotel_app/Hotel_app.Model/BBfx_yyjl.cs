using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BBfx_yyjl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BBfx_yyjl
	{
		public BBfx_yyjl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _sbzd;
		private string _xfrb;
		private string _sjxfje;
		private string _czy_temp;
		private string _y_r;
		private string _y_z_w;
		private DateTime _bbrq;
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
		public string sbzd
		{
			set{ _sbzd=value;}
			get{return _sbzd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfrb
		{
			set{ _xfrb=value;}
			get{return _xfrb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sjxfje
		{
			set{ _sjxfje=value;}
			get{return _sjxfje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czy_temp
		{
			set{ _czy_temp=value;}
			get{return _czy_temp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string y_r
		{
			set{ _y_r=value;}
			get{return _y_r;}
		}
		/// <summary>
		/// 营业y、账务z、预收w、未结w
		/// </summary>
		public string y_z_w
		{
			set{ _y_z_w=value;}
			get{return _y_z_w;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime bbrq
		{
			set{ _bbrq=value;}
			get{return _bbrq;}
		}
		#endregion Model

	}
}

