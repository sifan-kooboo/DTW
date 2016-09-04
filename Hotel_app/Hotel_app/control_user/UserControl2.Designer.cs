namespace Hotel_app.control_user
{
    partial class UserControl2
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.l_roomno = new System.Windows.Forms.Label();
            this.l_room_type = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_roomno
            // 
            this.l_roomno.AutoSize = true;
            this.l_roomno.BackColor = System.Drawing.Color.Transparent;
            this.l_roomno.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_roomno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_roomno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_roomno.Location = new System.Drawing.Point(2, 0);
            this.l_roomno.Name = "l_roomno";
            this.l_roomno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_roomno.Size = new System.Drawing.Size(45, 16);
            this.l_roomno.TabIndex = 18;
            this.l_roomno.Text = "BT4014";
            // 
            // l_room_type
            // 
            this.l_room_type.BackColor = System.Drawing.Color.Plum;
            this.l_room_type.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_room_type.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_room_type.Location = new System.Drawing.Point(4, 16);
            this.l_room_type.Name = "l_room_type";
            this.l_room_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.l_room_type.Size = new System.Drawing.Size(169, 89);
            this.l_room_type.TabIndex = 19;
            this.l_room_type.Text = "豪标";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_room_type);
            this.Controls.Add(this.l_roomno);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(418, 337);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_roomno;
        private System.Windows.Forms.Label l_room_type;
    }
}
