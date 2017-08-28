namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    partial class ScrumBoardView
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
            this.btn_doneticket = new System.Windows.Forms.Button();
            this.btn_createticket = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_logintracking = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_logintracking);
            this.groupBox1.Controls.Add(this.btn_doneticket);
            this.groupBox1.Controls.Add(this.btn_createticket);
            this.groupBox1.Location = new System.Drawing.Point(742, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 485);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btn_doneticket
            // 
            this.btn_doneticket.Location = new System.Drawing.Point(15, 61);
            this.btn_doneticket.Name = "btn_doneticket";
            this.btn_doneticket.Size = new System.Drawing.Size(115, 34);
            this.btn_doneticket.TabIndex = 0;
            this.btn_doneticket.Text = "Done Ticket";
            this.btn_doneticket.UseVisualStyleBackColor = true;
            this.btn_doneticket.Click += new System.EventHandler(this.btn_doneticket_Click);
            // 
            // btn_createticket
            // 
            this.btn_createticket.Location = new System.Drawing.Point(15, 21);
            this.btn_createticket.Name = "btn_createticket";
            this.btn_createticket.Size = new System.Drawing.Size(115, 34);
            this.btn_createticket.TabIndex = 0;
            this.btn_createticket.Text = "Create Ticket";
            this.btn_createticket.UseVisualStyleBackColor = true;
            this.btn_createticket.Click += new System.EventHandler(this.btn_createticket_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 464);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To do";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 471);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(884, 190);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pending/Need Help";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(246, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 464);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In progress";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(495, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(240, 464);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Review";
            // 
            // btn_logintracking
            // 
            this.btn_logintracking.Location = new System.Drawing.Point(15, 430);
            this.btn_logintracking.Name = "btn_logintracking";
            this.btn_logintracking.Size = new System.Drawing.Size(115, 34);
            this.btn_logintracking.TabIndex = 0;
            this.btn_logintracking.Text = "Login View";
            this.btn_logintracking.UseVisualStyleBackColor = true;
            this.btn_logintracking.Visible = false;
            this.btn_logintracking.Click += new System.EventHandler(this.btn_logintracking_Click);
            // 
            // ScrumBoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(900, 700);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "ScrumBoardView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScrumBoardView";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_createticket;
        private System.Windows.Forms.Button btn_doneticket;
        private System.Windows.Forms.Button btn_logintracking;
    }
}