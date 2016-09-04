namespace Hotel_app.Hhygl
{
    partial class Hhygl_hyhk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hhygl_hyhk));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_dk = new System.Windows.Forms.Button();
            this.tB_newkh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_hykh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tB_krxm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_dk);
            this.panel1.Controls.Add(this.tB_newkh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tB_hykh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_exit);
            this.panel1.Controls.Add(this.tB_krxm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 199);
            this.panel1.TabIndex = 9;
            // 
            // bt_dk
            // 
            this.bt_dk.BackColor = System.Drawing.Color.DimGray;
            this.bt_dk.ForeColor = System.Drawing.SystemColors.Window;
            this.bt_dk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_dk.Location = new System.Drawing.Point(231, 108);
            this.bt_dk.Name = "bt_dk";
            this.bt_dk.Size = new System.Drawing.Size(46, 26);
            this.bt_dk.TabIndex = 91;
            this.bt_dk.Text = "读卡";
            this.bt_dk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_dk.UseVisualStyleBackColor = false;
            this.bt_dk.Click += new System.EventHandler(this.bt_dk_Click);
            // 
            // tB_newkh
            // 
            this.tB_newkh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_newkh.Location = new System.Drawing.Point(92, 106);
            this.tB_newkh.Name = "tB_newkh";
            this.tB_newkh.Size = new System.Drawing.Size(133, 26);
            this.tB_newkh.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "新的卡号";
            // 
            // tB_hykh
            // 
            this.tB_hykh.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tB_hykh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_hykh.Location = new System.Drawing.Point(92, 17);
            this.tB_hykh.Name = "tB_hykh";
            this.tB_hykh.ReadOnly = true;
            this.tB_hykh.Size = new System.Drawing.Size(185, 26);
            this.tB_hykh.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 56;
            this.label3.Text = "会员卡号";
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(56, 140);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(67, 44);
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
            this.b_exit.Location = new System.Drawing.Point(179, 140);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(67, 44);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tB_krxm
            // 
            this.tB_krxm.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tB_krxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_krxm.Location = new System.Drawing.Point(92, 61);
            this.tB_krxm.Name = "tB_krxm";
            this.tB_krxm.ReadOnly = true;
            this.tB_krxm.Size = new System.Drawing.Size(185, 26);
            this.tB_krxm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员姓名";
            // 
            // Hhygl_hyhk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(325, 220);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Hhygl_hyhk";
            this.ShowInTaskbar = false;
            this.Text = "换卡";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tB_hykh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;
        public System.Windows.Forms.TextBox tB_krxm;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tB_newkh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_dk;
    }
}