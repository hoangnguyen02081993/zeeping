namespace ReleaseDownloader
{
    partial class Form1
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
            this.chb_autoupdate = new System.Windows.Forms.CheckBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.progress_update = new System.Windows.Forms.ProgressBar();
            this.lb_process = new System.Windows.Forms.Label();
            this.chb_autorun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chb_autoupdate
            // 
            this.chb_autoupdate.AutoSize = true;
            this.chb_autoupdate.Location = new System.Drawing.Point(22, 26);
            this.chb_autoupdate.Name = "chb_autoupdate";
            this.chb_autoupdate.Size = new System.Drawing.Size(95, 17);
            this.chb_autoupdate.TabIndex = 0;
            this.chb_autoupdate.Text = "Auto Update ?";
            this.chb_autoupdate.UseVisualStyleBackColor = true;
            this.chb_autoupdate.CheckedChanged += new System.EventHandler(this.chb_autoupdate_CheckedChanged);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(487, 24);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // progress_update
            // 
            this.progress_update.Location = new System.Drawing.Point(17, 92);
            this.progress_update.Name = "progress_update";
            this.progress_update.Size = new System.Drawing.Size(545, 23);
            this.progress_update.TabIndex = 2;
            // 
            // lb_process
            // 
            this.lb_process.AutoSize = true;
            this.lb_process.Location = new System.Drawing.Point(22, 61);
            this.lb_process.Name = "lb_process";
            this.lb_process.Size = new System.Drawing.Size(0, 13);
            this.lb_process.TabIndex = 3;
            // 
            // chb_autorun
            // 
            this.chb_autorun.AutoSize = true;
            this.chb_autorun.Location = new System.Drawing.Point(139, 26);
            this.chb_autorun.Name = "chb_autorun";
            this.chb_autorun.Size = new System.Drawing.Size(137, 17);
            this.chb_autorun.TabIndex = 4;
            this.chb_autorun.Text = "Auto run when updated";
            this.chb_autorun.UseVisualStyleBackColor = true;
            this.chb_autorun.CheckedChanged += new System.EventHandler(this.chb_autorun_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 127);
            this.Controls.Add(this.chb_autorun);
            this.Controls.Add(this.lb_process);
            this.Controls.Add(this.progress_update);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.chb_autoupdate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb_autoupdate;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ProgressBar progress_update;
        private System.Windows.Forms.Label lb_process;
        private System.Windows.Forms.CheckBox chb_autorun;
    }
}

