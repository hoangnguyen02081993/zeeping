namespace ZeepingAdminDashboard.View
{
    partial class ConfigForm
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
            this.lb_DBServer = new System.Windows.Forms.Label();
            this.tb_DBServer = new System.Windows.Forms.TextBox();
            this.ld_DBPort = new System.Windows.Forms.Label();
            this.lb_DBDatabase = new System.Windows.Forms.Label();
            this.ld_DBPassword = new System.Windows.Forms.Label();
            this.lb_DBUser = new System.Windows.Forms.Label();
            this.tb_DBPort = new System.Windows.Forms.TextBox();
            this.tb_DBDatabase = new System.Windows.Forms.TextBox();
            this.tb_DBUser = new System.Windows.Forms.TextBox();
            this.tb_DBPassword = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_check_DBServer = new System.Windows.Forms.Button();
            this.chb_autoupdate = new System.Windows.Forms.CheckBox();
            this.chb_autorun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lb_DBServer
            // 
            this.lb_DBServer.AutoSize = true;
            this.lb_DBServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DBServer.Location = new System.Drawing.Point(22, 17);
            this.lb_DBServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DBServer.Name = "lb_DBServer";
            this.lb_DBServer.Size = new System.Drawing.Size(85, 18);
            this.lb_DBServer.TabIndex = 1;
            this.lb_DBServer.Text = "DBServer:";
            // 
            // tb_DBServer
            // 
            this.tb_DBServer.Location = new System.Drawing.Point(212, 8);
            this.tb_DBServer.Margin = new System.Windows.Forms.Padding(2);
            this.tb_DBServer.Multiline = true;
            this.tb_DBServer.Name = "tb_DBServer";
            this.tb_DBServer.Size = new System.Drawing.Size(228, 29);
            this.tb_DBServer.TabIndex = 3;
            // 
            // ld_DBPort
            // 
            this.ld_DBPort.AutoSize = true;
            this.ld_DBPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ld_DBPort.Location = new System.Drawing.Point(22, 52);
            this.ld_DBPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ld_DBPort.Name = "ld_DBPort";
            this.ld_DBPort.Size = new System.Drawing.Size(68, 18);
            this.ld_DBPort.TabIndex = 4;
            this.ld_DBPort.Text = "DBPort:";
            // 
            // lb_DBDatabase
            // 
            this.lb_DBDatabase.AutoSize = true;
            this.lb_DBDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DBDatabase.Location = new System.Drawing.Point(22, 92);
            this.lb_DBDatabase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DBDatabase.Name = "lb_DBDatabase";
            this.lb_DBDatabase.Size = new System.Drawing.Size(107, 18);
            this.lb_DBDatabase.TabIndex = 5;
            this.lb_DBDatabase.Text = "DBDatabase:";
            // 
            // ld_DBPassword
            // 
            this.ld_DBPassword.AutoSize = true;
            this.ld_DBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ld_DBPassword.Location = new System.Drawing.Point(22, 181);
            this.ld_DBPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ld_DBPassword.Name = "ld_DBPassword";
            this.ld_DBPassword.Size = new System.Drawing.Size(111, 18);
            this.ld_DBPassword.TabIndex = 6;
            this.ld_DBPassword.Text = "DBPassword:";
            // 
            // lb_DBUser
            // 
            this.lb_DBUser.AutoSize = true;
            this.lb_DBUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DBUser.Location = new System.Drawing.Point(22, 137);
            this.lb_DBUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DBUser.Name = "lb_DBUser";
            this.lb_DBUser.Size = new System.Drawing.Size(72, 18);
            this.lb_DBUser.TabIndex = 8;
            this.lb_DBUser.Text = "DBUser:";
            // 
            // tb_DBPort
            // 
            this.tb_DBPort.Location = new System.Drawing.Point(212, 52);
            this.tb_DBPort.Margin = new System.Windows.Forms.Padding(2);
            this.tb_DBPort.Multiline = true;
            this.tb_DBPort.Name = "tb_DBPort";
            this.tb_DBPort.Size = new System.Drawing.Size(228, 29);
            this.tb_DBPort.TabIndex = 12;
            // 
            // tb_DBDatabase
            // 
            this.tb_DBDatabase.Location = new System.Drawing.Point(212, 92);
            this.tb_DBDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.tb_DBDatabase.Multiline = true;
            this.tb_DBDatabase.Name = "tb_DBDatabase";
            this.tb_DBDatabase.Size = new System.Drawing.Size(228, 29);
            this.tb_DBDatabase.TabIndex = 13;
            // 
            // tb_DBUser
            // 
            this.tb_DBUser.Location = new System.Drawing.Point(212, 137);
            this.tb_DBUser.Margin = new System.Windows.Forms.Padding(2);
            this.tb_DBUser.Multiline = true;
            this.tb_DBUser.Name = "tb_DBUser";
            this.tb_DBUser.Size = new System.Drawing.Size(228, 29);
            this.tb_DBUser.TabIndex = 14;
            // 
            // tb_DBPassword
            // 
            this.tb_DBPassword.Location = new System.Drawing.Point(212, 181);
            this.tb_DBPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tb_DBPassword.Multiline = true;
            this.tb_DBPassword.Name = "tb_DBPassword";
            this.tb_DBPassword.Size = new System.Drawing.Size(228, 29);
            this.tb_DBPassword.TabIndex = 15;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(255, 280);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(185, 37);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_check_DBServer
            // 
            this.btn_check_DBServer.Location = new System.Drawing.Point(460, 8);
            this.btn_check_DBServer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_check_DBServer.Name = "btn_check_DBServer";
            this.btn_check_DBServer.Size = new System.Drawing.Size(101, 28);
            this.btn_check_DBServer.TabIndex = 22;
            this.btn_check_DBServer.Text = "Check DBServer";
            this.btn_check_DBServer.UseVisualStyleBackColor = true;
            this.btn_check_DBServer.Click += new System.EventHandler(this.btn_check_DBServer_Click);
            // 
            // chb_autoupdate
            // 
            this.chb_autoupdate.AutoSize = true;
            this.chb_autoupdate.Location = new System.Drawing.Point(206, 238);
            this.chb_autoupdate.Name = "chb_autoupdate";
            this.chb_autoupdate.Size = new System.Drawing.Size(86, 17);
            this.chb_autoupdate.TabIndex = 23;
            this.chb_autoupdate.Text = "Auto Update";
            this.chb_autoupdate.UseVisualStyleBackColor = true;
            // 
            // chb_autorun
            // 
            this.chb_autorun.AutoSize = true;
            this.chb_autorun.Location = new System.Drawing.Point(298, 238);
            this.chb_autorun.Name = "chb_autorun";
            this.chb_autorun.Size = new System.Drawing.Size(142, 17);
            this.chb_autorun.TabIndex = 24;
            this.chb_autorun.Text = "Auto Run when updated";
            this.chb_autorun.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 328);
            this.Controls.Add(this.chb_autorun);
            this.Controls.Add(this.chb_autoupdate);
            this.Controls.Add(this.btn_check_DBServer);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_DBPassword);
            this.Controls.Add(this.tb_DBUser);
            this.Controls.Add(this.tb_DBDatabase);
            this.Controls.Add(this.tb_DBPort);
            this.Controls.Add(this.lb_DBUser);
            this.Controls.Add(this.ld_DBPassword);
            this.Controls.Add(this.lb_DBDatabase);
            this.Controls.Add(this.ld_DBPort);
            this.Controls.Add(this.tb_DBServer);
            this.Controls.Add(this.lb_DBServer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(593, 367);
            this.MinimumSize = new System.Drawing.Size(593, 367);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_DBServer;
        private System.Windows.Forms.TextBox tb_DBServer;
        private System.Windows.Forms.Label ld_DBPort;
        private System.Windows.Forms.Label lb_DBDatabase;
        private System.Windows.Forms.Label ld_DBPassword;
        private System.Windows.Forms.Label lb_DBUser;
        private System.Windows.Forms.TextBox tb_DBPort;
        private System.Windows.Forms.TextBox tb_DBDatabase;
        private System.Windows.Forms.TextBox tb_DBUser;
        private System.Windows.Forms.TextBox tb_DBPassword;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_check_DBServer;
        private System.Windows.Forms.CheckBox chb_autoupdate;
        private System.Windows.Forms.CheckBox chb_autorun;
    }
}