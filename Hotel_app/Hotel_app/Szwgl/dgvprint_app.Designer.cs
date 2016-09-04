namespace Hotel_app.Szwgl
{
    partial class dgvprint_app
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
            this.cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cr
            // 
            this.cr.ActiveViewIndex = -1;
            this.cr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cr.Location = new System.Drawing.Point(0, 0);
            this.cr.Name = "cr";
            this.cr.SelectionFormula = "";
            this.cr.Size = new System.Drawing.Size(297, 211);
            this.cr.TabIndex = 0;
            this.cr.ViewTimeSelectionFormula = "";
            // 
            // dgvprint_app
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 211);
            this.Controls.Add(this.cr);
            this.Name = "dgvprint_app";
            this.Text = "dgvprint_app";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cr;

    }
}