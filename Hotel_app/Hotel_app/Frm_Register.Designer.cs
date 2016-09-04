namespace Hotel_app
{
    partial class Frm_Register
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
            this.b_RegisterKey = new System.Windows.Forms.Button();
            this.Txt_McKey = new System.Windows.Forms.TextBox();
            this.lbl_McKey = new System.Windows.Forms.Label();
            this.lbl_CupID = new System.Windows.Forms.Label();
            this.lbl_DiskID = new System.Windows.Forms.Label();
            this.Txt_DiskID = new System.Windows.Forms.TextBox();
            this.Txt_CpuID = new System.Windows.Forms.TextBox();
            this.b_next = new System.Windows.Forms.Button();
            this.lbl_registerKey = new System.Windows.Forms.Label();
            this.Txt_RegisterKey = new System.Windows.Forms.TextBox();
            this.b_getRegisterKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_RegisterKey
            // 
            this.b_RegisterKey.Location = new System.Drawing.Point(122, 66);
            this.b_RegisterKey.Name = "b_RegisterKey";
            this.b_RegisterKey.Size = new System.Drawing.Size(81, 23);
            this.b_RegisterKey.TabIndex = 15;
            this.b_RegisterKey.Text = "注册";
            this.b_RegisterKey.UseVisualStyleBackColor = true;
            this.b_RegisterKey.Click += new System.EventHandler(this.b_getRegisterKey_Click);
            // 
            // Txt_McKey
            // 
            this.Txt_McKey.Location = new System.Drawing.Point(95, 12);
            this.Txt_McKey.Name = "Txt_McKey";
            this.Txt_McKey.ReadOnly = true;
            this.Txt_McKey.Size = new System.Drawing.Size(219, 21);
            this.Txt_McKey.TabIndex = 14;
            // 
            // lbl_McKey
            // 
            this.lbl_McKey.AutoSize = true;
            this.lbl_McKey.Location = new System.Drawing.Point(15, 18);
            this.lbl_McKey.Name = "lbl_McKey";
            this.lbl_McKey.Size = new System.Drawing.Size(53, 12);
            this.lbl_McKey.TabIndex = 13;
            this.lbl_McKey.Text = "序列码：";
            // 
            // lbl_CupID
            // 
            this.lbl_CupID.AutoSize = true;
            this.lbl_CupID.Location = new System.Drawing.Point(15, 9);
            this.lbl_CupID.Name = "lbl_CupID";
            this.lbl_CupID.Size = new System.Drawing.Size(59, 12);
            this.lbl_CupID.TabIndex = 12;
            this.lbl_CupID.Text = "CPU列号：";
            this.lbl_CupID.Visible = false;
            // 
            // lbl_DiskID
            // 
            this.lbl_DiskID.AutoSize = true;
            this.lbl_DiskID.Location = new System.Drawing.Point(15, 6);
            this.lbl_DiskID.Name = "lbl_DiskID";
            this.lbl_DiskID.Size = new System.Drawing.Size(77, 12);
            this.lbl_DiskID.TabIndex = 11;
            this.lbl_DiskID.Text = "硬盘序列号：";
            this.lbl_DiskID.Visible = false;
            // 
            // Txt_DiskID
            // 
            this.Txt_DiskID.Location = new System.Drawing.Point(95, 3);
            this.Txt_DiskID.Name = "Txt_DiskID";
            this.Txt_DiskID.ReadOnly = true;
            this.Txt_DiskID.Size = new System.Drawing.Size(219, 21);
            this.Txt_DiskID.TabIndex = 10;
            this.Txt_DiskID.Visible = false;
            // 
            // Txt_CpuID
            // 
            this.Txt_CpuID.Location = new System.Drawing.Point(95, 6);
            this.Txt_CpuID.Name = "Txt_CpuID";
            this.Txt_CpuID.ReadOnly = true;
            this.Txt_CpuID.Size = new System.Drawing.Size(219, 21);
            this.Txt_CpuID.TabIndex = 9;
            this.Txt_CpuID.Visible = false;
            // 
            // b_next
            // 
            this.b_next.Location = new System.Drawing.Point(233, 66);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(81, 23);
            this.b_next.TabIndex = 16;
            this.b_next.Text = "继续试用";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click);
            // 
            // lbl_registerKey
            // 
            this.lbl_registerKey.AutoSize = true;
            this.lbl_registerKey.Location = new System.Drawing.Point(19, 44);
            this.lbl_registerKey.Name = "lbl_registerKey";
            this.lbl_registerKey.Size = new System.Drawing.Size(53, 12);
            this.lbl_registerKey.TabIndex = 17;
            this.lbl_registerKey.Text = "注册码：";
            // 
            // Txt_RegisterKey
            // 
            this.Txt_RegisterKey.Location = new System.Drawing.Point(95, 39);
            this.Txt_RegisterKey.Name = "Txt_RegisterKey";
            this.Txt_RegisterKey.Size = new System.Drawing.Size(219, 21);
            this.Txt_RegisterKey.TabIndex = 18;
            // 
            // b_getRegisterKey
            // 
            this.b_getRegisterKey.Location = new System.Drawing.Point(21, 66);
            this.b_getRegisterKey.Name = "b_getRegisterKey";
            this.b_getRegisterKey.Size = new System.Drawing.Size(81, 23);
            this.b_getRegisterKey.TabIndex = 19;
            this.b_getRegisterKey.Text = "获取注册码";
            this.b_getRegisterKey.UseVisualStyleBackColor = true;
            this.b_getRegisterKey.Click += new System.EventHandler(this.b_getRegisterKey_Click_1);
            // 
            // Frm_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 96);
            this.Controls.Add(this.b_getRegisterKey);
            this.Controls.Add(this.Txt_RegisterKey);
            this.Controls.Add(this.lbl_registerKey);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.b_RegisterKey);
            this.Controls.Add(this.Txt_McKey);
            this.Controls.Add(this.lbl_McKey);
            this.Controls.Add(this.lbl_CupID);
            this.Controls.Add(this.lbl_DiskID);
            this.Controls.Add(this.Txt_DiskID);
            this.Controls.Add(this.Txt_CpuID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Register";
            this.Text = "注册";
            this.Load += new System.EventHandler(this.Frm_Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_RegisterKey;
        private System.Windows.Forms.TextBox Txt_McKey;
        private System.Windows.Forms.Label lbl_McKey;
        private System.Windows.Forms.Label lbl_CupID;
        private System.Windows.Forms.Label lbl_DiskID;
        private System.Windows.Forms.TextBox Txt_DiskID;
        private System.Windows.Forms.TextBox Txt_CpuID;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Label lbl_registerKey;
        private System.Windows.Forms.TextBox Txt_RegisterKey;
        private System.Windows.Forms.Button b_getRegisterKey;
    }
}