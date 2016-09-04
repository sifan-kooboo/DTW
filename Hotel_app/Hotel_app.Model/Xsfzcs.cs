using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xsfzcs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xsfzcs
	{
		public Xsfzcs()
		{}
		#region Model
		private int _id;
		private string _sfdm;
		private string _sfmc;
		private string _csdm;
		private string _csmc;
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
		public string sfdm
		{
			set{ _sfdm=value;}
			get{return _sfdm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sfmc
		{
			set{ _sfmc=value;}
			get{return _sfmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csdm
		{
			set{ _csdm=value;}
			get{return _csdm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csmc
		{
			set{ _csmc=value;}
			get{return _csmc;}
		}
		#endregion Model

	}
}

