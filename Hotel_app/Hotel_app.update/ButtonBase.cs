/*
 *

 */
 
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace xpButton
{
	#region ButtonStates ENUM
	/// <summary>
	/// Enumeration of Button states
	/// </summary>
	public enum ButtonStates
	{
		/// <summary>
        /// 正常的按钮状态
		/// </summary>
		Normal,
		/// <summary>
		/// 鼠标悬浮在按钮上方
		/// </summary>
		Hover,
		/// <summary>
		/// 按钮被按下
		/// </summary>
		Pushed,
		/// <summary>
		/// 按钮被设为不可用状态
		/// </summary>
		Disabled
	}
	#endregion
	
	/// <summary>
	/// Button Base class implementation
	/// </summary>
    public abstract class ButtonBase : Control
	{
		#region Custom Variables
		protected abstract void PaintNormalState(Graphics g);
		protected abstract void PaintHoverState(Graphics g);
		protected abstract void PaintClickedState(Graphics g);
		protected abstract void PaintDisabledState(Graphics g);
		
		private ButtonStates _state = ButtonStates.Normal;
		private DialogResult _dlgResult = DialogResult.OK;
		
		private Color _bkgcolor1 = Color.FromArgb(214, 214, 214);
		private Color _bkgcolor2 = Color.FromArgb(165, 165, 165);
		#endregion
		
		#region Extended Properties
		///<summary>
		/// Start background color
		///</summary>
		[Description("梯度开始的颜色"),
		Category("梯度颜色")]
		public Color BackColor1
		{
			get{ return _bkgcolor1; }
			set
			{ 
				if( (_bkgcolor1 != value) )
				{
					_bkgcolor1 = value; 
					BackColor = value;
					Invalidate();
				}
			}
		}
		
		///<summary>
		/// End background color
		///</summary>
		[Description("梯度结束的颜色"),
       Category("梯度颜色")]
		public Color BackColor2
		{
			get{ return _bkgcolor2; }
			set
			{ 
				if( (_bkgcolor2 != value) )
				{
					_bkgcolor2 = value; 
					Invalidate();
				}
			}
		}
		
		protected ButtonStates StateOfButton
		{
			get{ return _state; }
			set
			{
				if(value != _state)
				{
					_state = value;
					Invalidate();
				}
			}
		}
		
		///<summary>
		/// button的会话结果
		///</summary>
		[Description("被返回的会话窗口的结果"),
		Category("会话结果")]
		public DialogResult DialogResult
		{
			get{ return _dlgResult; }
			set{ _dlgResult = value; }
		}
		
		public override string Text
		{
			get{ return base.Text; }
			set
			{
				if(value != base.Text)
				{
					base.Text = value;
					Invalidate();
				}
			}
		}
		
		#endregion
		
		#region Virtual Methods
		
		/// <returns></returns>
		protected virtual bool HitTest(int X, int Y)
		{
			return true;
		}

		protected virtual void PaintFocusRectangle(Graphics g)
		{
			ControlPaint.DrawFocusRectangle(g, this.ClientRectangle);
		}

		
		public virtual void OnNotifyDefault(bool value)
		{
			
		}
		
		/// <summary>
        ///  在WndProc中指定WM_NOTIFY消息
	    /// </summary>
		/// <param name="value">boolean value</param>
		public void NotifyDefault(bool value)
		{
			OnNotifyDefault(value);
		}
		#endregion
		
		#region Methods over-riden
		
		protected override void OnEnabledChanged(EventArgs e)
		{
			if(!Enabled)
				StateOfButton = ButtonStates.Disabled;
			else if(Enabled && StateOfButton == ButtonStates.Disabled)
				StateOfButton = ButtonStates.Normal;

			Invalidate();
			
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{			
			switch(StateOfButton)
			{
				case ButtonStates.Normal:
					PaintNormalState(e.Graphics);
					break;
				case ButtonStates.Hover:
					PaintHoverState(e.Graphics);
					break;
				case ButtonStates.Pushed:
					PaintClickedState(e.Graphics);
					break;
				case ButtonStates.Disabled:
					PaintDisabledState(e.Graphics);
					break;
			}

			if(this.Focused && StateOfButton != ButtonStates.Disabled)
				PaintFocusRectangle(e.Graphics);
		}
		
		protected override void OnClick(EventArgs e)
		{
			if(StateOfButton == ButtonStates.Pushed)
				base.OnClick(e);
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(StateOfButton == ButtonStates.Disabled)
				return;

			if(HitTest(e.X, e.Y))
			{
				if(StateOfButton != ButtonStates.Pushed)
					StateOfButton = ButtonStates.Hover;
			}
			else
				StateOfButton = ButtonStates.Normal;
			
			Invalidate();
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			if(StateOfButton == ButtonStates.Disabled)
				return;
			else
				StateOfButton = ButtonStates.Normal;
			
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(StateOfButton == ButtonStates.Disabled)
				return;
			else
				StateOfButton = ButtonStates.Normal;


			if(HitTest(e.X, e.Y))
			{
				if((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					StateOfButton = ButtonStates.Pushed;
					Focus();
				}
			}
			
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(StateOfButton == ButtonStates.Disabled)
				return;
			else
				StateOfButton = ButtonStates.Normal;

			if((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				if(HitTest(e.X, e.Y))
					StateOfButton = ButtonStates.Hover;
				else
					StateOfButton = ButtonStates.Normal;
			}
			
			Invalidate();
		}
		
		#endregion
	}
}
