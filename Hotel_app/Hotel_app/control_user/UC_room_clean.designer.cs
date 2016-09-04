namespace Hotel_app.control_user
{
    partial class UC_room_clean
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_room_clean));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.l_room_type = new System.Windows.Forms.Label();
            this.l_roomno = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.l_room_type);
            this.panel1.Controls.Add(this.l_roomno);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 91);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 36);
            this.panel2.TabIndex = 30;
            // 
            // l_room_type
            // 
            this.l_room_type.AutoSize = true;
            this.l_room_type.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_room_type.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.l_room_type.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_room_type.Location = new System.Drawing.Point(2, 20);
            this.l_room_type.Name = "l_room_type";
            this.l_room_type.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_room_type.Size = new System.Drawing.Size(29, 12);
            this.l_room_type.TabIndex = 18;
            this.l_room_type.Text = "豪标";
            // 
            // l_roomno
            // 
            this.l_roomno.AutoSize = true;
            this.l_roomno.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_roomno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.l_roomno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_roomno.Location = new System.Drawing.Point(2, 3);
            this.l_roomno.Name = "l_roomno";
            this.l_roomno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_roomno.Size = new System.Drawing.Size(41, 12);
            this.l_roomno.TabIndex = 17;
            this.l_roomno.Text = "BT4014";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(52, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // UC_room_clean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.Controls.Add(this.panel1);
            this.Name = "UC_room_clean";
            this.Size = new System.Drawing.Size(86, 95);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label l_room_type;
        private System.Windows.Forms.Label l_roomno;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
