using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xxfmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xxfmx
	{
		public Xxfmx()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _drbh="";
		private string _xfdr="";
		private string _xrbh="";
		private string _xfxr="";
		private string _mxbh="";
		private string _xfmx="";
		private string _zjm="";
		private string _xfgg="";
		private decimal _jjje=0M;
		private decimal _xfje=0M;
		private string _xftm="";
		private bool _is_top= false;
		private bool _is_select= false;
		private string _xf_cd="";
		private string _xf_dw="";
		private string _jldw="";
		private bool _is_tj_kc= false;
		private decimal _kcsl=0M;
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
		public string drbh
		{
			set{ _drbh=value;}
			get{return _drbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfdr
		{
			set{ _xfdr=value;}
			get{return _xfdr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xrbh
		{
			set{ _xrbh=value;}
			get{return _xrbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfxr
		{
			set{ _xfxr=value;}
			get{return _xfxr;}
		}
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
		public string xfmx
		{
			set{ _xfmx=value;}
			get{return _xfmx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zjm
		{
			set{ _zjm=value;}
			get{return _zjm;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string xfgg
		{
			set{ _xfgg=value;}
			get{return _xfgg;}
		}
		/// <summary>
		/// 进价价格
		/// </summary>
		public decimal jjje
		{
			set{ _jjje=value;}
			get{return _jjje;}
		}
		/// <summary>
		/// 消费价格
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 条码
		/// </summary>
		public string xftm
		{
			set{ _xftm=value;}
			get{return _xftm;}
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
		/// 生产地
		/// </summary>
		public string xf_cd
		{
			set{ _xf_cd=value;}
			get{return _xf_cd;}
		}
		/// <summary>
		/// 消费单位
		/// </summary>
		public string xf_dw
		{
			set{ _xf_dw=value;}
			get{return _xf_dw;}
		}
		/// <summary>
		/// 计量单位
		/// </summary>
		public string jldw
		{
			set{ _jldw=value;}
			get{return _jldw;}
		}
		/// <summary>
		/// 是否要统计出入库
		/// </summary>
		public bool is_tj_kc
		{
			set{ _is_tj_kc=value;}
			get{return _is_tj_kc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal kcsl
		{
			set{ _kcsl=value;}
			get{return _kcsl;}
		}
		#endregion Model

	}
}

