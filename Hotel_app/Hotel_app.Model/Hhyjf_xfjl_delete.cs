using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhyjf_xfjl_delete:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_xfjl_delete
	{
		public Hhyjf_xfjl_delete()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _id_app;
		private string _lsbh_df;
		private bool _shsc= false;
		private DateTime _clsj= DateTime.Now;
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
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lsbh_df
		{
			set{ _lsbh_df=value;}
			get{return _lsbh_df;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime clsj
		{
			set{ _clsj=value;}
			get{return _clsj;}
		}
		#endregion Model

	}
}

