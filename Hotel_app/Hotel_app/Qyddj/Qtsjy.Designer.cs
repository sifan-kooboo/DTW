namespace Hotel_app.Qyddj
{
    partial class Qtsjy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Qtsjy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.r = new System.Windows.Forms.Panel();
            this.b_his = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dg_tsjy = new Hotel_app.DataGridViewSummary();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bs_tsjy = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.tB_tsnr = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.r.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tsjy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_tsjy)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.r);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 493);
            this.panel1.TabIndex = 0;
            // 
            // r
            // 
            this.r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.r.Controls.Add(this.b_his);
            this.r.Controls.Add(this.b_save);
            this.r.Controls.Add(this.b_exit);
            this.r.Controls.Add(this.b_new);
            this.r.Location = new System.Drawing.Point(508, 12);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(87, 469);
            this.r.TabIndex = 10;
            // 
            // b_his
            // 
            this.b_his.BackColor = System.Drawing.SystemColors.Window;
            this.b_his.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_his.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_his.ForeColor = System.Drawing.SystemColors.WindowText;
            this.b_his.Image = ((System.Drawing.Image)(resources.GetObject("b_his.Image")));
            this.b_his.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_his.Location = new System.Drawing.Point(12, 312);
            this.b_his.Margin = new System.Windows.Forms.Padding(1);
            this.b_his.Name = "b_his";
            this.b_his.Padding = new System.Windows.Forms.Padding(1);
            this.b_his.Size = new System.Drawing.Size(59, 56);
            this.b_his.TabIndex = 6;
            this.b_his.Text = "历史";
            this.b_his.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_his.UseVisualStyleBackColor = false;
            this.b_his.Click += new System.EventHandler(this.b_his_Click);
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.SystemColors.Window;
            this.b_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_save.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_save.ForeColor = System.Drawing.SystemColors.WindowText;
            this.b_save.Image = ((System.Drawing.Image)(resources.GetObject("b_save.Image")));
            this.b_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_save.Location = new System.Drawing.Point(12, 240);
            this.b_save.Margin = new System.Windows.Forms.Padding(1);
            this.b_save.Name = "b_save";
            this.b_save.Padding = new System.Windows.Forms.Padding(1);
            this.b_save.Size = new System.Drawing.Size(59, 56);
            this.b_save.TabIndex = 5;
            this.b_save.Text = "保存";
            this.b_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_exit
            // 
            this.b_exit.BackColor = System.Drawing.SystemColors.Window;
            this.b_exit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_exit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.b_exit.Image = ((System.Drawing.Image)(resources.GetObject("b_exit.Image")));
            this.b_exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_exit.Location = new System.Drawing.Point(12, 384);
            this.b_exit.Margin = new System.Windows.Forms.Padding(1);
            this.b_exit.Name = "b_exit";
            this.b_exit.Padding = new System.Windows.Forms.Padding(1);
            this.b_exit.Size = new System.Drawing.Size(59, 55);
            this.b_exit.TabIndex = 4;
            this.b_exit.Text = "退出";
            this.b_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_exit.UseVisualStyleBackColor = false;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_new
            // 
            this.b_new.BackColor = System.Drawing.SystemColors.Window;
            this.b_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_new.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_new.ForeColor = System.Drawing.SystemColors.WindowText;
            this.b_new.Image = ((System.Drawing.Image)(resources.GetObject("b_new.Image")));
            this.b_new.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.b_new.Location = new System.Drawing.Point(12, 168);
            this.b_new.Margin = new System.Windows.Forms.Padding(1);
            this.b_new.Name = "b_new";
            this.b_new.Padding = new System.Windows.Forms.Padding(1);
            this.b_new.Size = new System.Drawing.Size(59, 58);
            this.b_new.TabIndex = 3;
            this.b_new.Text = "新增";
            this.b_new.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.b_new.UseVisualStyleBackColor = false;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dg_tsjy);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 469);
            this.panel2.TabIndex = 0;
            // 
            // dg_tsjy
            // 
            this.dg_tsjy.AllowUserToAddRows = false;
            this.dg_tsjy.AutoGenerateColumns = false;
            this.dg_tsjy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_tsjy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_tsjy.ColumnHeadersHeight = 30;
            this.dg_tsjy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_tsjy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            this.dg_tsjy.DataSource = this.bs_tsjy;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_tsjy.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_tsjy.DisplaySumRowHeader = true;
            this.dg_tsjy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_tsjy.EnableHeadersVisualStyles = false;
            this.dg_tsjy.Location = new System.Drawing.Point(0, 0);
            this.dg_tsjy.Name = "dg_tsjy";
            this.dg_tsjy.RowTemplate.Height = 26;
            this.dg_tsjy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_tsjy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_tsjy.ShowRowNumber = true;
            this.dg_tsjy.Size = new System.Drawing.Size(480, 412);
            this.dg_tsjy.SummaryColumns = new string[] {
        "senior_dep"};
            this.dg_tsjy.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_tsjy.SummaryRowSpace = 0;
            this.dg_tsjy.SummaryRowVisible = true;
            this.dg_tsjy.SumRowHeaderText = null;
            this.dg_tsjy.SumRowHeaderTextBold = false;
            this.dg_tsjy.TabIndex = 6;
            this.dg_tsjy.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_tsjy_ColumnHeaderMouseClick);
            this.dg_tsjy.Click += new System.EventHandler(this.dg_tsjy_Click);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "qymc";
            this.Column3.HeaderText = "地点";
            this.Column3.Name = "Column3";
            this.Column3.Width = 110;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tsnr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "投诉内容";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tssj";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tB_tsnr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 412);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 55);
            this.panel3.TabIndex = 0;
            // 
            // tB_tsnr
            // 
            this.tB_tsnr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB_tsnr.Location = new System.Drawing.Point(0, 0);
            this.tB_tsnr.Multiline = true;
            this.tB_tsnr.Name = "tB_tsnr";
            this.tB_tsnr.Size = new System.Drawing.Size(478, 53);
            this.tB_tsnr.TabIndex = 0;
            // 
            // Qtsjy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 493);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Qtsjy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "投诉建议";
            this.Load += new System.EventHandler(this.Qtsjy_Load);
            this.panel1.ResumeLayout(false);
            this.r.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tsjy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_tsjy)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel r;
        private System.Windows.Forms.Button b_his;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tB_tsnr;
        public DataGridViewSummary dg_tsjy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.BindingSource bs_tsjy;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}