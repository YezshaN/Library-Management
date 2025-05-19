namespace LibraryManagement
{
    partial class Login
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
            lbUsername = new Label();
            lbPassword = new Label();
            btnLogin = new Button();
            txtPass = new TextBox();
            txtUN = new TextBox();
            btnForgot = new Button();
            SuspendLayout();
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbUsername.Location = new Point(53, 41);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(105, 25);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "Username: ";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            lbPassword.Location = new Point(53, 98);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(94, 25);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Plum;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(82, 165);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(108, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(164, 99);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(231, 27);
            txtPass.TabIndex = 4;
            // 
            // txtUN
            // 
            txtUN.Location = new Point(164, 41);
            txtUN.Name = "txtUN";
            txtUN.Size = new Size(231, 27);
            txtUN.TabIndex = 5;
            txtUN.TextChanged += txtUN_TextChanged;
            // 
            // btnForgot
            // 
            btnForgot.BackColor = Color.Plum;
            btnForgot.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForgot.Location = new Point(213, 165);
            btnForgot.Name = "btnForgot";
            btnForgot.Size = new Size(147, 39);
            btnForgot.TabIndex = 6;
            btnForgot.Text = "Forgot Password";
            btnForgot.UseVisualStyleBackColor = false;
            btnForgot.Click += btnForgot_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            ClientSize = new Size(452, 244);
            Controls.Add(btnForgot);
            Controls.Add(txtUN);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
            Controls.Add(lbPassword);
            Controls.Add(lbUsername);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUsername;
        private Label lbPassword;
        private Button btnLogin;
        private TextBox txtPass;
        private TextBox txtUN;
        private Button btnForgot;
    }
}