﻿namespace Hotel_app.BBfx
{
    partial class Frm_BB_hyk_xfmxfx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BB_hyk_xfmxfx));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.M_gl = new System.Windows.Forms.ToolStripMenuItem();
            this.M_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.p_gl = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_hykh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_xsy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_jssj = new System.Windows.Forms.DateTimePicker();
            this.dtp_cssj = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.b_outport = new System.Windows.Forms.Button();
            this.b_print = new System.Windows.Forms.Button();
            this.b_last = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_previous = new System.Windows.Forms.Button();
            this.b_first = new System.Windows.Forms.Button();
            this.b_gl = new System.Windows.Forms.Button();
            this.b_refresh = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.b_exit = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.p_gl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_gl,
            this.M_refresh,
            this.打印ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // M_gl
            // 
            this.M_gl.Name = "M_gl";
            this.M_gl.Size = new System.Drawing.Size(100, 22);
            this.M_gl.Text = "过滤";
            this.M_gl.Click += new System.EventHandler(this.M_gl_Click);
            // 
            // M_refresh
            // 
            this.M_refresh.Name = "M_refresh";
            this.M_refresh.Size = new System.Drawing.Size(100, 22);
            this.M_refresh.Text = "刷新";
            this.M_refresh.Click += new System.EventHandler(this.M_refresh_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 730);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.p_gl);
            this.panel4.Controls.Add(this.crystalReportViewer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 669);
            this.panel4.TabIndex = 2;
            // 
            // p_gl
            // 
            this.p_gl.BackColor = System.Drawing.SystemColors.Control;
            this.p_gl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_gl.Controls.Add(this.groupBox1);
            this.p_gl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Underline);
            this.p_gl.Location = new System.Drawing.Point(0, 16);
            this.p_gl.Name = "p_gl";
            this.p_gl.Size = new System.Drawing.Size(304, 258);
            this.p_gl.TabIndex = 44;
            this.p_gl.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 250);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tb_hykh);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.tb_xsy);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.dtp_jssj);
            this.panel5.Controls.Add(this.dtp_cssj);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Font = new System.Drawing.Font("宋体", 12F);
            this.panel5.Location = new System.Drawing.Point(8, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(277, 156);
            this.panel5.TabIndex = 100;
            // 
            // tb_hykh
            // 
            this.tb_hykh.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_hykh.ForeColor = System.Drawing.Color.Red;
            this.tb_hykh.Location = new System.Drawing.Point(72, 48);
            this.tb_hykh.Name = "tb_hykh";
            this.tb_hykh.Size = new System.Drawing.Size(186, 26);
            this.tb_hykh.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 113;
            this.label1.Text = "会员卡号";
            // 
            // tb_xsy
            // 
            this.tb_xsy.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_xsy.ForeColor = System.Drawing.Color.Red;
            this.tb_xsy.Location = new System.Drawing.Point(72, 16);
            this.tb_xsy.Name = "tb_xsy";
            this.tb_xsy.Size = new System.Drawing.Size(186, 26);
            this.tb_xsy.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 111;
            this.label3.Text = "销售员";
            // 
            // dtp_jssj
            // 
            this.dtp_jssj.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_jssj.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_jssj.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtp_jssj.Font = new System.Drawing.Font("宋体", 12F);
            this.dtp_jssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_jssj.Location = new System.Drawing.Point(72, 116);
            this.dtp_jssj.Name = "dtp_jssj";
            this.dtp_jssj.Size = new System.Drawing.Size(186, 26);
            this.dtp_jssj.TabIndex = 108;
            this.dtp_jssj.Value = new System.DateTime(2012, 5, 15, 0, 0, 0, 0);
            this.dtp_jssj.ValueChanged += new System.EventHandler(this.dtp_cssj_ValueChanged);
            this.dtp_jssj.Enter += new System.EventHandler(this.dtp_cssj_Enter);
            // 
            // dtp_cssj
            // 
            this.dtp_cssj.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_cssj.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_cssj.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtp_cssj.Font = new System.Drawing.Font("宋体", 12F);
            this.dtp_cssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_cssj.Location = new System.Drawing.Point(72, 83);
            this.dtp_cssj.Name = "dtp_cssj";
            this.dtp_cssj.Size = new System.Drawing.Size(186, 26);
            this.dtp_cssj.TabIndex = 107;
            this.dtp_cssj.Value = new System.DateTime(2012, 5, 15, 0, 0, 0, 0);
            this.dtp_cssj.Enter += new System.EventHandler(this.dtp_cssj_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 106;
            this.label5.Text = "结束时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(13, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 104;
            this.label6.Text = "起始时间";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Location = new System.Drawing.Point(8, 187);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(277, 55);
            this.panel7.TabIndex = 101;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(157, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(1);
            this.button1.Size = new System.Drawing.Size(74, 42);
            this.button1.TabIndex = 103;
            this.button1.Text = "退出";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.b_gl_exit_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(53, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(1);
            this.button2.Size = new System.Drawing.Size(74, 42);
            this.button2.TabIndex = 102;
            this.button2.Text = "查询";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.b_search_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.ContextMenuStrip = this.contextMenuStrip1;
            this.crystalReportViewer1.DisplayBackgroundEdge = false;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.DisplayToolbar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1008, 669);
            this.crystalReportViewer1.TabIndex = 43;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 719);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 11);
            this.panel3.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 11);
            this.progressBar1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 50);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.b_outport);
            this.panel6.Controls.Add(this.b_print);
            this.panel6.Controls.Add(this.b_last);
            this.panel6.Controls.Add(this.b_next);
            this.panel6.Controls.Add(this.b_previous);
            this.panel6.Controls.Add(this.b_first);
            this.panel6.Controls.Add(this.b_gl);
            this.panel6.Controls.Add(this.b_refresh);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 50);
            this.panel6.TabIndex = 42;
            // 
            // b_outport
            // 
            this.b_outport.Image = ((System.Drawing.Image)(resources.GetObject("b_outport.Image")));
            this.b_outport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_outport.Location = new System.Drawing.Point(145, 6);
            this.b_outport.Name = "b_outport";
            this.b_outport.Size = new System.Drawing.Size(40, 40);
            this.b_outport.TabIndex = 82;
            this.b_outport.UseVisualStyleBackColor = true;
            this.b_outport.Click += new System.EventHandler(this.b_outport_Click);
            // 
            // b_print
            // 
            this.b_print.Image = ((System.Drawing.Image)(resources.GetObject("b_print.Image")));
            this.b_print.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_print.Location = new System.Drawing.Point(101, 6);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(40, 40);
            this.b_print.TabIndex = 81;
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.Click += new System.EventHandler(this.b_print_Click);
            // 
            // b_last
            // 
            this.b_last.Image = ((System.Drawing.Image)(resources.GetObject("b_last.Image")));
            this.b_last.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_last.Location = new System.Drawing.Point(343, 6);
            this.b_last.Name = "b_last";
            this.b_last.Size = new System.Drawing.Size(40, 40);
            this.b_last.TabIndex = 80;
            this.b_last.UseVisualStyleBackColor = true;
            this.b_last.Click += new System.EventHandler(this.b_last_Click);
            // 
            // b_next
            // 
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_next.Location = new System.Drawing.Point(297, 6);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(40, 40);
            this.b_next.TabIndex = 79;
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_previous
            // 
            this.b_previous.Image = ((System.Drawing.Image)(resources.GetObject("b_previous.Image")));
            this.b_previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_previous.Location = new System.Drawing.Point(251, 6);
            this.b_previous.Name = "b_previous";
            this.b_previous.Size = new System.Drawing.Size(40, 40);
            this.b_previous.TabIndex = 78;
            this.b_previous.UseVisualStyleBackColor = true;
            this.b_previous.Click += new System.EventHandler(this.b_previous_Click);
            // 
            // b_first
            // 
            this.b_first.Image = ((System.Drawing.Image)(resources.GetObject("b_first.Image")));
            this.b_first.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_first.Location = new System.Drawing.Point(205, 6);
            this.b_first.Name = "b_first";
            this.b_first.Size = new System.Drawing.Size(40, 40);
            this.b_first.TabIndex = 76;
            this.b_first.UseVisualStyleBackColor = true;
            this.b_first.Click += new System.EventHandler(this.b_first_Click);
            // 
            // b_gl
            // 
            this.b_gl.Image = ((System.Drawing.Image)(resources.GetObject("b_gl.Image")));
            this.b_gl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_gl.Location = new System.Drawing.Point(9, 7);
            this.b_gl.Name = "b_gl";
            this.b_gl.Size = new System.Drawing.Size(40, 40);
            this.b_gl.TabIndex = 75;
            this.b_gl.UseVisualStyleBackColor = true;
            this.b_gl.Click += new System.EventHandler(this.M_gl_Click);
            // 
            // b_refresh
            // 
            this.b_refresh.Image = ((System.Drawing.Image)(resources.GetObject("b_refresh.Image")));
            this.b_refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_refresh.Location = new System.Drawing.Point(55, 6);
            this.b_refresh.Name = "b_refresh";
            this.b_refresh.Size = new System.Drawing.Size(40, 40);
            this.b_refresh.TabIndex = 74;
            this.b_refresh.UseVisualStyleBackColor = true;
            this.b_refresh.Click += new System.EventHandler(this.M_refresh_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.b_exit);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(954, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(52, 48);
            this.panel11.TabIndex = 12;
            // 
            // b_exit
            // 
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_exit.Location = new System.Drawing.Point(0, 5);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(40, 40);
            this.b_exit.TabIndex = 77;
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Visible = false;
            // 
            // Frm_BB_hyk_xfmxfx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_BB_hyk_xfmxfx";
            this.Text = "会员卡销售统计分析";
            this.Load += new System.EventHandler(this.Frm_BB_xydw_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.p_gl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem M_gl;
        private System.Windows.Forms.ToolStripMenuItem M_refresh;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel p_gl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_xsy;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtp_jssj;
        public System.Windows.Forms.DateTimePicker dtp_cssj;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox tb_hykh;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_outport;
        private System.Windows.Forms.Button b_print;
        private System.Windows.Forms.Button b_last;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_previous;
        private System.Windows.Forms.Button b_first;
        private System.Windows.Forms.Button b_gl;
        private System.Windows.Forms.Button b_refresh;
        private System.Windows.Forms.Button b_exit;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;

    }
}