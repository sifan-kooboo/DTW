namespace Hotel_app.Yhgl
{
    partial class YH_User_add_edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YH_User_add_edit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cB_bm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cB_Role = new System.Windows.Forms.ComboBox();
            this.tB_yhbh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tB_yhxm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cB_bm);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cB_Role);
            this.panel1.Controls.Add(this.tB_yhbh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_exit);
            this.panel1.Controls.Add(this.tB_yhxm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 243);
            this.panel1.TabIndex = 8;
            // 
            // cB_bm
            // 
            this.cB_bm.Cursor = System.Windows.Forms.Cursors.Default;
            this.cB_bm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_bm.FormattingEnabled = true;
            this.cB_bm.Location = new System.Drawing.Point(78, 101);
            this.cB_bm.Name = "cB_bm";
            this.cB_bm.Size = new System.Drawing.Size(197, 24);
            this.cB_bm.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "用户部门";
            // 
            // cB_Role
            // 
            this.cB_Role.Cursor = System.Windows.Forms.Cursors.Default;
            this.cB_Role.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_Role.FormattingEnabled = true;
            this.cB_Role.Location = new System.Drawing.Point(78, 142);
            this.cB_Role.Name = "cB_Role";
            this.cB_Role.Size = new System.Drawing.Size(197, 24);
            this.cB_Role.TabIndex = 89;
            // 
            // tB_yhbh
            // 
            this.tB_yhbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhbh.Location = new System.Drawing.Point(78, 16);
            this.tB_yhbh.Name = "tB_yhbh";
            this.tB_yhbh.Size = new System.Drawing.Size(197, 26);
            this.tB_yhbh.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "用户编号";
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(68, 184);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(68, 44);
            this.b_save.TabIndex = 3;
            this.b_save.Text = "保存";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit.Location = new System.Drawing.Point(198, 184);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(68, 44);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tB_yhxm
            // 
            this.tB_yhxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_yhxm.Location = new System.Drawing.Point(78, 60);
            this.tB_yhxm.Name = "tB_yhxm";
            this.tB_yhxm.Size = new System.Drawing.Size(197, 26);
            this.tB_yhxm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户角色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名称";
            // 
            // YH_User_add_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(317, 267);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YH_User_add_edit";
            this.Text = "新增修改用户";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tB_yhbh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;
        public System.Windows.Forms.TextBox tB_yhxm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cB_Role;
        public System.Windows.Forms.ComboBox cB_bm;
        private System.Windows.Forms.Label label4;
    }
}