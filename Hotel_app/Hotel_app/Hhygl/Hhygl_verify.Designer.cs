namespace Hotel_app.Hhygl
{
    partial class Hhygl_verify
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
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_getCode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.b_confirm = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_code
            // 
            this.txt_code.Font = new System.Drawing.Font("宋体", 18F);
            this.txt_code.Location = new System.Drawing.Point(61, 26);
            this.txt_code.Multiline = true;
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(182, 35);
            this.txt_code.TabIndex = 0;
            this.txt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "验证码";
            // 
            // b_getCode
            // 
            this.b_getCode.FlatAppearance.BorderSize = 0;
            this.b_getCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_getCode.Location = new System.Drawing.Point(61, 67);
            this.b_getCode.Name = "b_getCode";
            this.b_getCode.Size = new System.Drawing.Size(126, 29);
            this.b_getCode.TabIndex = 2;
            this.b_getCode.Text = "点击获取验证码";
            this.b_getCode.UseVisualStyleBackColor = true;
            this.b_getCode.Click += new System.EventHandler(this.b_getCode_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // b_confirm
            // 
            this.b_confirm.FlatAppearance.BorderSize = 0;
            this.b_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_confirm.Location = new System.Drawing.Point(249, 30);
            this.b_confirm.Name = "b_confirm";
            this.b_confirm.Size = new System.Drawing.Size(53, 33);
            this.b_confirm.TabIndex = 3;
            this.b_confirm.Text = "验证";
            this.b_confirm.UseVisualStyleBackColor = true;
            this.b_confirm.Click += new System.EventHandler(this.b_confirm_Click);
            // 
            // b_exit
            // 
            this.b_exit.FlatAppearance.BorderSize = 0;
            this.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_exit.Location = new System.Drawing.Point(171, 65);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(87, 31);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "下次验证";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // Hhygl_verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(347, 107);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.b_confirm);
            this.Controls.Add(this.b_getCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hhygl_verify";
            this.Text = "Hhygl_verify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_getCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_confirm;
        private System.Windows.Forms.Button b_exit;
    }
}