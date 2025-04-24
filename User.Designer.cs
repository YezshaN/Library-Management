namespace LibraryManagement
{
    partial class User
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
            tabUserManager = new TabControl();
            tabAdd = new TabPage();
            btnUseradd = new Button();
            txtAddpass = new TextBox();
            txtAddmail = new TextBox();
            txtAddUN = new TextBox();
            lbAddpass = new Label();
            lbAddmail = new Label();
            lbAddUN = new Label();
            tabProfile = new TabPage();
            txtSearch = new TextBox();
            panelUP = new Panel();
            btnUpdate = new Button();
            txtUDpass = new TextBox();
            txtUDmail = new TextBox();
            txtUDname = new TextBox();
            lbUDname = new Label();
            lbUDpass = new Label();
            lbUDmail = new Label();
            lbSearch = new Label();
            tabDelete = new TabPage();
            btnDelUs = new Button();
            txtDelUs = new TextBox();
            lbDelUs = new Label();
            tabUserManager.SuspendLayout();
            tabAdd.SuspendLayout();
            tabProfile.SuspendLayout();
            panelUP.SuspendLayout();
            tabDelete.SuspendLayout();
            SuspendLayout();
            // 
            // tabUserManager
            // 
            tabUserManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabUserManager.Controls.Add(tabAdd);
            tabUserManager.Controls.Add(tabProfile);
            tabUserManager.Controls.Add(tabDelete);
            tabUserManager.Location = new Point(-2, 1);
            tabUserManager.Name = "tabUserManager";
            tabUserManager.SelectedIndex = 0;
            tabUserManager.Size = new Size(513, 345);
            tabUserManager.TabIndex = 0;
            // 
            // tabAdd
            // 
            tabAdd.BackColor = Color.Thistle;
            tabAdd.Controls.Add(btnUseradd);
            tabAdd.Controls.Add(txtAddpass);
            tabAdd.Controls.Add(txtAddmail);
            tabAdd.Controls.Add(txtAddUN);
            tabAdd.Controls.Add(lbAddpass);
            tabAdd.Controls.Add(lbAddmail);
            tabAdd.Controls.Add(lbAddUN);
            tabAdd.Location = new Point(4, 29);
            tabAdd.Name = "tabAdd";
            tabAdd.Padding = new Padding(3);
            tabAdd.Size = new Size(505, 312);
            tabAdd.TabIndex = 0;
            tabAdd.Text = "Add User";
            // 
            // btnUseradd
            // 
            btnUseradd.BackColor = Color.Plum;
            btnUseradd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUseradd.Location = new Point(58, 225);
            btnUseradd.Name = "btnUseradd";
            btnUseradd.Size = new Size(370, 49);
            btnUseradd.TabIndex = 6;
            btnUseradd.Text = "Add User";
            btnUseradd.UseVisualStyleBackColor = false;
            // 
            // txtAddpass
            // 
            txtAddpass.Location = new Point(184, 153);
            txtAddpass.Name = "txtAddpass";
            txtAddpass.Size = new Size(244, 27);
            txtAddpass.TabIndex = 5;
            // 
            // txtAddmail
            // 
            txtAddmail.Location = new Point(184, 93);
            txtAddmail.Name = "txtAddmail";
            txtAddmail.Size = new Size(244, 27);
            txtAddmail.TabIndex = 4;
            // 
            // txtAddUN
            // 
            txtAddUN.Location = new Point(184, 38);
            txtAddUN.Name = "txtAddUN";
            txtAddUN.Size = new Size(244, 27);
            txtAddUN.TabIndex = 3;
            txtAddUN.TextChanged += txtAddUN_TextChanged;
            // 
            // lbAddpass
            // 
            lbAddpass.AutoSize = true;
            lbAddpass.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbAddpass.Location = new Point(58, 157);
            lbAddpass.Name = "lbAddpass";
            lbAddpass.Size = new Size(90, 23);
            lbAddpass.TabIndex = 2;
            lbAddpass.Text = "Password:";
            // 
            // lbAddmail
            // 
            lbAddmail.AutoSize = true;
            lbAddmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbAddmail.Location = new Point(58, 97);
            lbAddmail.Name = "lbAddmail";
            lbAddmail.Size = new Size(59, 23);
            lbAddmail.TabIndex = 1;
            lbAddmail.Text = "Email:";
            // 
            // lbAddUN
            // 
            lbAddUN.AutoSize = true;
            lbAddUN.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbAddUN.Location = new Point(58, 38);
            lbAddUN.Name = "lbAddUN";
            lbAddUN.Size = new Size(94, 23);
            lbAddUN.TabIndex = 0;
            lbAddUN.Text = "Username:";
            // 
            // tabProfile
            // 
            tabProfile.BackColor = Color.Thistle;
            tabProfile.BorderStyle = BorderStyle.FixedSingle;
            tabProfile.Controls.Add(txtSearch);
            tabProfile.Controls.Add(panelUP);
            tabProfile.Controls.Add(lbSearch);
            tabProfile.Location = new Point(4, 29);
            tabProfile.Name = "tabProfile";
            tabProfile.Padding = new Padding(3);
            tabProfile.Size = new Size(505, 312);
            tabProfile.TabIndex = 1;
            tabProfile.Text = "Update User Profile";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(259, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(206, 27);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panelUP
            // 
            panelUP.BackColor = Color.Plum;
            panelUP.BorderStyle = BorderStyle.FixedSingle;
            panelUP.Controls.Add(btnUpdate);
            panelUP.Controls.Add(txtUDpass);
            panelUP.Controls.Add(txtUDmail);
            panelUP.Controls.Add(txtUDname);
            panelUP.Controls.Add(lbUDname);
            panelUP.Controls.Add(lbUDpass);
            panelUP.Controls.Add(lbUDmail);
            panelUP.ForeColor = Color.Black;
            panelUP.Location = new Point(30, 70);
            panelUP.Name = "panelUP";
            panelUP.Size = new Size(435, 225);
            panelUP.TabIndex = 4;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Plum;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(27, 172);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(366, 48);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update Account Profile";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // txtUDpass
            // 
            txtUDpass.Location = new Point(163, 114);
            txtUDpass.Name = "txtUDpass";
            txtUDpass.Size = new Size(230, 27);
            txtUDpass.TabIndex = 6;
            // 
            // txtUDmail
            // 
            txtUDmail.Location = new Point(163, 64);
            txtUDmail.Name = "txtUDmail";
            txtUDmail.Size = new Size(230, 27);
            txtUDmail.TabIndex = 5;
            txtUDmail.TextChanged += textBox2_TextChanged;
            // 
            // txtUDname
            // 
            txtUDname.Enabled = false;
            txtUDname.Location = new Point(163, 12);
            txtUDname.Name = "txtUDname";
            txtUDname.Size = new Size(230, 27);
            txtUDname.TabIndex = 4;
            // 
            // lbUDname
            // 
            lbUDname.AutoSize = true;
            lbUDname.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbUDname.Location = new Point(16, 13);
            lbUDname.Name = "lbUDname";
            lbUDname.Size = new Size(94, 23);
            lbUDname.TabIndex = 1;
            lbUDname.Text = "Username:";
            // 
            // lbUDpass
            // 
            lbUDpass.AutoSize = true;
            lbUDpass.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbUDpass.Location = new Point(16, 115);
            lbUDpass.Name = "lbUDpass";
            lbUDpass.Size = new Size(90, 23);
            lbUDpass.TabIndex = 3;
            lbUDpass.Text = "Password:";
            // 
            // lbUDmail
            // 
            lbUDmail.AutoSize = true;
            lbUDmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbUDmail.Location = new Point(16, 65);
            lbUDmail.Name = "lbUDmail";
            lbUDmail.Size = new Size(59, 23);
            lbUDmail.TabIndex = 2;
            lbUDmail.Text = "Email:";
            lbUDmail.Click += lbUPmail_Click;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbSearch.Location = new Point(30, 28);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(177, 23);
            lbSearch.TabIndex = 0;
            lbSearch.Text = "Search by Username:";
            // 
            // tabDelete
            // 
            tabDelete.BackColor = Color.Thistle;
            tabDelete.Controls.Add(btnDelUs);
            tabDelete.Controls.Add(txtDelUs);
            tabDelete.Controls.Add(lbDelUs);
            tabDelete.Location = new Point(4, 29);
            tabDelete.Name = "tabDelete";
            tabDelete.Padding = new Padding(3);
            tabDelete.Size = new Size(505, 312);
            tabDelete.TabIndex = 2;
            tabDelete.Text = "Delete User";
            // 
            // btnDelUs
            // 
            btnDelUs.BackColor = Color.Plum;
            btnDelUs.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelUs.Location = new Point(27, 229);
            btnDelUs.Name = "btnDelUs";
            btnDelUs.Size = new Size(435, 56);
            btnDelUs.TabIndex = 2;
            btnDelUs.Text = "Delete Acount";
            btnDelUs.UseVisualStyleBackColor = false;
            btnDelUs.Click += btnDelUs_Click;
            // 
            // txtDelUs
            // 
            txtDelUs.Location = new Point(239, 32);
            txtDelUs.Name = "txtDelUs";
            txtDelUs.Size = new Size(223, 27);
            txtDelUs.TabIndex = 1;
            // 
            // lbDelUs
            // 
            lbDelUs.AutoSize = true;
            lbDelUs.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDelUs.Location = new Point(27, 32);
            lbDelUs.Name = "lbDelUs";
            lbDelUs.Size = new Size(177, 23);
            lbDelUs.TabIndex = 0;
            lbDelUs.Text = "Search by Username:";
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 347);
            Controls.Add(tabUserManager);
            Name = "User";
            Text = "User";
            tabUserManager.ResumeLayout(false);
            tabAdd.ResumeLayout(false);
            tabAdd.PerformLayout();
            tabProfile.ResumeLayout(false);
            tabProfile.PerformLayout();
            panelUP.ResumeLayout(false);
            panelUP.PerformLayout();
            tabDelete.ResumeLayout(false);
            tabDelete.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabUserManager;
        private TabPage tabAdd;
        private Label lbAddpass;
        private Label lbAddmail;
        private Label lbAddUN;
        private TabPage tabProfile;
        private TextBox txtAddpass;
        private TextBox txtAddmail;
        private TextBox txtAddUN;
        private Button btnUseradd;
        private Label lbUDpass;
        private Label lbUDmail;
        private Label lbUDname;
        private Label lbSearch;
        private Panel panelUP;
        private TextBox txtSearch;
        private TextBox txtUDpass;
        private TextBox txtUDmail;
        private TextBox txtUDname;
        private Button btnUpdate;
        private TabPage tabDelete;
        private Button btnDelUs;
        private TextBox txtDelUs;
        private Label lbDelUs;
    }
}