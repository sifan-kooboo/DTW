using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ssyxfmx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ssyxfmx
	{
		public Ssyxfmx()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private bool _is_top= false;
		private bool _is_select= false;
		private string _id_app="";
		private string _jzbh="";
		private string _lsbh="";
		private string _krxm="";
		private string _fjrb="";
		private string _fjbh="";
		private string _sktt="";
		private DateTime _xfrq= Convert.ToDateTime("1800-01-01");
		private DateTime _xfsj= Convert.ToDateTime("1800-01-01");
		private string _czy="";
		private string _xfdr="";
		private string _xfrb="";
		private string _xfxm="";
		private string _xfbz="";
		private string _xfzy="";
		private decimal _jjje=0M;
		private decimal _xfje=0M;
		private string _yh="";
		private decimal _sjxfje=0M;
		private decimal _xfsl=0M;
		private bool _shsc= false;
		private string _czy_bc="";
		private bool _is_visible= true;
		private string _mxbh="";
		private DateTime _ddsj= Convert.ToDateTime("1800-01-01");
		private DateTime _lksj= Convert.ToDateTime("1800-01-01");
		private DateTime _czsj= Convert.ToDateTime("1800-01-01");
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
		/// ('识别码')
		/// </summary>
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		/// <summary>
		/// 结账对应的编号
		/// </summary>
		public string jzbh
		{
			set{ _jzbh=value;}
			get{return _jzbh;}
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
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 房类
		/// </summary>
		public string fjrb
		{
			set{ _fjrb=value;}
			get{return _fjrb;}
		}
		/// <summary>
		/// 房号
		/// </summary>
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
		}
		/// <summary>
		/// 记录消费的日期
		/// </summary>
		public DateTime xfrq
		{
			set{ _xfrq=value;}
			get{return _xfrq;}
		}
		/// <summary>
		/// 消费时间
		/// </summary>
		public DateTime xfsj
		{
			set{ _xfsj=value;}
			get{return _xfsj;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string czy
		{
			set{ _czy=value;}
			get{return _czy;}
		}
		/// <summary>
		/// 大类
		/// </summary>
		public string xfdr
		{
			set{ _xfdr=value;}
			get{return _xfdr;}
		}
		/// <summary>
		/// 类别
		/// </summary>
		public string xfrb
		{
			set{ _xfrb=value;}
			get{return _xfrb;}
		}
		/// <summary>
		/// 项目
		/// </summary>
		public string xfxm
		{
			set{ _xfxm=value;}
			get{return _xfxm;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string xfbz
		{
			set{ _xfbz=value;}
			get{return _xfbz;}
		}
		/// <summary>
		/// 摘要
		/// </summary>
		public string xfzy
		{
			set{ _xfzy=value;}
			get{return _xfzy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jjje
		{
			set{ _jjje=value;}
			get{return _jjje;}
		}
		/// <summary>
		/// 参考金额
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 优惠
		/// </summary>
		public string yh
		{
			set{ _yh=value;}
			get{return _yh;}
		}
		/// <summary>
		/// 实际金额
		/// </summary>
		public decimal sjxfje
		{
			set{ _sjxfje=value;}
			get{return _sjxfje;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal xfsl
		{
			set{ _xfsl=value;}
			get{return _xfsl;}
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
		/// 操作员班次
		/// </summary>
		public string czy_bc
		{
			set{ _czy_bc=value;}
			get{return _czy_bc;}
		}
		/// <summary>
		/// 是否隐藏真为可视，假为不可视
		/// </summary>
		public bool is_visible
		{
			set{ _is_visible=value;}
			get{return _is_visible;}
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
		public DateTime ddsj
		{
			set{ _ddsj=value;}
			get{return _ddsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lksj
		{
			set{ _lksj=value;}
			get{return _lksj;}
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

