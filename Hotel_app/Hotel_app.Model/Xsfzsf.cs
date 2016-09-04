using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Xsfzsf:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Xsfzsf
	{
		public Xsfzsf()
		{}
		#region Model
		private int _id;
		private string _sfdm;
		private string _sfmc;
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
		#endregion Model

	}
}

