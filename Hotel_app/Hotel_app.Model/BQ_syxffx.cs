using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BQ_syxffx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BQ_syxffx
	{
		public BQ_syxffx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _type;
		private string _fxdr;
		private string _fxrb;
		private decimal _zyye;
		private decimal _zfh;
		private decimal _czfs;
		private string _pjczl;
		private string _xd_pjczl;
		private string _pjbl;
		private string _xd_pjbl;
		private decimal _pjfj;
		private decimal _jcb;
		private string _czy_temp;
		private DateTime _cssj;
		private DateTime _jssj;
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
		/// 类型如xsy,krly,xydw等
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 主要放像krly,xsy这种大类
		/// </summary>
		public string fxdr
		{
			set{ _fxdr=value;}
			get{return _fxdr;}
		}
		/// <summary>
		/// 项目-分析别，像客人来源，协议单位，销售员等
		/// </summary>
		public string fxrb
		{
			set{ _fxrb=value;}
			get{return _fxrb;}
		}
		/// <summary>
		/// 营业额
		/// </summary>
		public decimal zyye
		{
			set{ _zyye=value;}
			get{return _zyye;}
		}
		/// <summary>
		/// 房费
		/// </summary>
		public decimal zfh
		{
			set{ _zfh=value;}
			get{return _zfh;}
		}
		/// <summary>
		/// 房数
		/// </summary>
		public decimal czfs
		{
			set{ _czfs=value;}
			get{return _czfs;}
		}
		/// <summary>
		/// 出租率
		/// </summary>
		public string pjczl
		{
			set{ _pjczl=value;}
			get{return _pjczl;}
		}
		/// <summary>
		/// 相对比率
		/// </summary>
		public string xd_pjczl
		{
			set{ _xd_pjczl=value;}
			get{return _xd_pjczl;}
		}
		/// <summary>
		/// 消费占比
		/// </summary>
		public string pjbl
		{
			set{ _pjbl=value;}
			get{return _pjbl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xd_pjbl
		{
			set{ _xd_pjbl=value;}
			get{return _xd_pjbl;}
		}
		/// <summary>
		/// 平均房价
		/// </summary>
		public decimal pjfj
		{
			set{ _pjfj=value;}
			get{return _pjfj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jcb
		{
			set{ _jcb=value;}
			get{return _jcb;}
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
		public DateTime cssj
		{
			set{ _cssj=value;}
			get{return _cssj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime jssj
		{
			set{ _jssj=value;}
			get{return _jssj;}
		}
		#endregion Model

	}
}

