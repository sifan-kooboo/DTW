namespace Hotel_app.Ffjzt
{
    partial class Ffjrb_add_edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ffjrb_add_edit));
            this.b_exit = new System.Windows.Forms.Button();
            this.tB_sjjg = new System.Windows.Forms.TextBox();
            this.tB_fjrb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_zyrs = new System.Windows.Forms.TextBox();
            this.tB_fjrb_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_exit.Location = new System.Drawing.Point(164, 192);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(67, 44);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            this.b_exit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            // 
            // tB_sjjg
            // 
            this.tB_sjjg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_sjjg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tB_sjjg.Location = new System.Drawing.Point(75, 104);
            this.tB_sjjg.Name = "tB_sjjg";
            this.tB_sjjg.Size = new System.Drawing.Size(184, 26);
            this.tB_sjjg.TabIndex = 2;
            this.tB_sjjg.Text = "0";
            this.tB_sjjg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            this.tB_sjjg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_sjjg_KeyPress);
            // 
            // tB_fjrb
            // 
            this.tB_fjrb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_fjrb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tB_fjrb.Location = new System.Drawing.Point(75, 62);
            this.tB_fjrb.Name = "tB_fjrb";
            this.tB_fjrb.Size = new System.Drawing.Size(184, 26);
            this.tB_fjrb.TabIndex = 1;
            this.tB_fjrb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tB_zyrs);
            this.panel1.Controls.Add(this.tB_fjrb_code);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_exit);
            this.panel1.Controls.Add(this.tB_sjjg);
            this.panel1.Controls.Add(this.tB_fjrb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 256);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 58;
            this.label4.Text = "预占人数";
            // 
            // tB_zyrs
            // 
            this.tB_zyrs.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_zyrs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tB_zyrs.Location = new System.Drawing.Point(75, 145);
            this.tB_zyrs.Name = "tB_zyrs";
            this.tB_zyrs.Size = new System.Drawing.Size(184, 26);
            this.tB_zyrs.TabIndex = 57;
            this.tB_zyrs.Text = "1";
            this.tB_zyrs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            this.tB_zyrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_zyrs_KeyPress);
            // 
            // tB_fjrb_code
            // 
            this.tB_fjrb_code.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_fjrb_code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tB_fjrb_code.Location = new System.Drawing.Point(75, 21);
            this.tB_fjrb_code.Name = "tB_fjrb_code";
            this.tB_fjrb_code.Size = new System.Drawing.Size(184, 26);
            this.tB_fjrb_code.TabIndex = 0;
            this.tB_fjrb_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 56;
            this.label3.Text = "代码";
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(28, 192);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(67, 44);
            this.b_save.TabIndex = 3;
            this.b_save.Text = "保存";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            this.b_save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_fjrb_code_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "房价";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "房型";
            // 
            // Ffjrb_add_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(319, 279);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ffjrb_add_edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "房型";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tB_sjjg;
        public System.Windows.Forms.TextBox tB_fjrb;
        public System.Windows.Forms.TextBox tB_fjrb_code;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tB_zyrs;
    }
}