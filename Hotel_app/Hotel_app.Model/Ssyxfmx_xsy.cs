using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Ssyxfmx_xsy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ssyxfmx_xsy
	{
		public Ssyxfmx_xsy()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _xsy;
		private bool _shsc= false;
		private int _xsy_sl=1;
		private string _id_app;
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
		public string xsy
		{
			set{ _xsy=value;}
			get{return _xsy;}
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
		/// //销售员数量，一张单据有可能有两个销售员，销售员可用 | 隔开
		/// </summary>
		public int xsy_sl
		{
			set{ _xsy_sl=value;}
			get{return _xsy_sl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string id_app
		{
			set{ _id_app=value;}
			get{return _id_app;}
		}
		#endregion Model

	}
}

