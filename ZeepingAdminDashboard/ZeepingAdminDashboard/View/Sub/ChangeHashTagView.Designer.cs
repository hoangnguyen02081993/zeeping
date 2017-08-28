namespace ZeepingAdminDashboard.View.Sub
{
    partial class ChangeHashTagView
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
            this.tb_hashtag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_hashtag
            // 
            this.tb_hashtag.Location = new System.Drawing.Point(12, 28);
            this.tb_hashtag.Name = "tb_hashtag";
            this.tb_hashtag.Size = new System.Drawing.Size(376, 20);
            this.tb_hashtag.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "HashTag:";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(269, 54);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(119, 30);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ChangeHashTagView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 96);
            this.Controls.Add(this.tb_hashtag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OK);
            this.Name = "ChangeHashTagView";
            this.Text = "ChangeHashTagView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_hashtag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK;
    }
}