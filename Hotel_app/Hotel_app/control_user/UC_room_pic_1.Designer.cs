namespace Hotel_app.control_user
{
    partial class UC_room_pic_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_room_pic_1));
            this.p_range = new System.Windows.Forms.Panel();
            this.l_room_type = new System.Windows.Forms.Label();
            this.l_roomno = new System.Windows.Forms.Label();
            this.pB_room_special = new System.Windows.Forms.PictureBox();
            this.pB_arrival = new System.Windows.Forms.PictureBox();
            this.p_range.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_room_special)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_arrival)).BeginInit();
            this.SuspendLayout();
            // 
            // p_range
            // 
            this.p_range.BackColor = System.Drawing.Color.LightCoral;
            this.p_range.Controls.Add(this.pB_room_special);
            this.p_range.Controls.Add(this.pB_arrival);
            this.p_range.Controls.Add(this.l_room_type);
            this.p_range.Controls.Add(this.l_roomno);
            this.p_range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_range.Location = new System.Drawing.Point(0, 0);
            this.p_range.Name = "p_range";
            this.p_range.Size = new System.Drawing.Size(63, 53);
            this.p_range.TabIndex = 0;
            // 
            // l_room_type
            // 
            this.l_room_type.BackColor = System.Drawing.Color.Transparent;
            this.l_room_type.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_room_type.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_room_type.Location = new System.Drawing.Point(2, 18);
            this.l_room_type.Name = "l_room_type";
            this.l_room_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.l_room_type.Size = new System.Drawing.Size(41, 15);
            this.l_room_type.TabIndex = 41;
            this.l_room_type.Text = "豪标豪标豪标";
            this.l_room_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_roomno
            // 
            this.l_roomno.AutoSize = true;
            this.l_roomno.BackColor = System.Drawing.Color.Transparent;
            this.l_roomno.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_roomno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_roomno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_roomno.Location = new System.Drawing.Point(1, 1);
            this.l_roomno.Name = "l_roomno";
            this.l_roomno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_roomno.Size = new System.Drawing.Size(45, 16);
            this.l_roomno.TabIndex = 40;
            this.l_roomno.Text = "BT4014";
            // 
            // pB_room_special
            // 
            this.pB_room_special.BackColor = System.Drawing.Color.Transparent;
            //this.pB_room_special.Image = global::Hotel_app.Properties.Resources.c_10;
            this.pB_room_special.Location = new System.Drawing.Point(44, 3);
            this.pB_room_special.Name = "pB_room_special";
            this.pB_room_special.Size = new System.Drawing.Size(17, 16);
            this.pB_room_special.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB_room_special.TabIndex = 43;
            this.pB_room_special.TabStop = false;
            // 
            // pB_arrival
            // 
            this.pB_arrival.BackColor = System.Drawing.Color.Transparent;
            this.pB_arrival.Image = ((System.Drawing.Image)(resources.GetObject("pB_arrival.Image")));
            this.pB_arrival.Location = new System.Drawing.Point(3, 35);
            this.pB_arrival.Name = "pB_arrival";
            this.pB_arrival.Size = new System.Drawing.Size(17, 16);
            this.pB_arrival.TabIndex = 42;
            this.pB_arrival.TabStop = false;
            // 
            // UC_room_pic_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_range);
            this.Name = "UC_room_pic_1";
            this.Size = new System.Drawing.Size(63, 53);
            this.p_range.ResumeLayout(false);
            this.p_range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_room_special)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_arrival)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_range;
        private System.Windows.Forms.PictureBox pB_arrival;
        private System.Windows.Forms.Label l_room_type;
        private System.Windows.Forms.Label l_roomno;
        private System.Windows.Forms.PictureBox pB_room_special;

    }
}
