using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// X_judge_void:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class X_judge_void
	{
		public X_judge_void()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _judge_type="";
		private bool _judge_value= false;
		private string _bz="";
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
		/// 判断预先设定的值是否要为空
		/// </summary>
		public string judge_type
		{
			set{ _judge_type=value;}
			get{return _judge_type;}
		}
		/// <summary>
		/// 判断预先设定的值是否要为空
		/// </summary>
		public bool judge_value
		{
			set{ _judge_value=value;}
			get{return _judge_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
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

