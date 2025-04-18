namespace WindowsFormsApp1
{
    partial class Transaction
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
            this.label6 = new System.Windows.Forms.Label();
            this.staffdetails = new System.Windows.Forms.GroupBox();
            this.txtreserve = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtbook = new System.Windows.Forms.Label();
            this.txtstaff = new System.Windows.Forms.Label();
            this.txtmembers = new System.Windows.Forms.Label();
            this.duedatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transac = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transacdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.staffdetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(290, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 38);
            this.label6.TabIndex = 7;
            this.label6.Text = "TRANSACTIONS";
            // 
            // staffdetails
            // 
            this.staffdetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.staffdetails.Controls.Add(this.comboBox2);
            this.staffdetails.Controls.Add(this.duedatePicker);
            this.staffdetails.Controls.Add(this.textBox2);
            this.staffdetails.Controls.Add(this.txtbook);
            this.staffdetails.Controls.Add(this.txtreserve);
            this.staffdetails.Controls.Add(this.label1);
            this.staffdetails.Controls.Add(this.btnClear);
            this.staffdetails.Controls.Add(this.btnSave);
            this.staffdetails.Controls.Add(this.textBox3);
            this.staffdetails.Controls.Add(this.textBox1);
            this.staffdetails.Controls.Add(this.txtstaff);
            this.staffdetails.Controls.Add(this.txtmembers);
            this.staffdetails.Location = new System.Drawing.Point(183, 50);
            this.staffdetails.Name = "staffdetails";
            this.staffdetails.Size = new System.Drawing.Size(439, 157);
            this.staffdetails.TabIndex = 6;
            this.staffdetails.TabStop = false;
            this.staffdetails.Text = "Staff Details";
            this.staffdetails.Enter += new System.EventHandler(this.staffdetails_Enter);
            // 
            // txtreserve
            // 
            this.txtreserve.AutoSize = true;
            this.txtreserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreserve.Location = new System.Drawing.Point(50, 63);
            this.txtreserve.Name = "txtreserve";
            this.txtreserve.Size = new System.Drawing.Size(130, 16);
            this.txtreserve.TabIndex = 15;
            this.txtreserve.Text = "Transaction Date:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(236, 119);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 27);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(114, 119);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(153, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 22);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 22);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 22);
            this.textBox1.TabIndex = 4;
            // 
            // txtbook
            // 
            this.txtbook.AutoSize = true;
            this.txtbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbook.Location = new System.Drawing.Point(263, 63);
            this.txtbook.Name = "txtbook";
            this.txtbook.Size = new System.Drawing.Size(62, 16);
            this.txtbook.TabIndex = 2;
            this.txtbook.Text = "Amount:";
            // 
            // txtstaff
            // 
            this.txtstaff.AutoSize = true;
            this.txtstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaff.Location = new System.Drawing.Point(150, 18);
            this.txtstaff.Name = "txtstaff";
            this.txtstaff.Size = new System.Drawing.Size(103, 16);
            this.txtstaff.TabIndex = 1;
            this.txtstaff.Text = "Staff\'s Name: ";
            // 
            // txtmembers
            // 
            this.txtmembers.AutoSize = true;
            this.txtmembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmembers.Location = new System.Drawing.Point(12, 18);
            this.txtmembers.Name = "txtmembers";
            this.txtmembers.Size = new System.Drawing.Size(128, 16);
            this.txtmembers.TabIndex = 0;
            this.txtmembers.Text = "Member\'s Name: ";
            // 
            // duedatePicker
            // 
            this.duedatePicker.Location = new System.Drawing.Point(53, 82);
            this.duedatePicker.Name = "duedatePicker";
            this.duedatePicker.Size = new System.Drawing.Size(200, 22);
            this.duedatePicker.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Transaction Type:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Membership Fee",
            "Fine",
            "Damage Book Fee",
            "Lost Book Fee"});
            this.comboBox2.Location = new System.Drawing.Point(292, 35);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(130, 24);
            this.comboBox2.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.member,
            this.staff,
            this.transac,
            this.amount,
            this.transacdate,
            this.edit,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 232);
            this.dataGridView1.TabIndex = 8;
            // 
            // member
            // 
            this.member.HeaderText = "Member Name";
            this.member.MinimumWidth = 6;
            this.member.Name = "member";
            this.member.ReadOnly = true;
            // 
            // staff
            // 
            this.staff.HeaderText = "Staff Name";
            this.staff.MinimumWidth = 6;
            this.staff.Name = "staff";
            // 
            // transac
            // 
            this.transac.HeaderText = "Transaction Type";
            this.transac.MinimumWidth = 6;
            this.transac.Name = "transac";
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // transacdate
            // 
            this.transacdate.HeaderText = "Transaction Date";
            this.transacdate.MinimumWidth = 6;
            this.transacdate.Name = "transacdate";
            this.transacdate.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Text = "";
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Text = "";
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.staffdetails);
            this.Name = "Transaction";
            this.Text = "Transaction";
            this.staffdetails.ResumeLayout(false);
            this.staffdetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox staffdetails;
        private System.Windows.Forms.Label txtreserve;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtbook;
        private System.Windows.Forms.Label txtstaff;
        private System.Windows.Forms.Label txtmembers;
        private System.Windows.Forms.DateTimePicker duedatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn member;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff;
        private System.Windows.Forms.DataGridViewComboBoxColumn transac;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn transacdate;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}