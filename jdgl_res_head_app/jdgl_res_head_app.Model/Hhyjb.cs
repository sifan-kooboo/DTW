using System;
namespace jdgl_res_head_app.Model
{
	/// <summary>
	/// Hhyjb:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Hhyjb
	{
		public Hhyjb()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private int _jbxs=0;
		private string _hyrx="";
		private decimal _dfjf=0M;
		private bool _is_top= false;
		private bool _is_select= false;
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
		public int jbxs
		{
			set{ _jbxs=value;}
			get{return _jbxs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hyrx
		{
			set{ _hyrx=value;}
			get{return _hyrx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal dfjf
		{
			set{ _dfjf=value;}
			get{return _dfjf;}
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
		#endregion Model

	}
}

