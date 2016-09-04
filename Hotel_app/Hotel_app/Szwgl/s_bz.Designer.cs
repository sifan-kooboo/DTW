namespace Hotel_app.Szwgl
{
    partial class s_bz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(s_bz));
            this.p_gl_1 = new System.Windows.Forms.Panel();
            this.b_exit1 = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.l_czy = new System.Windows.Forms.Label();
            this.tB_fpcs = new System.Windows.Forms.TextBox();
            this.tB_fpbz = new System.Windows.Forms.TextBox();
            this.l_hykh = new System.Windows.Forms.Label();
            this.p_gl_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_gl_1
            // 
            this.p_gl_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_gl_1.Controls.Add(this.b_exit1);
            this.p_gl_1.Controls.Add(this.b_save);
            this.p_gl_1.Controls.Add(this.l_czy);
            this.p_gl_1.Controls.Add(this.tB_fpcs);
            this.p_gl_1.Controls.Add(this.tB_fpbz);
            this.p_gl_1.Controls.Add(this.l_hykh);
            this.p_gl_1.Location = new System.Drawing.Point(12, 12);
            this.p_gl_1.Name = "p_gl_1";
            this.p_gl_1.Size = new System.Drawing.Size(332, 215);
            this.p_gl_1.TabIndex = 102;
            // 
            // b_exit1
            // 
            this.b_exit1.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit1.Image = ((System.Drawing.Image)(resources.GetObject("b_exit1.Image")));
            this.b_exit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit1.Location = new System.Drawing.Point(224, 154);
            this.b_exit1.Name = "b_exit1";
            this.b_exit1.Size = new System.Drawing.Size(70, 44);
            this.b_exit1.TabIndex = 108;
            this.b_exit1.Text = "退出";
            this.b_exit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit1.UseVisualStyleBackColor = false;
            this.b_exit1.Click += new System.EventHandler(this.b_exit1_Click);
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(98, 154);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(70, 44);
            this.b_save.TabIndex = 107;
            this.b_save.Text = "确认";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // l_czy
            // 
            this.l_czy.AutoSize = true;
            this.l_czy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_czy.Location = new System.Drawing.Point(12, 15);
            this.l_czy.Name = "l_czy";
            this.l_czy.Size = new System.Drawing.Size(53, 12);
            this.l_czy.TabIndex = 106;
            this.l_czy.Text = "发票次数";
            // 
            // tB_fpcs
            // 
            this.tB_fpcs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_fpcs.Location = new System.Drawing.Point(90, 10);
            this.tB_fpcs.Name = "tB_fpcs";
            this.tB_fpcs.Size = new System.Drawing.Size(219, 26);
            this.tB_fpcs.TabIndex = 105;
            this.tB_fpcs.Text = "0";
            this.tB_fpcs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_fpcs_KeyPress);
            // 
            // tB_fpbz
            // 
            this.tB_fpbz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_fpbz.Location = new System.Drawing.Point(90, 43);
            this.tB_fpbz.Multiline = true;
            this.tB_fpbz.Name = "tB_fpbz";
            this.tB_fpbz.Size = new System.Drawing.Size(219, 93);
            this.tB_fpbz.TabIndex = 102;
            // 
            // l_hykh
            // 
            this.l_hykh.AutoSize = true;
            this.l_hykh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_hykh.Location = new System.Drawing.Point(11, 50);
            this.l_hykh.Name = "l_hykh";
            this.l_hykh.Size = new System.Drawing.Size(29, 12);
            this.l_hykh.TabIndex = 100;
            this.l_hykh.Text = "备注";
            // 
            // s_bz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(356, 239);
            this.Controls.Add(this.p_gl_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "s_bz";
            this.Text = "备注";
            this.Load += new System.EventHandler(this.s_bz_Load);
            this.p_gl_1.ResumeLayout(false);
            this.p_gl_1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_gl_1;
        private System.Windows.Forms.Button b_exit1;
        private System.Windows.Forms.Button b_save;
        public System.Windows.Forms.Label l_czy;
        public System.Windows.Forms.TextBox tB_fpcs;
        public System.Windows.Forms.TextBox tB_fpbz;
        public System.Windows.Forms.Label l_hykh;
    }
}