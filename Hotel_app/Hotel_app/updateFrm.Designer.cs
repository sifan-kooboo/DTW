namespace Hotel_app
{
    partial class updateFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.downLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "更新文件下载成功，主程序关闭后将自动完成更新操作";
            // 
            // downLoad
            // 
            this.downLoad.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downLoad.Location = new System.Drawing.Point(75, 50);
            this.downLoad.Name = "downLoad";
            this.downLoad.Size = new System.Drawing.Size(164, 23);
            this.downLoad.TabIndex = 4;
            this.downLoad.Text = "开始下载";
            this.downLoad.UseVisualStyleBackColor = true;
            this.downLoad.Click += new System.EventHandler(this.downLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "有新版本，是否下载新版本？";
            // 
            // updateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downLoad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "updateFrm";
            this.Text = "自动升级程序";
            this.Load += new System.EventHandler(this.updateFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.updateFrm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button downLoad;
        private System.Windows.Forms.Label label1;
    }
}