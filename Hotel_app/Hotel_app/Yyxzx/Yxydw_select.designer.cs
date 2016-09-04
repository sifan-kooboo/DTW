namespace Hotel_app.Yyxzx
{
    partial class Yxydw_select
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tB_select = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dg_xydw = new Hotel_app.DataGridViewSummary();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_xydw)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_select
            // 
            this.tB_select.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_select.Location = new System.Drawing.Point(13, 431);
            this.tB_select.Name = "tB_select";
            this.tB_select.Size = new System.Drawing.Size(542, 26);
            this.tB_select.TabIndex = 4;
            this.tB_select.TextChanged += new System.EventHandler(this.tB_select_TextChanged);
            this.tB_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_xydw_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dg_xydw);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 414);
            this.panel1.TabIndex = 3;
            // 
            // dg_xydw
            // 
            this.dg_xydw.AllowUserToAddRows = false;
            this.dg_xydw.AutoGenerateColumns = false;
            this.dg_xydw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_xydw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_xydw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_xydw.ColumnHeadersHeight = 30;
            this.dg_xydw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_xydw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4});
            this.dg_xydw.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_xydw.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_xydw.DisplaySumRowHeader = true;
            this.dg_xydw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_xydw.EnableHeadersVisualStyles = false;
            this.dg_xydw.Location = new System.Drawing.Point(0, 0);
            this.dg_xydw.Name = "dg_xydw";
            this.dg_xydw.ReadOnly = true;
            this.dg_xydw.RowTemplate.Height = 26;
            this.dg_xydw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_xydw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_xydw.ShowRowNumber = true;
            this.dg_xydw.Size = new System.Drawing.Size(542, 412);
            this.dg_xydw.SummaryColumns = new string[] {
        "xydw"};
            this.dg_xydw.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dg_xydw.SummaryRowSpace = 0;
            this.dg_xydw.SummaryRowVisible = true;
            this.dg_xydw.SumRowHeaderText = null;
            this.dg_xydw.SumRowHeaderTextBold = false;
            this.dg_xydw.TabIndex = 6;
            this.dg_xydw.DoubleClick += new System.EventHandler(this.dg_xydw_DoubleClick);
            this.dg_xydw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_xydw_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "qymc";
            this.Column1.HeaderText = "签约单位";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "krly";
            this.Column3.HeaderText = "来源";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "xydw";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "协议单位";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "xsy";
            this.Column4.HeaderText = "销售员";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Yxydw_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(568, 468);
            this.Controls.Add(this.tB_select);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Yxydw_select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "协议单位";
             this.Shown += new System.EventHandler(this.Yxydw_select_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_xydw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_select;
        public DataGridViewSummary dg_xydw;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}