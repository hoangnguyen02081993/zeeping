namespace ZeepingAdminDashboard
{
    partial class ReleaseNote
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
            this.rtb_releasenote = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_releasenote
            // 
            this.rtb_releasenote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_releasenote.Location = new System.Drawing.Point(0, 0);
            this.rtb_releasenote.Name = "rtb_releasenote";
            this.rtb_releasenote.ReadOnly = true;
            this.rtb_releasenote.Size = new System.Drawing.Size(752, 376);
            this.rtb_releasenote.TabIndex = 0;
            this.rtb_releasenote.Text = "";
            // 
            // ReleaseNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 376);
            this.Controls.Add(this.rtb_releasenote);
            this.Name = "ReleaseNote";
            this.Text = "ReleaseNote";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_releasenote;
    }
}