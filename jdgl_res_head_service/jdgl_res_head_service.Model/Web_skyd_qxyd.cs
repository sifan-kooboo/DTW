using System;
namespace jdgl_res_head_service.Model
{
	/// <summary>
	/// Web_skyd_qxyd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Web_skyd_qxyd
	{
		public Web_skyd_qxyd()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _lsbh;
		private string _ddbh;
		private int _sfqr;
		private DateTime _qxsj;
		private string _qxyy;
		private string _sktt;
		/// <summary>
		/// id与web_skyd的id对应
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
		public string ddbh
		{
			set{ _ddbh=value;}
			get{return _ddbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sfqr
		{
			set{ _sfqr=value;}
			get{return _sfqr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime qxsj
		{
			set{ _qxsj=value;}
			get{return _qxsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qxyy
		{
			set{ _qxyy=value;}
			get{return _qxyy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
		}
		#endregion Model

	}
}

