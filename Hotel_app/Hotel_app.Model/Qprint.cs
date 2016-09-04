using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Qprint:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Qprint
	{
		public Qprint()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _zdtype;
		private string _zdvalue;
		private int _printtimes;
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
		public string zdType
		{
			set{ _zdtype=value;}
			get{return _zdtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zdValue
		{
			set{ _zdvalue=value;}
			get{return _zdvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int printTimes
		{
			set{ _printtimes=value;}
			get{return _printtimes;}
		}
		#endregion Model

	}
}

