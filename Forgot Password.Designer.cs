namespace LibraryManagement
{
    partial class Forgot_Password
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
            btnbcklogin = new Button();
            label1 = new Label();
            txtunForgot = new TextBox();
            btnGen = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnbcklogin
            // 
            btnbcklogin.BackColor = Color.Plum;
            btnbcklogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnbcklogin.Location = new Point(146, 230);
            btnbcklogin.Name = "btnbcklogin";
            btnbcklogin.Size = new Size(117, 38);
            btnbcklogin.TabIndex = 0;
            btnbcklogin.Text = "Back to Login";
            btnbcklogin.UseVisualStyleBackColor = false;
            btnbcklogin.Click += btnbcklogin_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 9);
            label1.Name = "label1";
            label1.Size = new Size(325, 66);
            label1.TabIndex = 1;
            label1.Text = "Enter your username to generate temporary password";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // txtunForgot
            // 
            txtunForgot.Location = new Point(169, 115);
            txtunForgot.Name = "txtunForgot";
            txtunForgot.Size = new Size(205, 27);
            txtunForgot.TabIndex = 4;
            txtunForgot.TextChanged += txtunForgot_TextChanged;
            // 
            // btnGen
            // 
            btnGen.BackColor = Color.Plum;
            btnGen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGen.Location = new Point(83, 186);
            btnGen.Name = "btnGen";
            btnGen.Size = new Size(252, 38);
            btnGen.TabIndex = 5;
            btnGen.Text = "Generate Temporary Password";
            btnGen.UseVisualStyleBackColor = false;
            btnGen.Click += btnGen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 119);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 6;
            label2.Text = "Username:";
            // 
            // Forgot_Password
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Thistle;
            ClientSize = new Size(419, 285);
            Controls.Add(label2);
            Controls.Add(btnGen);
            Controls.Add(txtunForgot);
            Controls.Add(label1);
            Controls.Add(btnbcklogin);
            MaximizeBox = false;
            Name = "Forgot_Password";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgot_Password";
            Load += Forgot_Password_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnbcklogin;
        private Label label1;
        private TextBox txtunForgot;
        private Button btnGen;
        private Label label2;
    }
}