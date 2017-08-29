namespace ZeepingAdminDashboard.View.Sub
{
    partial class ImageAttachPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.pn_image = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.pn_image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_browser);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(14, 33);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(129, 29);
            this.btn_browser.TabIndex = 0;
            this.btn_browser.Text = "Browser";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(14, 72);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(129, 35);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // pn_image
            // 
            this.pn_image.AutoScroll = true;
            this.pn_image.Controls.Add(this.pictureBox1);
            this.pn_image.Location = new System.Drawing.Point(175, 8);
            this.pn_image.Name = "pn_image";
            this.pn_image.Size = new System.Drawing.Size(416, 113);
            this.pn_image.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ImageAttachPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.Controls.Add(this.pn_image);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(603, 128);
            this.MinimumSize = new System.Drawing.Size(603, 128);
            this.Name = "ImageAttachPanel";
            this.Size = new System.Drawing.Size(603, 128);
            this.groupBox1.ResumeLayout(false);
            this.pn_image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.Panel pn_image;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
