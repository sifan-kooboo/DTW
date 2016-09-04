namespace Hotel_app.Ffjzt
{
    partial class FQ_yddj_select
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
            this.dg_Qskyd = new Hotel_app.DataGridViewSummary();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bs_Qskyd = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Qskyd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Qskyd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_Qskyd);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 204);
            this.panel1.TabIndex = 0;
            // 
            // dg_Qskyd
            // 
            this.dg_Qskyd.AllowUserToAddRows = false;
            this.dg_Qskyd.AutoGenerateColumns = false;
            this.dg_Qskyd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_Qskyd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Qskyd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Qskyd.ColumnHeadersHeight = 35;
            this.dg_Qskyd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Qskyd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dg_Qskyd.DataSource = this.bs_Qskyd;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Qskyd.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_Qskyd.DisplaySumRowHeader = true;
            this.dg_Qskyd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Qskyd.EnableHeadersVisualStyles = false;
            this.dg_Qskyd.Location = new System.Drawing.Point(0, 0);
            this.dg_Qskyd.Name = "dg_Qskyd";
            this.dg_Qskyd.RowHeadersWidth = 60;
            this.dg_Qskyd.RowTemplate.Height = 30;
            this.dg_Qskyd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_Qskyd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Qskyd.ShowRowNumber = true;
            this.dg_Qskyd.Size = new System.Drawing.Size(574, 202);
            this.dg_Qskyd.SummaryColumns = new string[] {
        "senior_dep"};
            this.dg_Qskyd.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_Qskyd.SummaryRowSpace = 0;
            this.dg_Qskyd.SummaryRowVisible = true;
            this.dg_Qskyd.SumRowHeaderText = null;
            this.dg_Qskyd.SumRowHeaderTextBold = false;
            this.dg_Qskyd.TabIndex = 7;
            this.dg_Qskyd.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_Qskyd_ColumnHeaderMouseClick);
            this.dg_Qskyd.DoubleClick += new System.EventHandler(this.dg_Qskyd_DoubleClick);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "fjbh";
            this.Column3.HeaderText = "房号";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "krxm";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "客人";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "yddj";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ddsj";
            this.Column4.HeaderText = "到时";
            this.Column4.Name = "Column4";
            this.Column4.Width = 110;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "lksj";
            this.Column5.HeaderText = "离时";
            this.Column5.Name = "Column5";
            this.Column5.Width = 110;
            // 
            // FQ_yddj_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 233);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FQ_yddj_select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "选择";
            this.Load += new System.EventHandler(this.FQ_yddj_select_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Qskyd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Qskyd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public DataGridViewSummary dg_Qskyd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.BindingSource bs_Qskyd;
    }
}