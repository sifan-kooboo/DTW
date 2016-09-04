using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// BS_g_j_fx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_g_j_fx
	{
		public BS_g_j_fx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _jzzt;
		private string _type;
		private decimal _zfh;
		private decimal _ds;
		private decimal _qt;
		private decimal _zyye;
		private decimal _zzz;
		private decimal _zgz_zjz;
		private decimal _zsz;
		private decimal _wj;
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
		/// 挂账单位/或记账主体
		/// </summary>
		public string jzzt
		{
			set{ _jzzt=value;}
			get{return _jzzt;}
		}
		/// <summary>
		/// 是挂账gz还是记账jz
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
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
		/// 代收
		/// </summary>
		public decimal ds
		{
			set{ _ds=value;}
			get{return _ds;}
		}
		/// <summary>
		/// 其他
		/// </summary>
		public decimal qt
		{
			set{ _qt=value;}
			get{return _qt;}
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
		/// 转在住
		/// </summary>
		public decimal zzz
		{
			set{ _zzz=value;}
			get{return _zzz;}
		}
		/// <summary>
		/// 转记账
		/// </summary>
		public decimal zgz_zjz
		{
			set{ _zgz_zjz=value;}
			get{return _zgz_zjz;}
		}
		/// <summary>
		/// 转结账
		/// </summary>
		public decimal zsz
		{
			set{ _zsz=value;}
			get{return _zsz;}
		}
		/// <summary>
		/// 未结
		/// </summary>
		public decimal wj
		{
			set{ _wj=value;}
			get{return _wj;}
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

