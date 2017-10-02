namespace ZeepingAdminDashboard.View.Sub
{
    partial class AdditionalProductView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pc_featuredimage = new System.Windows.Forms.PictureBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.chb_isfeaturedimage = new System.Windows.Forms.CheckBox();
            this.chlb_catogary = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_hashtag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_vision = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_featuredimage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pc_featuredimage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Featured Image";
            // 
            // pc_featuredimage
            // 
            this.pc_featuredimage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pc_featuredimage.Location = new System.Drawing.Point(3, 16);
            this.pc_featuredimage.Name = "pc_featuredimage";
            this.pc_featuredimage.Size = new System.Drawing.Size(337, 270);
            this.pc_featuredimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pc_featuredimage.TabIndex = 0;
            this.pc_featuredimage.TabStop = false;
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(277, 304);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(75, 23);
            this.btn_browser.TabIndex = 1;
            this.btn_browser.Text = "Browser";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(375, 331);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(119, 48);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // chb_isfeaturedimage
            // 
            this.chb_isfeaturedimage.AutoSize = true;
            this.chb_isfeaturedimage.Location = new System.Drawing.Point(375, 28);
            this.chb_isfeaturedimage.Name = "chb_isfeaturedimage";
            this.chb_isfeaturedimage.Size = new System.Drawing.Size(119, 17);
            this.chb_isfeaturedimage.TabIndex = 2;
            this.chb_isfeaturedimage.Text = "Is Featured Product";
            this.chb_isfeaturedimage.UseVisualStyleBackColor = true;
            this.chb_isfeaturedimage.CheckedChanged += new System.EventHandler(this.chb_isfeaturedimage_CheckedChanged);
            // 
            // chlb_catogary
            // 
            this.chlb_catogary.FormattingEnabled = true;
            this.chlb_catogary.Location = new System.Drawing.Point(375, 51);
            this.chlb_catogary.Name = "chlb_catogary";
            this.chlb_catogary.Size = new System.Drawing.Size(120, 214);
            this.chlb_catogary.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "HashTag:";
            // 
            // tb_hashtag
            // 
            this.tb_hashtag.Location = new System.Drawing.Point(14, 359);
            this.tb_hashtag.Name = "tb_hashtag";
            this.tb_hashtag.Size = new System.Drawing.Size(338, 20);
            this.tb_hashtag.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Default vision:";
            // 
            // cb_vision
            // 
            this.cb_vision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_vision.FormattingEnabled = true;
            this.cb_vision.Items.AddRange(new object[] {
            "Front",
            "Behide"});
            this.cb_vision.Location = new System.Drawing.Point(375, 295);
            this.cb_vision.Name = "cb_vision";
            this.cb_vision.Size = new System.Drawing.Size(121, 21);
            this.cb_vision.TabIndex = 7;
            this.cb_vision.SelectedIndexChanged += new System.EventHandler(this.cb_vision_SelectedIndexChanged);
            // 
            // AdditionalProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 390);
            this.Controls.Add(this.cb_vision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_hashtag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chlb_catogary);
            this.Controls.Add(this.chb_isfeaturedimage);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_browser);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(531, 429);
            this.MinimumSize = new System.Drawing.Size(531, 429);
            this.Name = "AdditionalProductView";
            this.Text = "AdditionalProductView";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pc_featuredimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pc_featuredimage;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox chb_isfeaturedimage;
        private System.Windows.Forms.CheckedListBox chlb_catogary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_hashtag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_vision;
    }
}