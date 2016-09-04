using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ssyxfmx_kc_sh_temp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ssyxfmx_kc_sh_temp
	{
		public Ssyxfmx_kc_sh_temp()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private bool _is_top;
		private bool _is_select;
		private string _id_app;
		private DateTime _ckecktime;
		private DateTime _xfsj;
		private string _mxbh;
		private decimal _xfsl;
		private decimal _xfje;
		private string _xfxm;
		private bool _ischecked;
		private string _xftm;
		private DateTime _tjrq;
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
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ckeckTime
		{
			set{ _ckecktime=value;}
			get{return _ckecktime;}
		}
		/// <summary>
		/// 记录消费品的消费时间
		/// </summary>
		public DateTime xfsj
		{
			set{ _xfsj=value;}
			get{return _xfsj;}
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
		public decimal xfsl
		{
			set{ _xfsl=value;}
			get{return _xfsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xfxm
		{
			set{ _xfxm=value;}
			get{return _xfxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ischecked
		{
			set{ _ischecked=value;}
			get{return _ischecked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xftm
		{
			set{ _xftm=value;}
			get{return _xftm;}
		}
		/// <summary>
		/// 计录消费品的统计日期（有可能是以前消费的，但是今天或者以后列入统计的)
		/// </summary>
		public DateTime tjrq
		{
			set{ _tjrq=value;}
			get{return _tjrq;}
		}
		#endregion Model

	}
}

