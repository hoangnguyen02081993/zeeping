namespace ZeepingAdminDashboard.View
{
    partial class ReplySupportForm
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
            this.tb_from = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_to = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ:";
            // 
            // tb_from
            // 
            this.tb_from.Location = new System.Drawing.Point(89, 21);
            this.tb_from.Name = "tb_from";
            this.tb_from.ReadOnly = true;
            this.tb_from.Size = new System.Drawing.Size(378, 20);
            this.tb_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến:";
            // 
            // tb_to
            // 
            this.tb_to.Location = new System.Drawing.Point(89, 47);
            this.tb_to.Name = "tb_to";
            this.tb_to.ReadOnly = true;
            this.tb_to.Size = new System.Drawing.Size(378, 20);
            this.tb_to.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiêu đề:";
            // 
            // tb_subject
            // 
            this.tb_subject.Location = new System.Drawing.Point(89, 73);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(378, 20);
            this.tb_subject.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nội dung:";
            // 
            // rtb_content
            // 
            this.rtb_content.Location = new System.Drawing.Point(20, 135);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(447, 242);
            this.rtb_content.TabIndex = 0;
            this.rtb_content.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(387, 390);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Gửi";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // ReplySupportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 425);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_to);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_from);
            this.Controls.Add(this.label1);
            this.Name = "ReplySupportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReplySupportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_to;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.Button btn_send;
    }
}