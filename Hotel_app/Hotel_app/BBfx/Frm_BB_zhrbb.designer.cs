namespace Hotel_app.BBfx
{
    partial class Frm_BB_zhrbb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BB_zhrbb));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.M_gl = new System.Windows.Forms.ToolStripMenuItem();
            this.M_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.b_print = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_last = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_previous = new System.Windows.Forms.Button();
            this.b_first = new System.Windows.Forms.Button();
            this.b_gl = new System.Windows.Forms.Button();
            this.b_refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.p_gl = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_all = new System.Windows.Forms.Button();
            this.b_wj = new System.Windows.Forms.Button();
            this.b_sr = new System.Windows.Forms.Button();
            this.b_zw = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dT_rq_cx = new System.Windows.Forms.DateTimePicker();
            this.b_search = new System.Windows.Forms.Button();
            this.b_gl_exit = new System.Windows.Forms.Button();
            this.l_czy = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.p_gl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.M_refresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
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
            // b_print
            // 
            this.b_print.Image = ((System.Drawing.Image)(resources.GetObject("b_print.Image")));
            this.b_print.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_print.Location = new System.Drawing.Point(104, 1);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(40, 40);
            this.b_print.TabIndex = 62;
            this.toolTip1.SetToolTip(this.b_print, "打印");
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.Click += new System.EventHandler(this.b_print_Click);
            // 
            // b_exit
            // 
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_exit.Location = new System.Drawing.Point(3, 2);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(40, 40);
            this.b_exit.TabIndex = 6;
            this.toolTip1.SetToolTip(this.b_exit, "退出");
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Visible = false;
            this.b_exit.Click += new System.EventHandler(this.b_Exit_Click);
            // 
            // b_last
            // 
            this.b_last.Image = ((System.Drawing.Image)(resources.GetObject("b_last.Image")));
            this.b_last.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_last.Location = new System.Drawing.Point(355, 2);
            this.b_last.Name = "b_last";
            this.b_last.Size = new System.Drawing.Size(40, 40);
            this.b_last.TabIndex = 9;
            this.toolTip1.SetToolTip(this.b_last, "末页");
            this.b_last.UseVisualStyleBackColor = true;
            this.b_last.Click += new System.EventHandler(this.b_last_Click);
            // 
            // b_next
            // 
            this.b_next.Image = ((System.Drawing.Image)(resources.GetObject("b_next.Image")));
            this.b_next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_next.Location = new System.Drawing.Point(309, 2);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(40, 40);
            this.b_next.TabIndex = 8;
            this.toolTip1.SetToolTip(this.b_next, "下一页");
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // b_previous
            // 
            this.b_previous.Image = ((System.Drawing.Image)(resources.GetObject("b_previous.Image")));
            this.b_previous.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_previous.Location = new System.Drawing.Point(263, 2);
            this.b_previous.Name = "b_previous";
            this.b_previous.Size = new System.Drawing.Size(40, 40);
            this.b_previous.TabIndex = 7;
            this.toolTip1.SetToolTip(this.b_previous, "上一页");
            this.b_previous.UseVisualStyleBackColor = true;
            this.b_previous.Click += new System.EventHandler(this.b_previous_Click);
            // 
            // b_first
            // 
            this.b_first.Image = ((System.Drawing.Image)(resources.GetObject("b_first.Image")));
            this.b_first.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_first.Location = new System.Drawing.Point(217, 2);
            this.b_first.Name = "b_first";
            this.b_first.Size = new System.Drawing.Size(40, 40);
            this.b_first.TabIndex = 5;
            this.toolTip1.SetToolTip(this.b_first, "首页");
            this.b_first.UseVisualStyleBackColor = true;
            this.b_first.Click += new System.EventHandler(this.b_first_Click);
            // 
            // b_gl
            // 
            this.b_gl.Image = ((System.Drawing.Image)(resources.GetObject("b_gl.Image")));
            this.b_gl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_gl.Location = new System.Drawing.Point(11, 2);
            this.b_gl.Name = "b_gl";
            this.b_gl.Size = new System.Drawing.Size(40, 40);
            this.b_gl.TabIndex = 4;
            this.toolTip1.SetToolTip(this.b_gl, "过滤");
            this.b_gl.UseVisualStyleBackColor = true;
            this.b_gl.Click += new System.EventHandler(this.M_gl_Click);
            // 
            // b_refresh
            // 
            this.b_refresh.Image = ((System.Drawing.Image)(resources.GetObject("b_refresh.Image")));
            this.b_refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_refresh.Location = new System.Drawing.Point(57, 1);
            this.b_refresh.Name = "b_refresh";
            this.b_refresh.Size = new System.Drawing.Size(40, 40);
            this.b_refresh.TabIndex = 3;
            this.toolTip1.SetToolTip(this.b_refresh, "刷新");
            this.b_refresh.UseVisualStyleBackColor = true;
            this.b_refresh.Click += new System.EventHandler(this.Frm_BB_zhrbb_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 750);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.p_gl);
            this.panel4.Controls.Add(this.crystalReportViewer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 694);
            this.panel4.TabIndex = 2;
            // 
            // p_gl
            // 
            this.p_gl.BackColor = System.Drawing.SystemColors.Control;
            this.p_gl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_gl.Controls.Add(this.groupBox2);
            this.p_gl.Controls.Add(this.groupBox1);
            this.p_gl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Underline);
            this.p_gl.Location = new System.Drawing.Point(3, 6);
            this.p_gl.Name = "p_gl";
            this.p_gl.Size = new System.Drawing.Size(485, 203);
            this.p_gl.TabIndex = 31;
            this.p_gl.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_all);
            this.groupBox2.Controls.Add(this.b_wj);
            this.groupBox2.Controls.Add(this.b_sr);
            this.groupBox2.Controls.Add(this.b_zw);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(244, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 187);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "重做报表";
            // 
            // b_all
            // 
            this.b_all.BackColor = System.Drawing.SystemColors.Control;
            this.b_all.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_all.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_all.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_all.Image = ((System.Drawing.Image)(resources.GetObject("b_all.Image")));
            this.b_all.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_all.Location = new System.Drawing.Point(138, 114);
            this.b_all.Margin = new System.Windows.Forms.Padding(1);
            this.b_all.Name = "b_all";
            this.b_all.Padding = new System.Windows.Forms.Padding(1);
            this.b_all.Size = new System.Drawing.Size(75, 42);
            this.b_all.TabIndex = 101;
            this.b_all.Text = "整体";
            this.b_all.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_all.UseVisualStyleBackColor = false;
            this.b_all.Click += new System.EventHandler(this.button4_Click);
            // 
            // b_wj
            // 
            this.b_wj.BackColor = System.Drawing.SystemColors.Control;
            this.b_wj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_wj.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_wj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_wj.Image = ((System.Drawing.Image)(resources.GetObject("b_wj.Image")));
            this.b_wj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_wj.Location = new System.Drawing.Point(27, 114);
            this.b_wj.Margin = new System.Windows.Forms.Padding(1);
            this.b_wj.Name = "b_wj";
            this.b_wj.Padding = new System.Windows.Forms.Padding(1);
            this.b_wj.Size = new System.Drawing.Size(75, 42);
            this.b_wj.TabIndex = 100;
            this.b_wj.Text = "未结";
            this.b_wj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_wj.UseVisualStyleBackColor = false;
            this.b_wj.Click += new System.EventHandler(this.button3_Click);
            // 
            // b_sr
            // 
            this.b_sr.BackColor = System.Drawing.SystemColors.Control;
            this.b_sr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_sr.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_sr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_sr.Image = ((System.Drawing.Image)(resources.GetObject("b_sr.Image")));
            this.b_sr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_sr.Location = new System.Drawing.Point(27, 46);
            this.b_sr.Margin = new System.Windows.Forms.Padding(1);
            this.b_sr.Name = "b_sr";
            this.b_sr.Padding = new System.Windows.Forms.Padding(1);
            this.b_sr.Size = new System.Drawing.Size(75, 42);
            this.b_sr.TabIndex = 98;
            this.b_sr.Text = "收入";
            this.b_sr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_sr.UseVisualStyleBackColor = false;
            this.b_sr.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_zw
            // 
            this.b_zw.BackColor = System.Drawing.SystemColors.Control;
            this.b_zw.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_zw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_zw.Image = ((System.Drawing.Image)(resources.GetObject("b_zw.Image")));
            this.b_zw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_zw.Location = new System.Drawing.Point(138, 46);
            this.b_zw.Margin = new System.Windows.Forms.Padding(1);
            this.b_zw.Name = "b_zw";
            this.b_zw.Padding = new System.Windows.Forms.Padding(1);
            this.b_zw.Size = new System.Drawing.Size(75, 42);
            this.b_zw.TabIndex = 99;
            this.b_zw.Text = "账务";
            this.b_zw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_zw.UseVisualStyleBackColor = false;
            this.b_zw.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dT_rq_cx);
            this.groupBox1.Controls.Add(this.b_search);
            this.groupBox1.Controls.Add(this.b_gl_exit);
            this.groupBox1.Controls.Add(this.l_czy);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 187);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤";
            // 
            // dT_rq_cx
            // 
            this.dT_rq_cx.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_rq_cx.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dT_rq_cx.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dT_rq_cx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dT_rq_cx.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT_rq_cx.Location = new System.Drawing.Point(43, 51);
            this.dT_rq_cx.Name = "dT_rq_cx";
            this.dT_rq_cx.Size = new System.Drawing.Size(161, 29);
            this.dT_rq_cx.TabIndex = 107;
            // 
            // b_search
            // 
            this.b_search.BackColor = System.Drawing.SystemColors.Control;
            this.b_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_search.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_search.Image = ((System.Drawing.Image)(resources.GetObject("b_search.Image")));
            this.b_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_search.Location = new System.Drawing.Point(38, 114);
            this.b_search.Margin = new System.Windows.Forms.Padding(1);
            this.b_search.Name = "b_search";
            this.b_search.Padding = new System.Windows.Forms.Padding(1);
            this.b_search.Size = new System.Drawing.Size(69, 42);
            this.b_search.TabIndex = 98;
            this.b_search.Text = "查询";
            this.b_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_search.UseVisualStyleBackColor = false;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // b_gl_exit
            // 
            this.b_gl_exit.BackColor = System.Drawing.SystemColors.Control;
            this.b_gl_exit.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_gl_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_gl_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_gl_exit.Image")));
            this.b_gl_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_gl_exit.Location = new System.Drawing.Point(130, 114);
            this.b_gl_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_gl_exit.Name = "b_gl_exit";
            this.b_gl_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_gl_exit.Size = new System.Drawing.Size(69, 42);
            this.b_gl_exit.TabIndex = 99;
            this.b_gl_exit.Text = "退出";
            this.b_gl_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_gl_exit.UseVisualStyleBackColor = false;
            this.b_gl_exit.Click += new System.EventHandler(this.b_exit_Click_1);
            // 
            // l_czy
            // 
            this.l_czy.AutoSize = true;
            this.l_czy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_czy.Location = new System.Drawing.Point(6, 57);
            this.l_czy.Name = "l_czy";
            this.l_czy.Size = new System.Drawing.Size(32, 17);
            this.l_czy.TabIndex = 106;
            this.l_czy.Text = "日期";
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
            this.crystalReportViewer1.Font = new System.Drawing.Font("宋体", 12F);
            this.crystalReportViewer1.ForeColor = System.Drawing.Color.White;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowExportButton = false;
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowPageNavigateButtons = false;
            this.crystalReportViewer1.ShowPrintButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.ShowZoomButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1008, 694);
            this.crystalReportViewer1.TabIndex = 30;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 740);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 10);
            this.panel3.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 46);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.b_print);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.b_last);
            this.panel6.Controls.Add(this.b_next);
            this.panel6.Controls.Add(this.b_previous);
            this.panel6.Controls.Add(this.b_first);
            this.panel6.Controls.Add(this.b_gl);
            this.panel6.Controls.Add(this.b_refresh);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 46);
            this.panel6.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(150, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 76;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.b_outport_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.b_exit);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(954, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(52, 44);
            this.panel11.TabIndex = 12;
            // 
            // Frm_BB_zhrbb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 750);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_BB_zhrbb";
            this.Text = "综合日报表";
            this.Load += new System.EventHandler(this.Frm_BB_zhrbb_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.p_gl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel p_gl;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label l_czy;
        public System.Windows.Forms.Button b_gl_exit;
        public System.Windows.Forms.Button b_search;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button b_print;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_last;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_previous;
        private System.Windows.Forms.Button b_first;
        private System.Windows.Forms.Button b_gl;
        private System.Windows.Forms.Button b_refresh;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button b_all;
        public System.Windows.Forms.Button b_wj;
        public System.Windows.Forms.Button b_sr;
        public System.Windows.Forms.Button b_zw;
        private System.Windows.Forms.DateTimePicker dT_rq_cx;
        private System.Windows.Forms.Button button1;
    }
}