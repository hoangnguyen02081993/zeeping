namespace ZeepingAdminDashboard.View.Sub
{
    partial class ChangeDefaultVisionProductView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_vision = new System.Windows.Forms.ComboBox();
            this.btn_change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Vision:";
            // 
            // cb_vision
            // 
            this.cb_vision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_vision.FormattingEnabled = true;
            this.cb_vision.Items.AddRange(new object[] {
            "Front",
            "Behide"});
            this.cb_vision.Location = new System.Drawing.Point(91, 8);
            this.cb_vision.Name = "cb_vision";
            this.cb_vision.Size = new System.Drawing.Size(229, 21);
            this.cb_vision.TabIndex = 1;
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(245, 45);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 2;
            this.btn_change.Text = "Change";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // ChangeDefaultVisionProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 77);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.cb_vision);
            this.Controls.Add(this.label1);
            this.Name = "ChangeDefaultVisionProductView";
            this.Text = "ChangeDefaultVisionProductView";
            this.Load += new System.EventHandler(this.ChangeDefaultVisionProductView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_vision;
        private System.Windows.Forms.Button btn_change;
    }
}