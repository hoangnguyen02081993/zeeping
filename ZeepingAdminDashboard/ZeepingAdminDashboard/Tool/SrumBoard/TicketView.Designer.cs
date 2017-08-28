namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    partial class TicketView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_perority = new System.Windows.Forms.Label();
            this.lb_assginer = new System.Windows.Forms.Label();
            this.lb_creater = new System.Windows.Forms.Label();
            this.lb_relatied = new System.Windows.Forms.Label();
            this.rtb_ticketname = new System.Windows.Forms.RichTextBox();
            this.btn_assign = new System.Windows.Forms.Button();
            this.btn_pre = new System.Windows.Forms.Button();
            this.btn_pend = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(14, 15);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(40, 13);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "Ticket:";
            // 
            // lb_perority
            // 
            this.lb_perority.AutoSize = true;
            this.lb_perority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_perority.Location = new System.Drawing.Point(59, 55);
            this.lb_perority.Name = "lb_perority";
            this.lb_perority.Size = new System.Drawing.Size(54, 13);
            this.lb_perority.TabIndex = 0;
            this.lb_perority.Text = "Priority: ";
            // 
            // lb_assginer
            // 
            this.lb_assginer.AutoSize = true;
            this.lb_assginer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_assginer.Location = new System.Drawing.Point(59, 94);
            this.lb_assginer.Name = "lb_assginer";
            this.lb_assginer.Size = new System.Drawing.Size(63, 13);
            this.lb_assginer.TabIndex = 0;
            this.lb_assginer.Text = "Assginer: ";
            // 
            // lb_creater
            // 
            this.lb_creater.AutoSize = true;
            this.lb_creater.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_creater.Location = new System.Drawing.Point(59, 112);
            this.lb_creater.Name = "lb_creater";
            this.lb_creater.Size = new System.Drawing.Size(56, 13);
            this.lb_creater.TabIndex = 0;
            this.lb_creater.Text = "Creater: ";
            // 
            // lb_relatied
            // 
            this.lb_relatied.AutoSize = true;
            this.lb_relatied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_relatied.Location = new System.Drawing.Point(59, 74);
            this.lb_relatied.Name = "lb_relatied";
            this.lb_relatied.Size = new System.Drawing.Size(59, 13);
            this.lb_relatied.TabIndex = 0;
            this.lb_relatied.Text = "Related: ";
            // 
            // rtb_ticketname
            // 
            this.rtb_ticketname.Location = new System.Drawing.Point(58, 12);
            this.rtb_ticketname.Name = "rtb_ticketname";
            this.rtb_ticketname.ReadOnly = true;
            this.rtb_ticketname.Size = new System.Drawing.Size(145, 41);
            this.rtb_ticketname.TabIndex = 1;
            this.rtb_ticketname.Text = "";
            // 
            // btn_assign
            // 
            this.btn_assign.Location = new System.Drawing.Point(135, 90);
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(75, 20);
            this.btn_assign.TabIndex = 2;
            this.btn_assign.Text = "Assgin";
            this.btn_assign.UseVisualStyleBackColor = true;
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // btn_pre
            // 
            this.btn_pre.Location = new System.Drawing.Point(3, 128);
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.Size = new System.Drawing.Size(65, 21);
            this.btn_pre.TabIndex = 3;
            this.btn_pre.Text = "button1";
            this.btn_pre.UseVisualStyleBackColor = true;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // btn_pend
            // 
            this.btn_pend.Location = new System.Drawing.Point(74, 128);
            this.btn_pend.Name = "btn_pend";
            this.btn_pend.Size = new System.Drawing.Size(65, 21);
            this.btn_pend.TabIndex = 3;
            this.btn_pend.Text = "button1";
            this.btn_pend.UseVisualStyleBackColor = true;
            this.btn_pend.Click += new System.EventHandler(this.btn_pend_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(145, 128);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(65, 21);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "button1";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(105, 26);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.detailToolStripMenuItem.Text = "Detail";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.detailToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Priority: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Related: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Assginer: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Creater: ";
            // 
            // TicketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_pend);
            this.Controls.Add(this.btn_pre);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.rtb_ticketname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_creater);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_assginer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_relatied);
            this.Controls.Add(this.lb_perority);
            this.Controls.Add(this.lb_name);
            this.Name = "TicketView";
            this.Size = new System.Drawing.Size(215, 152);
            this.Click += new System.EventHandler(this.TicketView_Click);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_perority;
        private System.Windows.Forms.Label lb_assginer;
        private System.Windows.Forms.Label lb_creater;
        private System.Windows.Forms.Label lb_relatied;
        private System.Windows.Forms.RichTextBox rtb_ticketname;
        private System.Windows.Forms.Button btn_assign;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Button btn_pend;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
