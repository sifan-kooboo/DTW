using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Hhy_cs_qy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhy_cs_qy
	{
		public Hhy_cs_qy()
		{}
		#region Model
		private int _id;
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

