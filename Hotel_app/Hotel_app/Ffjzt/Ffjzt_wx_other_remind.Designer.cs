namespace Hotel_app.Ffjzt
{
    partial class Ffjzt_wx_other_remind
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_wx_other = new Hotel_app.DataGridViewSummary();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_wx_other)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_wx_other);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 465);
            this.panel1.TabIndex = 9;
            // 
            // dg_wx_other
            // 
            this.dg_wx_other.AllowUserToAddRows = false;
            this.dg_wx_other.AllowUserToDeleteRows = false;
            this.dg_wx_other.AutoGenerateColumns = false;
            this.dg_wx_other.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_wx_other.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_wx_other.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_wx_other.ColumnHeadersHeight = 30;
            this.dg_wx_other.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_wx_other.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.fjbh,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column3,
            this.Column7});
            this.dg_wx_other.DataSource = this.bindingSource1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_wx_other.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_wx_other.DisplaySumRowHeader = true;
            this.dg_wx_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_wx_other.EnableHeadersVisualStyles = false;
            this.dg_wx_other.Location = new System.Drawing.Point(0, 0);
            this.dg_wx_other.Name = "dg_wx_other";
            this.dg_wx_other.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_wx_other.RowTemplate.Height = 26;
            this.dg_wx_other.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_wx_other.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_wx_other.ShowRowNumber = true;
            this.dg_wx_other.Size = new System.Drawing.Size(822, 463);
            this.dg_wx_other.SummaryColumns = new string[] {
        "fjbh"};
            this.dg_wx_other.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_wx_other.SummaryRowSpace = 10;
            this.dg_wx_other.SummaryRowVisible = true;
            this.dg_wx_other.SumRowHeaderText = "合计:";
            this.dg_wx_other.SumRowHeaderTextBold = false;
            this.dg_wx_other.TabIndex = 8;
            this.dg_wx_other.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_wx_other_KeyDown);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "zyzt";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fjrb";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "房型";
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // fjbh
            // 
            this.fjbh.DataPropertyName = "fjbh";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fjbh.DefaultCellStyle = dataGridViewCellStyle3;
            this.fjbh.HeaderText = "房间编号";
            this.fjbh.Name = "fjbh";
            this.fjbh.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ddsj";
            this.Column5.HeaderText = "开始时间";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "lksj";
            this.Column6.HeaderText = "结束时间";
            this.Column6.Name = "Column6";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "bz";
            this.Column4.HeaderText = "备注";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "czsj";
            this.Column3.HeaderText = "操作时间";
            this.Column3.Name = "Column3";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "czy";
            this.Column7.HeaderText = "操作员";
            this.Column7.Name = "Column7";
            // 
            // Ffjzt_wx_other_remind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(846, 489);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ffjzt_wx_other_remind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "维修_其他房占用提醒";
             this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_wx_other_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_wx_other)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_wx_other;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}