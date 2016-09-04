using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// X_yw_lang_type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class X_yw_lang_type
	{
		public X_yw_lang_type()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _language_bh;
		private string _language_type;
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
		public string language_bh
		{
			set{ _language_bh=value;}
			get{return _language_bh;}
		}
		/// <summary>
		/// 语言类型，比如英语、日语、韩语等
		/// </summary>
		public string language_type
		{
			set{ _language_type=value;}
			get{return _language_type;}
		}
		#endregion Model

	}
}

