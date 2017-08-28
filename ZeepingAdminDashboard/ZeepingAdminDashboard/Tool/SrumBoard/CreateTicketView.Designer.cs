namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    partial class CreateTicketView
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
            this.tb_creater = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_priority = new System.Windows.Forms.ComboBox();
            this.cb_related = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtb_description = new System.Windows.Forms.RichTextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creater:";
            // 
            // tb_creater
            // 
            this.tb_creater.Location = new System.Drawing.Point(85, 11);
            this.tb_creater.Name = "tb_creater";
            this.tb_creater.ReadOnly = true;
            this.tb_creater.Size = new System.Drawing.Size(299, 20);
            this.tb_creater.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TicketName:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(85, 39);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(299, 20);
            this.tb_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Priority:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Related:";
            // 
            // cb_priority
            // 
            this.cb_priority.DisplayMember = "name";
            this.cb_priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_priority.FormattingEnabled = true;
            this.cb_priority.Location = new System.Drawing.Point(85, 67);
            this.cb_priority.Name = "cb_priority";
            this.cb_priority.Size = new System.Drawing.Size(299, 21);
            this.cb_priority.TabIndex = 2;
            // 
            // cb_related
            // 
            this.cb_related.DisplayMember = "name";
            this.cb_related.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_related.FormattingEnabled = true;
            this.cb_related.Location = new System.Drawing.Point(85, 93);
            this.cb_related.Name = "cb_related";
            this.cb_related.Size = new System.Drawing.Size(299, 21);
            this.cb_related.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Description:";
            // 
            // rtb_description
            // 
            this.rtb_description.Location = new System.Drawing.Point(10, 155);
            this.rtb_description.Name = "rtb_description";
            this.rtb_description.Size = new System.Drawing.Size(374, 237);
            this.rtb_description.TabIndex = 3;
            this.rtb_description.Text = "";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(289, 409);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(95, 23);
            this.btn_create.TabIndex = 4;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // CreateTicketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 449);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.rtb_description);
            this.Controls.Add(this.cb_related);
            this.Controls.Add(this.cb_priority);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_creater);
            this.Controls.Add(this.label1);
            this.Name = "CreateTicketView";
            this.Text = "CreateTicketView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_creater;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_priority;
        private System.Windows.Forms.ComboBox cb_related;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtb_description;
        private System.Windows.Forms.Button btn_create;
    }
}