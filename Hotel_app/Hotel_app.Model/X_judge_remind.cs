using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// X_judge_remind:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class X_judge_remind
	{
		public X_judge_remind()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _judge_type;
		private bool _judge_value= false;
		private string _judge_ym;
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
		public string judge_type
		{
			set{ _judge_type=value;}
			get{return _judge_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool judge_value
		{
			set{ _judge_value=value;}
			get{return _judge_value;}
		}
		/// <summary>
		/// 页面
		/// </summary>
		public string judge_ym
		{
			set{ _judge_ym=value;}
			get{return _judge_ym;}
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

