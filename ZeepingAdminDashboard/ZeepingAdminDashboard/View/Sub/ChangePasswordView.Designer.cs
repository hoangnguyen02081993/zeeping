namespace ZeepingAdminDashboard.View
{
    partial class ChangePasswordView
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
            this.tb_old = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_new = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_again_new = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Pass:";
            // 
            // tb_old
            // 
            this.tb_old.Location = new System.Drawing.Point(103, 27);
            this.tb_old.Name = "tb_old";
            this.tb_old.Size = new System.Drawing.Size(169, 20);
            this.tb_old.TabIndex = 0;
            this.tb_old.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "New pass:";
            // 
            // tb_new
            // 
            this.tb_new.Location = new System.Drawing.Point(103, 53);
            this.tb_new.Name = "tb_new";
            this.tb_new.Size = new System.Drawing.Size(169, 20);
            this.tb_new.TabIndex = 1;
            this.tb_new.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Again new pass:";
            // 
            // tb_again_new
            // 
            this.tb_again_new.Location = new System.Drawing.Point(103, 79);
            this.tb_again_new.Name = "tb_again_new";
            this.tb_again_new.Size = new System.Drawing.Size(169, 20);
            this.tb_again_new.TabIndex = 2;
            this.tb_again_new.UseSystemPasswordChar = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(197, 111);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ChangePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_again_new);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_new);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_old);
            this.Controls.Add(this.label1);
            this.Name = "ChangePasswordView";
            this.Text = "ChangePasswordView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_old;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_new;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_again_new;
        private System.Windows.Forms.Button btn_ok;
    }
}