using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// hhyyz_dx:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hhyyz_dx
	{
		public hhyyz_dx()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _hy_action_flage;
		private string _msm_content;
		private bool _enable= true;
		private int _dxycsj=0;
		private string _msm_content_2;
		private string _msm_content_3;
		private string _msm_content_4;
		private string _msm_content_5;
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
		public string hy_action_flage
		{
			set{ _hy_action_flage=value;}
			get{return _hy_action_flage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msm_content
		{
			set{ _msm_content=value;}
			get{return _msm_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int dxycsj
		{
			set{ _dxycsj=value;}
			get{return _dxycsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msm_content_2
		{
			set{ _msm_content_2=value;}
			get{return _msm_content_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msm_content_3
		{
			set{ _msm_content_3=value;}
			get{return _msm_content_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msm_content_4
		{
			set{ _msm_content_4=value;}
			get{return _msm_content_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string msm_content_5
		{
			set{ _msm_content_5=value;}
			get{return _msm_content_5;}
		}
		#endregion Model

	}
}

