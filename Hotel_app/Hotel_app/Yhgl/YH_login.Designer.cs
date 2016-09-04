namespace Hotel_app.Yhgl
{
    partial class YH_login
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YH_login));
            this.b_yxzj = new System.Windows.Forms.Button();
            this.DG_user = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bS_user = new System.Windows.Forms.BindingSource(this.components);
            this.b_save = new System.Windows.Forms.Button();
            this.cB_syzd = new System.Windows.Forms.ComboBox();
            this.tB_yhbm = new System.Windows.Forms.TextBox();
            this.tB_yhmm = new System.Windows.Forms.TextBox();
            this.tB_yhxm = new System.Windows.Forms.TextBox();
            this.tB_yhbh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.b_help = new System.Windows.Forms.Button();
            this.b_contactUs = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.b_info = new System.Windows.Forms.Button();
            this.b_CheckUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_user)).BeginInit();
            this.SuspendLayout();
            // 
            // b_yxzj
            // 
            this.b_yxzj.BackColor = System.Drawing.Color.Silver;
            this.b_yxzj.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.b_yxzj.Location = new System.Drawing.Point(471, 175);
            this.b_yxzj.Name = "b_yxzj";
            this.b_yxzj.Size = new System.Drawing.Size(57, 32);
            this.b_yxzj.TabIndex = 14;
            this.b_yxzj.Tag = "9999";
            this.b_yxzj.Text = "选择...";
            this.b_yxzj.UseVisualStyleBackColor = false;
            this.b_yxzj.Click += new System.EventHandler(this.b_yxzj_Click);
            // 
            // DG_user
            // 
            this.DG_user.AutoGenerateColumns = false;
            this.DG_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_user.ColumnHeadersVisible = false;
            this.DG_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DG_user.DataSource = this.bS_user;
            this.DG_user.Location = new System.Drawing.Point(528, 176);
            this.DG_user.Name = "DG_user";
            this.DG_user.RowHeadersVisible = false;
            this.DG_user.RowTemplate.Height = 30;
            this.DG_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_user.Size = new System.Drawing.Size(195, 140);
            this.DG_user.TabIndex = 13;
            this.DG_user.Visible = false;
            this.DG_user.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_user_CellDoubleClick);
            this.DG_user.DoubleClick += new System.EventHandler(this.DG_user_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "yhbh";
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "yhxm";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "yhbm";
            this.Column3.HeaderText = "部门";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_save.BackgroundImage")));
            this.b_save.FlatAppearance.BorderSize = 0;
            this.b_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(334, 356);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(60, 27);
            this.b_save.TabIndex = 11;
            this.b_save.Tag = "9999";
            this.b_save.Text = "登 录";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.MouseLeave += new System.EventHandler(this.b_save_MouseLeave);
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            this.b_save.MouseHover += new System.EventHandler(this.b_save_MouseHover);
            // 
            // cB_syzd
            // 
            this.cB_syzd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_syzd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cB_syzd.FormattingEnabled = true;
            this.cB_syzd.Location = new System.Drawing.Point(309, 138);
            this.cB_syzd.Name = "cB_syzd";
            this.cB_syzd.Size = new System.Drawing.Size(222, 29);
            this.cB_syzd.TabIndex = 1;
            this.cB_syzd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_syzd_KeyPress);
            this.cB_syzd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cB_syzd_KeyDown);
            // 
            // tB_yhbm
            // 
            this.tB_yhbm.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tB_yhbm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhbm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tB_yhbm.Location = new System.Drawing.Point(309, 286);
            this.tB_yhbm.Name = "tB_yhbm";
            this.tB_yhbm.ReadOnly = true;
            this.tB_yhbm.Size = new System.Drawing.Size(222, 29);
            this.tB_yhbm.TabIndex = 5;
            this.tB_yhbm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cB_syzd_KeyDown);
            // 
            // tB_yhmm
            // 
            this.tB_yhmm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhmm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tB_yhmm.Location = new System.Drawing.Point(309, 249);
            this.tB_yhmm.Name = "tB_yhmm";
            this.tB_yhmm.PasswordChar = '*';
            this.tB_yhmm.Size = new System.Drawing.Size(222, 29);
            this.tB_yhmm.TabIndex = 4;
            this.tB_yhmm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cB_syzd_KeyDown);
            // 
            // tB_yhxm
            // 
            this.tB_yhxm.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tB_yhxm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhxm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tB_yhxm.Location = new System.Drawing.Point(309, 212);
            this.tB_yhxm.Name = "tB_yhxm";
            this.tB_yhxm.ReadOnly = true;
            this.tB_yhxm.Size = new System.Drawing.Size(222, 29);
            this.tB_yhxm.TabIndex = 3;
            this.tB_yhxm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cB_syzd_KeyDown);
            // 
            // tB_yhbh
            // 
            this.tB_yhbh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhbh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tB_yhbh.Location = new System.Drawing.Point(309, 176);
            this.tB_yhbh.Name = "tB_yhbh";
            this.tB_yhbh.Size = new System.Drawing.Size(156, 29);
            this.tB_yhbh.TabIndex = 2;
            this.tB_yhbh.TextChanged += new System.EventHandler(this.tB_yhbh_TextChanged);
            this.tB_yhbh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cB_syzd_KeyDown);
            this.tB_yhbh.Leave += new System.EventHandler(this.tB_yhbh_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(249, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(249, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "所在部门";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(249, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(249, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(249, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "营业站点";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(685, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 15;
            this.button1.Tag = "9999";
            this.button1.Text = "x";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_help
            // 
            this.b_help.BackColor = System.Drawing.Color.Transparent;
            this.b_help.FlatAppearance.BorderSize = 0;
            this.b_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_help.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_help.ForeColor = System.Drawing.Color.Brown;
            this.b_help.Image = ((System.Drawing.Image)(resources.GetObject("b_help.Image")));
            this.b_help.Location = new System.Drawing.Point(554, 361);
            this.b_help.Name = "b_help";
            this.b_help.Size = new System.Drawing.Size(24, 25);
            this.b_help.TabIndex = 16;
            this.b_help.Tag = "9999";
            this.b_help.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.b_help, "帮助手册");
            this.b_help.UseVisualStyleBackColor = false;
            this.b_help.Click += new System.EventHandler(this.b_help_Click);
            // 
            // b_contactUs
            // 
            this.b_contactUs.BackColor = System.Drawing.Color.Transparent;
            this.b_contactUs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_contactUs.BackgroundImage")));
            this.b_contactUs.FlatAppearance.BorderSize = 0;
            this.b_contactUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_contactUs.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_contactUs.ForeColor = System.Drawing.Color.Brown;
            this.b_contactUs.Image = ((System.Drawing.Image)(resources.GetObject("b_contactUs.Image")));
            this.b_contactUs.Location = new System.Drawing.Point(588, 361);
            this.b_contactUs.Name = "b_contactUs";
            this.b_contactUs.Size = new System.Drawing.Size(29, 25);
            this.b_contactUs.TabIndex = 17;
            this.b_contactUs.Tag = "9999";
            this.b_contactUs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.b_contactUs, "联系我们");
            this.b_contactUs.UseVisualStyleBackColor = false;
            this.b_contactUs.Click += new System.EventHandler(this.b_contactUs_Click);
            // 
            // b_info
            // 
            this.b_info.BackColor = System.Drawing.Color.Transparent;
            this.b_info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_info.BackgroundImage")));
            this.b_info.FlatAppearance.BorderSize = 0;
            this.b_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_info.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_info.ForeColor = System.Drawing.Color.Brown;
            this.b_info.Image = ((System.Drawing.Image)(resources.GetObject("b_info.Image")));
            this.b_info.Location = new System.Drawing.Point(624, 360);
            this.b_info.Name = "b_info";
            this.b_info.Size = new System.Drawing.Size(29, 25);
            this.b_info.TabIndex = 18;
            this.b_info.Tag = "9999";
            this.b_info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.b_info, "关于我们");
            this.b_info.UseVisualStyleBackColor = false;
            this.b_info.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_CheckUpdate
            // 
            this.b_CheckUpdate.BackColor = System.Drawing.Color.Transparent;
            this.b_CheckUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("b_CheckUpdate.BackgroundImage")));
            this.b_CheckUpdate.FlatAppearance.BorderSize = 0;
            this.b_CheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_CheckUpdate.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_CheckUpdate.ForeColor = System.Drawing.Color.Brown;
            this.b_CheckUpdate.Image = ((System.Drawing.Image)(resources.GetObject("b_CheckUpdate.Image")));
            this.b_CheckUpdate.Location = new System.Drawing.Point(656, 358);
            this.b_CheckUpdate.Name = "b_CheckUpdate";
            this.b_CheckUpdate.Size = new System.Drawing.Size(33, 30);
            this.b_CheckUpdate.TabIndex = 19;
            this.b_CheckUpdate.Tag = "9999";
            this.b_CheckUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.b_CheckUpdate, "检查更新");
            this.b_CheckUpdate.UseVisualStyleBackColor = false;
            this.b_CheckUpdate.Click += new System.EventHandler(this.b_CheckUpdate_Click);
            // 
            // YH_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(722, 393);
            this.Controls.Add(this.b_CheckUpdate);
            this.Controls.Add(this.b_info);
            this.Controls.Add(this.b_contactUs);
            this.Controls.Add(this.b_help);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DG_user);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_yxzj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cB_syzd);
            this.Controls.Add(this.tB_yhbm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tB_yhmm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tB_yhxm);
            this.Controls.Add(this.tB_yhbh);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YH_login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.YH_login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YH_login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.YH_login_MouseMove);
            this.MouseHover += new System.EventHandler(this.b_save_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.DG_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_yhbm;
        private System.Windows.Forms.TextBox tB_yhmm;
        private System.Windows.Forms.TextBox tB_yhxm;
        private System.Windows.Forms.TextBox tB_yhbh;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.DataGridView DG_user;
        private System.Windows.Forms.BindingSource bS_user;
        private System.Windows.Forms.Button b_yxzj;
        public System.Windows.Forms.ComboBox cB_syzd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_help;
        private System.Windows.Forms.Button b_contactUs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button b_info;
        private System.Windows.Forms.Button b_CheckUpdate;
    }
}