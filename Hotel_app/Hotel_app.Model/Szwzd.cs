using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// Szwzd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Szwzd
	{
		public Szwzd()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _lsbh="";
		private string _krxm="";
		private string _sktt="";
		private string _yddj="";
		private string _fjbh="";
		private decimal _fkje=0M;
		private decimal _xfje=0M;
		private string _main_sec="main";
		private bool _is_top= false;
		private bool _is_select= false;
		private bool _is_ffzf;
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
		public string lsbh
		{
			set{ _lsbh=value;}
			get{return _lsbh;}
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
		public string sktt
		{
			set{ _sktt=value;}
			get{return _sktt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yddj
		{
			set{ _yddj=value;}
			get{return _yddj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fjbh
		{
			set{ _fjbh=value;}
			get{return _fjbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal fkje
		{
			set{ _fkje=value;}
			get{return _fkje;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal xfje
		{
			set{ _xfje=value;}
			get{return _xfje;}
		}
		/// <summary>
		/// 当两张单子共用一个房间时,第二条单据要先设置成sec才能配置
		/// </summary>
		public string main_sec
		{
			set{ _main_sec=value;}
			get{return _main_sec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_top
		{
			set{ _is_top=value;}
			get{return _is_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_select
		{
			set{ _is_select=value;}
			get{return _is_select;}
		}
		/// <summary>
		/// 指示说明该房间是否自付房费（2013－05－02增加）
		/// </summary>
		public bool is_ffzf
		{
			set{ _is_ffzf=value;}
			get{return _is_ffzf;}
		}
		#endregion Model

	}
}

