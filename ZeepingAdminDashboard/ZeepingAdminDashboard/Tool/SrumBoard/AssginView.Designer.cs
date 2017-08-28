namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    partial class AssginView
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
            this.cb_userlist = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_assign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_userlist
            // 
            this.cb_userlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_userlist.FormattingEnabled = true;
            this.cb_userlist.Location = new System.Drawing.Point(59, 12);
            this.cb_userlist.Name = "cb_userlist";
            this.cb_userlist.Size = new System.Drawing.Size(213, 21);
            this.cb_userlist.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // btn_assign
            // 
            this.btn_assign.Location = new System.Drawing.Point(197, 39);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(75, 23);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assgin";
            this.btn_assign.UseVisualStyleBackColor = true;
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // AssginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 67);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_userlist);
            this.Name = "AssginView";
            this.Text = "AssginView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_userlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_assign;
    }
}