using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhyyz:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyyz
	{
		public Hhyyz()
		{}
		#region Model
		private int _id;
		private string _krxm;
		private string _hysj;
		private string _yzm;
		private DateTime _yzdate;
		private bool _yzzt;
		private string _yydh;
		private string _qymc;
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
		public string krxm
		{
			set{ _krxm=value;}
			get{return _krxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hysj
		{
			set{ _hysj=value;}
			get{return _hysj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yzm
		{
			set{ _yzm=value;}
			get{return _yzm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime yzdate
		{
			set{ _yzdate=value;}
			get{return _yzdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool yzzt
		{
			set{ _yzzt=value;}
			get{return _yzzt;}
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
		#endregion Model

	}
}

