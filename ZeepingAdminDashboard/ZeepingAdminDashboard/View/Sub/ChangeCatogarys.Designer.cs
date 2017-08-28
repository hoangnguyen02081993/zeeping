namespace ZeepingAdminDashboard.View.Sub
{
    partial class ChangeCatogarys
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
            this.chlb_catogary = new System.Windows.Forms.CheckedListBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chlb_catogary
            // 
            this.chlb_catogary.FormattingEnabled = true;
            this.chlb_catogary.Location = new System.Drawing.Point(12, 12);
            this.chlb_catogary.Name = "chlb_catogary";
            this.chlb_catogary.Size = new System.Drawing.Size(189, 184);
            this.chlb_catogary.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(126, 212);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ChangeCatogarys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 242);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.chlb_catogary);
            this.MaximumSize = new System.Drawing.Size(234, 281);
            this.MinimumSize = new System.Drawing.Size(234, 281);
            this.Name = "ChangeCatogarys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeCatogarys";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chlb_catogary;
        private System.Windows.Forms.Button btn_ok;
    }
}