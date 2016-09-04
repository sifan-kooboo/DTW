using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Szw_zz_fj_temp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Szw_zz_fj_temp
	{
		public Szw_zz_fj_temp()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _jzbh;
		private string _id_app;
		private string _lsbh;
		private string _czy;
		private bool _is_top= false;
		private bool _is_select= false;
		private DateTime _czsj= DateTime.Now;
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
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
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
		public string lsbh
		{
			set{ _lsbh=value;}
			get{return _lsbh;}
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
		/// <summary>
		/// 
		/// </summary>
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
		}
		#endregion Model

	}
}

