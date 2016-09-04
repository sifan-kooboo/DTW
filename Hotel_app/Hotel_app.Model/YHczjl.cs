using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YHczjl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YHczjl
	{
		public YHczjl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _czy;
		private DateTime _czsj= Convert.ToDateTime("1800-01-01");
		private string _cznr;
		private string _czbz;
		private string _czzy;
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _shsc= false;
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
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime czsj
		{
			set{ _czsj=value;}
			get{return _czsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cznr
		{
			set{ _cznr=value;}
			get{return _cznr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czbz
		{
			set{ _czbz=value;}
			get{return _czbz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string czzy
		{
			set{ _czzy=value;}
			get{return _czzy;}
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
		public bool shsc
		{
			set{ _shsc=value;}
			get{return _shsc;}
		}
		#endregion Model

	}
}

