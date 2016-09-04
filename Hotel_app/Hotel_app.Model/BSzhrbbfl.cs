using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BSzhrbbfl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BSzhrbbfl
	{
		public BSzhrbbfl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private DateTime _bbrq;
		private decimal _zfs=0M;
		private decimal _zyye=0M;
		private decimal _zfh=0M;
		private decimal _czfs=0M;
		private string _pjczl="0%";
		private decimal _pjfj=0M;
		private decimal _jcb=0M;
		private decimal _wjds=0M;
		private decimal _gztj=0M;
		private decimal _jztj=0M;
		private decimal _sztj=0M;
		private decimal _yjds=0M;
		private decimal _ljwj=0M;
		private decimal _ljyf=0M;
		private decimal _ljgz=0M;
		private decimal _ljjz=0M;
		private bool _shsc= false;
		private decimal _pjczl_nu=0M;
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
		public DateTime bbrq
		{
			set{ _bbrq=value;}
			get{return _bbrq;}
		}
		/// <summary>
		/// 总房数（合计）
		/// </summary>
		public decimal zfs
		{
			set{ _zfs=value;}
			get{return _zfs;}
		}
		/// <summary>
		/// 总营业额（合计）
		/// </summary>
		public decimal zyye
		{
			set{ _zyye=value;}
			get{return _zyye;}
		}
		/// <summary>
		/// 总房费（合计）
		/// </summary>
		public decimal zfh
		{
			set{ _zfh=value;}
			get{return _zfh;}
		}
		/// <summary>
		/// 出租房数（合计）
		/// </summary>
		public decimal czfs
		{
			set{ _czfs=value;}
			get{return _czfs;}
		}
		/// <summary>
		/// 平均出租率（合计czfs/合计zfs）
		/// </summary>
		public string pjczl
		{
			set{ _pjczl=value;}
			get{return _pjczl;}
		}
		/// <summary>
		/// 平均房价（合计zfh/合计czfs）
		/// </summary>
		public decimal pjfj
		{
			set{ _pjfj=value;}
			get{return _pjfj;}
		}
		/// <summary>
		/// 交叉比(pjczl*pjfj)
		/// </summary>
		public decimal jcb
		{
			set{ _jcb=value;}
			get{return _jcb;}
		}
		/// <summary>
		/// 未结代收（合计）
		/// </summary>
		public decimal wjds
		{
			set{ _wjds=value;}
			get{return _wjds;}
		}
		/// <summary>
		/// 挂账（合计）
		/// </summary>
		public decimal gztj
		{
			set{ _gztj=value;}
			get{return _gztj;}
		}
		/// <summary>
		/// 记账（合计）
		/// </summary>
		public decimal jztj
		{
			set{ _jztj=value;}
			get{return _jztj;}
		}
		/// <summary>
		/// 已结（合计）
		/// </summary>
		public decimal sztj
		{
			set{ _sztj=value;}
			get{return _sztj;}
		}
		/// <summary>
		/// 已结代收（合计）
		/// </summary>
		public decimal yjds
		{
			set{ _yjds=value;}
			get{return _yjds;}
		}
		/// <summary>
		/// 未结合计（累计保持）
		/// </summary>
		public decimal ljwj
		{
			set{ _ljwj=value;}
			get{return _ljwj;}
		}
		/// <summary>
		/// 预付（累计保持）
		/// </summary>
		public decimal ljyf
		{
			set{ _ljyf=value;}
			get{return _ljyf;}
		}
		/// <summary>
		/// 未结挂账（累计保持）
		/// </summary>
		public decimal ljgz
		{
			set{ _ljgz=value;}
			get{return _ljgz;}
		}
		/// <summary>
		/// 未结记账（累计保持）
		/// </summary>
		public decimal ljjz
		{
			set{ _ljjz=value;}
			get{return _ljjz;}
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
		public decimal pjczl_nu
		{
			set{ _pjczl_nu=value;}
			get{return _pjczl_nu;}
		}
		#endregion Model

	}
}

