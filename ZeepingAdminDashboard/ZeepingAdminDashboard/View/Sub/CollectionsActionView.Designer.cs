namespace ZeepingAdminDashboard.View.Sub
{
    partial class CollectionsActionView
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
            this.btn_action = new System.Windows.Forms.Button();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.rtb_title = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_apply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.imageAttachPanel1 = new ZeepingAdminDashboard.View.Sub.ImageAttachPanel();
            this.SuspendLayout();
            // 
            // btn_action
            // 
            this.btn_action.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_action.Location = new System.Drawing.Point(528, 603);
            this.btn_action.Name = "btn_action";
            this.btn_action.Size = new System.Drawing.Size(90, 37);
            this.btn_action.TabIndex = 7;
            this.btn_action.Text = "Save";
            this.btn_action.UseVisualStyleBackColor = true;
            this.btn_action.Click += new System.EventHandler(this.btn_action_Click);
            // 
            // rtb_content
            // 
            this.rtb_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_content.Location = new System.Drawing.Point(13, 184);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(607, 277);
            this.rtb_content.TabIndex = 5;
            this.rtb_content.Text = "";
            // 
            // rtb_title
            // 
            this.rtb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_title.Location = new System.Drawing.Point(13, 53);
            this.rtb_title.Name = "rtb_title";
            this.rtb_title.Size = new System.Drawing.Size(607, 96);
            this.rtb_title.TabIndex = 6;
            this.rtb_title.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Content";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // btn_apply
            // 
            this.btn_apply.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_apply.Location = new System.Drawing.Point(358, 603);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(164, 37);
            this.btn_apply.TabIndex = 7;
            this.btn_apply.Text = "Apply and Preview";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name: ";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(62, 9);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(556, 20);
            this.tb_name.TabIndex = 8;
            // 
            // imageAttachPanel1
            // 
            this.imageAttachPanel1.BackColor = System.Drawing.Color.DarkRed;
            this.imageAttachPanel1.Location = new System.Drawing.Point(15, 469);
            this.imageAttachPanel1.Name = "imageAttachPanel1";
            this.imageAttachPanel1.Size = new System.Drawing.Size(603, 128);
            this.imageAttachPanel1.TabIndex = 9;
            // 
            // CollectionsActionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 646);
            this.Controls.Add(this.imageAttachPanel1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_action);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.rtb_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollectionsActionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CollectionsActionView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_action;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.RichTextBox rtb_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private ImageAttachPanel imageAttachPanel1;
    }
}