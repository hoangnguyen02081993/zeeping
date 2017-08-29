namespace ZeepingAdminDashboard
{
    partial class Form_main
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
            System.Windows.Forms.Button btn_listorder;
            System.Windows.Forms.Button btn_charge;
            System.Windows.Forms.Button btn_intro;
            System.Windows.Forms.Button btn_product;
            System.Windows.Forms.Button btn_other;
            System.Windows.Forms.Button btn_user;
            System.Windows.Forms.Button btn_support_customer;
            System.Windows.Forms.Button btn_FAQ;
            System.Windows.Forms.Button btn_collections;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.appOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chagnepassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrumBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_DB = new System.Windows.Forms.Label();
            this.lb_user = new System.Windows.Forms.Label();
            btn_listorder = new System.Windows.Forms.Button();
            btn_charge = new System.Windows.Forms.Button();
            btn_intro = new System.Windows.Forms.Button();
            btn_product = new System.Windows.Forms.Button();
            btn_other = new System.Windows.Forms.Button();
            btn_user = new System.Windows.Forms.Button();
            btn_support_customer = new System.Windows.Forms.Button();
            btn_FAQ = new System.Windows.Forms.Button();
            btn_collections = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.main_menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_listorder
            // 
            btn_listorder.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_listorder.ForeColor = System.Drawing.Color.Black;
            btn_listorder.Location = new System.Drawing.Point(17, 136);
            btn_listorder.Margin = new System.Windows.Forms.Padding(2);
            btn_listorder.Name = "btn_listorder";
            btn_listorder.Size = new System.Drawing.Size(170, 47);
            btn_listorder.TabIndex = 1;
            btn_listorder.Text = "Danh Sách Đơn Hàng";
            btn_listorder.UseVisualStyleBackColor = true;
            btn_listorder.Click += new System.EventHandler(this.btn_listorder_Click);
            // 
            // btn_charge
            // 
            btn_charge.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_charge.ForeColor = System.Drawing.Color.Black;
            btn_charge.Location = new System.Drawing.Point(17, 83);
            btn_charge.Margin = new System.Windows.Forms.Padding(2);
            btn_charge.Name = "btn_charge";
            btn_charge.Size = new System.Drawing.Size(170, 47);
            btn_charge.TabIndex = 2;
            btn_charge.Text = "Thanh Toán";
            btn_charge.UseVisualStyleBackColor = true;
            btn_charge.Click += new System.EventHandler(this.btn_charge_Click);
            // 
            // btn_intro
            // 
            btn_intro.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_intro.ForeColor = System.Drawing.Color.Black;
            btn_intro.Location = new System.Drawing.Point(17, 29);
            btn_intro.Margin = new System.Windows.Forms.Padding(2);
            btn_intro.Name = "btn_intro";
            btn_intro.Size = new System.Drawing.Size(170, 47);
            btn_intro.TabIndex = 3;
            btn_intro.Text = "Hướng Dẫn Sử Dụng";
            btn_intro.UseVisualStyleBackColor = true;
            btn_intro.Click += new System.EventHandler(this.btn_intro_Click);
            // 
            // btn_product
            // 
            btn_product.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_product.ForeColor = System.Drawing.Color.Black;
            btn_product.Location = new System.Drawing.Point(17, 188);
            btn_product.Margin = new System.Windows.Forms.Padding(2);
            btn_product.Name = "btn_product";
            btn_product.Size = new System.Drawing.Size(170, 47);
            btn_product.TabIndex = 4;
            btn_product.Text = "Sản Phẩm";
            btn_product.UseVisualStyleBackColor = true;
            btn_product.Click += new System.EventHandler(this.btn_product_Click);
            // 
            // btn_other
            // 
            btn_other.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_other.ForeColor = System.Drawing.Color.Black;
            btn_other.Location = new System.Drawing.Point(17, 449);
            btn_other.Margin = new System.Windows.Forms.Padding(2);
            btn_other.Name = "btn_other";
            btn_other.Size = new System.Drawing.Size(170, 47);
            btn_other.TabIndex = 5;
            btn_other.Text = "Khác";
            btn_other.UseVisualStyleBackColor = true;
            btn_other.Click += new System.EventHandler(this.btn_other_Click);
            // 
            // btn_user
            // 
            btn_user.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_user.ForeColor = System.Drawing.Color.Black;
            btn_user.Location = new System.Drawing.Point(17, 293);
            btn_user.Margin = new System.Windows.Forms.Padding(2);
            btn_user.Name = "btn_user";
            btn_user.Size = new System.Drawing.Size(170, 47);
            btn_user.TabIndex = 5;
            btn_user.Text = "User";
            btn_user.UseVisualStyleBackColor = true;
            btn_user.Click += new System.EventHandler(this.btn_user_Click);
            // 
            // btn_support_customer
            // 
            btn_support_customer.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_support_customer.ForeColor = System.Drawing.Color.Black;
            btn_support_customer.Location = new System.Drawing.Point(17, 347);
            btn_support_customer.Margin = new System.Windows.Forms.Padding(2);
            btn_support_customer.Name = "btn_support_customer";
            btn_support_customer.Size = new System.Drawing.Size(170, 47);
            btn_support_customer.TabIndex = 5;
            btn_support_customer.Text = "Yêu cầu hỗ trợ khách hàng";
            btn_support_customer.UseVisualStyleBackColor = true;
            btn_support_customer.Click += new System.EventHandler(this.btn_support_customer_Click);
            // 
            // btn_FAQ
            // 
            btn_FAQ.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_FAQ.ForeColor = System.Drawing.Color.Black;
            btn_FAQ.Location = new System.Drawing.Point(17, 398);
            btn_FAQ.Margin = new System.Windows.Forms.Padding(2);
            btn_FAQ.Name = "btn_FAQ";
            btn_FAQ.Size = new System.Drawing.Size(170, 47);
            btn_FAQ.TabIndex = 5;
            btn_FAQ.Text = "FAQ";
            btn_FAQ.UseVisualStyleBackColor = true;
            btn_FAQ.Click += new System.EventHandler(this.btn_FAQ_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(btn_intro);
            this.groupBox1.Controls.Add(btn_user);
            this.groupBox1.Controls.Add(btn_support_customer);
            this.groupBox1.Controls.Add(btn_FAQ);
            this.groupBox1.Controls.Add(btn_other);
            this.groupBox1.Controls.Add(btn_listorder);
            this.groupBox1.Controls.Add(btn_collections);
            this.groupBox1.Controls.Add(btn_product);
            this.groupBox1.Controls.Add(btn_charge);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 519);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // gbContent
            // 
            this.gbContent.BackColor = System.Drawing.Color.Transparent;
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbContent.Location = new System.Drawing.Point(200, 24);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(792, 567);
            this.gbContent.TabIndex = 7;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Content";
            // 
            // main_menu
            // 
            this.main_menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appOptionToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(992, 24);
            this.main_menu.TabIndex = 8;
            this.main_menu.Text = "menuStrip1";
            // 
            // appOptionToolStripMenuItem
            // 
            this.appOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.configToolStripMenuItem,
            this.chagnepassToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.appOptionToolStripMenuItem.Name = "appOptionToolStripMenuItem";
            this.appOptionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.appOptionToolStripMenuItem.Text = "App Option";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // chagnepassToolStripMenuItem
            // 
            this.chagnepassToolStripMenuItem.Name = "chagnepassToolStripMenuItem";
            this.chagnepassToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.chagnepassToolStripMenuItem.Text = "ChangePassword";
            this.chagnepassToolStripMenuItem.Click += new System.EventHandler(this.chagnepassToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scrumBoardToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // scrumBoardToolStripMenuItem
            // 
            this.scrumBoardToolStripMenuItem.Name = "scrumBoardToolStripMenuItem";
            this.scrumBoardToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scrumBoardToolStripMenuItem.Text = "ScrumBoard";
            this.scrumBoardToolStripMenuItem.Click += new System.EventHandler(this.scrumBoardToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_DB);
            this.panel1.Controls.Add(this.lb_user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 48);
            this.panel1.TabIndex = 9;
            // 
            // lb_DB
            // 
            this.lb_DB.AutoSize = true;
            this.lb_DB.Location = new System.Drawing.Point(8, 24);
            this.lb_DB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DB.Name = "lb_DB";
            this.lb_DB.Size = new System.Drawing.Size(59, 13);
            this.lb_DB.TabIndex = 1;
            this.lb_DB.Text = "Database: ";
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(8, 4);
            this.lb_user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(81, 13);
            this.lb_user.TabIndex = 0;
            this.lb_user.Text = "User: Unknown";
            // 
            // btn_collections
            // 
            btn_collections.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_collections.ForeColor = System.Drawing.Color.Black;
            btn_collections.Location = new System.Drawing.Point(19, 240);
            btn_collections.Margin = new System.Windows.Forms.Padding(2);
            btn_collections.Name = "btn_collections";
            btn_collections.Size = new System.Drawing.Size(170, 47);
            btn_collections.TabIndex = 4;
            btn_collections.Text = "Collections";
            btn_collections.UseVisualStyleBackColor = true;
            btn_collections.Click += new System.EventHandler(this.btn_collections_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.main_menu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1008, 636);
            this.MinimumSize = new System.Drawing.Size(1008, 597);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeeping.com - Administrator Dashboard";
            this.groupBox1.ResumeLayout(false);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_DB;
        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.ToolStripMenuItem appOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chagnepassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrumBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

