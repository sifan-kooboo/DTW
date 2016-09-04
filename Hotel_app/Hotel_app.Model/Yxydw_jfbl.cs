using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Yxydw_jfbl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Yxydw_jfbl
	{
		public Yxydw_jfbl()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _krly;
		private decimal _fd_sl=0M;
		private decimal _bl=1M;
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
		public string krly
		{
			set{ _krly=value;}
			get{return _krly;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fd_sl
		{
			set{ _fd_sl=value;}
			get{return _fd_sl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal bl
		{
			set{ _bl=value;}
			get{return _bl;}
		}
		#endregion Model

	}
}

