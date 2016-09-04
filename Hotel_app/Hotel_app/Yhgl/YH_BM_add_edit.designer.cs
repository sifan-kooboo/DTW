namespace Hotel_app.Yhgl
{
    partial class YH_BM_add_edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YH_BM_add_edit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tB_bm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tB_zjm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tB_bm);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_exit);
            this.panel1.Controls.Add(this.tB_zjm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 206);
            this.panel1.TabIndex = 8;
            // 
            // tB_bm
            // 
            this.tB_bm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_bm.Location = new System.Drawing.Point(91, 30);
            this.tB_bm.Name = "tB_bm";
            this.tB_bm.Size = new System.Drawing.Size(185, 26);
            this.tB_bm.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(13, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 56;
            this.label3.Text = "部门名称";
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(84, 135);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(69, 37);
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
            this.b_exit.Location = new System.Drawing.Point(193, 135);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(69, 37);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tB_zjm
            // 
            this.tB_zjm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_zjm.Location = new System.Drawing.Point(91, 74);
            this.tB_zjm.Name = "tB_zjm";
            this.tB_zjm.Size = new System.Drawing.Size(185, 26);
            this.tB_zjm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "助记码";
            // 
            // YH_BM_add_edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(316, 230);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YH_BM_add_edit";
            this.Text = "用户部门";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tB_bm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;
        public System.Windows.Forms.TextBox tB_zjm;
        private System.Windows.Forms.Label label1;
    }
}