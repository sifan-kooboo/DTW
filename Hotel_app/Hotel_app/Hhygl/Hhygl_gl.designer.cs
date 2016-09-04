namespace Hotel_app.Hhygl
{
    partial class Hhygl_gl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hhygl_gl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tB_xsy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_djsj_js = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_djsj_ks = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cB_hyrx = new System.Windows.Forms.ComboBox();
            this.dT_krsr = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_krdz = new System.Windows.Forms.TextBox();
            this.tB_qymc = new System.Windows.Forms.TextBox();
            this.tB_zjhm = new System.Windows.Forms.TextBox();
            this.tB_krsj = new System.Windows.Forms.TextBox();
            this.tB_krxm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_hykh_bz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_amend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tB_xsy);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtp_djsj_js);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtp_djsj_ks);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cB_hyrx);
            this.panel1.Controls.Add(this.dT_krsr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tB_krdz);
            this.panel1.Controls.Add(this.tB_qymc);
            this.panel1.Controls.Add(this.tB_zjhm);
            this.panel1.Controls.Add(this.tB_krsj);
            this.panel1.Controls.Add(this.tB_krxm);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tB_hykh_bz);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 368);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tB_xsy
            // 
            this.tB_xsy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_xsy.Location = new System.Drawing.Point(80, 69);
            this.tB_xsy.Name = "tB_xsy";
            this.tB_xsy.Size = new System.Drawing.Size(219, 26);
            this.tB_xsy.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(9, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 74;
            this.label11.Text = "售卡人";
            // 
            // dtp_djsj_js
            // 
            this.dtp_djsj_js.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_djsj_js.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_djsj_js.Location = new System.Drawing.Point(80, 133);
            this.dtp_djsj_js.Name = "dtp_djsj_js";
            this.dtp_djsj_js.Size = new System.Drawing.Size(219, 26);
            this.dtp_djsj_js.TabIndex = 73;
            this.dtp_djsj_js.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtp_djsj_js.Enter += new System.EventHandler(this.dtp_djsj_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(3, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 72;
            this.label10.Text = "登记时间结束";
            // 
            // dtp_djsj_ks
            // 
            this.dtp_djsj_ks.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_djsj_ks.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_djsj_ks.Location = new System.Drawing.Point(80, 101);
            this.dtp_djsj_ks.Name = "dtp_djsj_ks";
            this.dtp_djsj_ks.Size = new System.Drawing.Size(219, 26);
            this.dtp_djsj_ks.TabIndex = 71;
            this.dtp_djsj_ks.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtp_djsj_ks.Enter += new System.EventHandler(this.dtp_djsj_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "登记时间起始";
            // 
            // cB_hyrx
            // 
            this.cB_hyrx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cB_hyrx.FormattingEnabled = true;
            this.cB_hyrx.Location = new System.Drawing.Point(80, 199);
            this.cB_hyrx.Name = "cB_hyrx";
            this.cB_hyrx.Size = new System.Drawing.Size(221, 24);
            this.cB_hyrx.TabIndex = 69;
            // 
            // dT_krsr
            // 
            this.dT_krsr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_krsr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_krsr.Location = new System.Drawing.Point(80, 294);
            this.dT_krsr.Name = "dT_krsr";
            this.dT_krsr.Size = new System.Drawing.Size(219, 26);
            this.dT_krsr.TabIndex = 68;
            this.dT_krsr.Value = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dT_krsr.Enter += new System.EventHandler(this.dtp_djsj_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 66;
            this.label3.Text = "会员生日";
            // 
            // tB_krdz
            // 
            this.tB_krdz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_krdz.Location = new System.Drawing.Point(80, 326);
            this.tB_krdz.Name = "tB_krdz";
            this.tB_krdz.Size = new System.Drawing.Size(219, 26);
            this.tB_krdz.TabIndex = 65;
            // 
            // tB_qymc
            // 
            this.tB_qymc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_qymc.Location = new System.Drawing.Point(80, 5);
            this.tB_qymc.Name = "tB_qymc";
            this.tB_qymc.Size = new System.Drawing.Size(219, 26);
            this.tB_qymc.TabIndex = 63;
            // 
            // tB_zjhm
            // 
            this.tB_zjhm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_zjhm.Location = new System.Drawing.Point(80, 261);
            this.tB_zjhm.Name = "tB_zjhm";
            this.tB_zjhm.Size = new System.Drawing.Size(219, 26);
            this.tB_zjhm.TabIndex = 62;
            // 
            // tB_krsj
            // 
            this.tB_krsj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_krsj.Location = new System.Drawing.Point(80, 229);
            this.tB_krsj.Name = "tB_krsj";
            this.tB_krsj.Size = new System.Drawing.Size(219, 26);
            this.tB_krsj.TabIndex = 61;
            // 
            // tB_krxm
            // 
            this.tB_krxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_krxm.Location = new System.Drawing.Point(80, 166);
            this.tB_krxm.Name = "tB_krxm";
            this.tB_krxm.Size = new System.Drawing.Size(219, 26);
            this.tB_krxm.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(8, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 57;
            this.label9.Text = "会员地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(3, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 56;
            this.label8.Text = "会员类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "注册地点";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(8, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "证件号码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(5, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "会员手机";
            // 
            // tB_hykh_bz
            // 
            this.tB_hykh_bz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_hykh_bz.Location = new System.Drawing.Point(80, 37);
            this.tB_hykh_bz.Name = "tB_hykh_bz";
            this.tB_hykh_bz.Size = new System.Drawing.Size(219, 26);
            this.tB_hykh_bz.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(5, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "客人姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "会员卡号";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.b_exit);
            this.panel2.Controls.Add(this.b_amend);
            this.panel2.Location = new System.Drawing.Point(324, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 368);
            this.panel2.TabIndex = 2;
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_exit.Location = new System.Drawing.Point(13, 286);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(59, 57);
            this.b_exit.TabIndex = 7;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_amend
            // 
            this.b_amend.BackColor = System.Drawing.SystemColors.Control;
            this.b_amend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_amend.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_amend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_amend.Image = ((System.Drawing.Image)(resources.GetObject("b_amend.Image")));
            this.b_amend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_amend.Location = new System.Drawing.Point(13, 215);
            this.b_amend.Margin = new System.Windows.Forms.Padding(1);
            this.b_amend.Name = "b_amend";
            this.b_amend.Padding = new System.Windows.Forms.Padding(1);
            this.b_amend.Size = new System.Drawing.Size(59, 57);
            this.b_amend.TabIndex = 6;
            this.b_amend.Text = "查询";
            this.b_amend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_amend.UseVisualStyleBackColor = false;
            this.b_amend.Click += new System.EventHandler(this.b_amend_Click);
            // 
            // Hhygl_gl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(423, 392);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Hhygl_gl";
            this.Text = "过虑";
            this.Load += new System.EventHandler(this.Hhygl_gl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tB_krdz;
        private System.Windows.Forms.TextBox tB_qymc;
        private System.Windows.Forms.TextBox tB_zjhm;
        private System.Windows.Forms.TextBox tB_krsj;
        private System.Windows.Forms.TextBox tB_krxm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_hykh_bz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_amend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dT_krsr;
        private System.Windows.Forms.ComboBox cB_hyrx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_djsj_ks;
        private System.Windows.Forms.DateTimePicker dtp_djsj_js;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tB_xsy;
        private System.Windows.Forms.Label label11;
    }
}