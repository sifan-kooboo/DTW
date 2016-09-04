namespace Hotel_app.Xxtsz
{
    partial class Frm_txftsz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_txftsz));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_save = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_TestServer = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_webserver = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_SysteVersion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_ft = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tB_ft_sl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tB_ft_distance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 263);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 47);
            this.panel1.TabIndex = 20;
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Control;
            this.b_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_save.Location = new System.Drawing.Point(64, 6);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(70, 38);
            this.b_save.TabIndex = 12;
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
            this.b_exit.Location = new System.Drawing.Point(224, 6);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(70, 38);
            this.b_exit.TabIndex = 13;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.b_TestServer);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.tb_webserver);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tb_SysteVersion);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(4, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 71);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它信息";
            // 
            // b_TestServer
            // 
            this.b_TestServer.BackColor = System.Drawing.SystemColors.Control;
            this.b_TestServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_TestServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_TestServer.Location = new System.Drawing.Point(294, 12);
            this.b_TestServer.Name = "b_TestServer";
            this.b_TestServer.Size = new System.Drawing.Size(69, 27);
            this.b_TestServer.TabIndex = 30;
            this.b_TestServer.Text = "测试连接...";
            this.b_TestServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_TestServer.UseVisualStyleBackColor = false;
            this.b_TestServer.Click += new System.EventHandler(this.b_TestServer_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(277, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 25;
            this.label14.Text = "*";
            // 
            // tb_webserver
            // 
            this.tb_webserver.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_webserver.Location = new System.Drawing.Point(76, 16);
            this.tb_webserver.Name = "tb_webserver";
            this.tb_webserver.Size = new System.Drawing.Size(195, 23);
            this.tb_webserver.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "远程URI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "系统版本号";
            // 
            // tb_SysteVersion
            // 
            this.tb_SysteVersion.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SysteVersion.Location = new System.Drawing.Point(76, 43);
            this.tb_SysteVersion.Name = "tb_SysteVersion";
            this.tb_SysteVersion.ReadOnly = true;
            this.tb_SysteVersion.Size = new System.Drawing.Size(286, 23);
            this.tb_SysteVersion.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_ft);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tB_ft_sl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tB_ft_distance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图形房态界面信息";
            // 
            // cb_ft
            // 
            this.cb_ft.FormattingEnabled = true;
            this.cb_ft.Items.AddRange(new object[] {
            "精简房态",
            "详细房态"});
            this.cb_ft.Location = new System.Drawing.Point(129, 94);
            this.cb_ft.Name = "cb_ft";
            this.cb_ft.Size = new System.Drawing.Size(208, 20);
            this.cb_ft.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(348, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(14, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "房态图形设置";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(348, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(348, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "*";
            // 
            // tB_ft_sl
            // 
            this.tB_ft_sl.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_ft_sl.Location = new System.Drawing.Point(129, 29);
            this.tB_ft_sl.Name = "tB_ft_sl";
            this.tB_ft_sl.Size = new System.Drawing.Size(208, 23);
            this.tB_ft_sl.TabIndex = 1;
            this.tB_ft_sl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_qymc_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "水平房间数";
            // 
            // tB_ft_distance
            // 
            this.tB_ft_distance.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_ft_distance.Location = new System.Drawing.Point(129, 58);
            this.tB_ft_distance.Name = "tB_ft_distance";
            this.tB_ft_distance.Size = new System.Drawing.Size(208, 23);
            this.tB_ft_distance.TabIndex = 2;
            this.tB_ft_distance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_qymc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "房间间隔（相素值）";
            // 
            // Frm_txftsz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 263);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_txftsz";
            this.Text = "图形房态参数设置";
            this.Load += new System.EventHandler(this.Frm_txftsz_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_TestServer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_webserver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_SysteVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tB_ft_sl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_ft_distance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ft;
    }
}