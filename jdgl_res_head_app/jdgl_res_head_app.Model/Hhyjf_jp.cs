using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhyjf_jp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjf_jp
	{
		public Hhyjf_jp()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _classname="";
		private string _title="";
		private decimal _jpjf=0M;
		private string _simg="";
		private string _bimg="";
		private string _info="";
		private string _bz="";
		private bool _istuijian= false;
		private bool _isshow= false;
		private bool _shsc= false;
		private string _hyjfrx="";
		private bool _is_top= false;
		private bool _is_select= false;
		/// <summary>
		/// 
		/// </summary>
		public int ID
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
		public string classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jpjf
		{
			set{ _jpjf=value;}
			get{return _jpjf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string simg
		{
			set{ _simg=value;}
			get{return _simg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bimg
		{
			set{ _bimg=value;}
			get{return _bimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isTuiJian
		{
			set{ _istuijian=value;}
			get{return _istuijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isshow
		{
			set{ _isshow=value;}
			get{return _isshow;}
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
		public string hyjfrx
		{
			set{ _hyjfrx=value;}
			get{return _hyjfrx;}
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
		#endregion Model

	}
}

