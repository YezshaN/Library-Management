namespace WindowsFormsApp1
{
    partial class Loan
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
            this.staffdetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtborrow = new System.Windows.Forms.Label();
            this.txtbook = new System.Windows.Forms.Label();
            this.txtstaff = new System.Windows.Forms.Label();
            this.txtmembers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.borrowdatePicker = new System.Windows.Forms.DateTimePicker();
            this.duedatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtdue = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returndate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.staffdetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // staffdetails
            // 
            this.staffdetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.staffdetails.Controls.Add(this.duedatePicker);
            this.staffdetails.Controls.Add(this.txtdue);
            this.staffdetails.Controls.Add(this.borrowdatePicker);
            this.staffdetails.Controls.Add(this.btnClear);
            this.staffdetails.Controls.Add(this.btnSave);
            this.staffdetails.Controls.Add(this.textBox3);
            this.staffdetails.Controls.Add(this.textBox2);
            this.staffdetails.Controls.Add(this.textBox1);
            this.staffdetails.Controls.Add(this.txtborrow);
            this.staffdetails.Controls.Add(this.txtbook);
            this.staffdetails.Controls.Add(this.txtstaff);
            this.staffdetails.Controls.Add(this.txtmembers);
            this.staffdetails.Location = new System.Drawing.Point(174, 50);
            this.staffdetails.Name = "staffdetails";
            this.staffdetails.Size = new System.Drawing.Size(469, 167);
            this.staffdetails.TabIndex = 1;
            this.staffdetails.TabStop = false;
            this.staffdetails.Text = "Staff Details";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(235, 126);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 27);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(137, 126);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(176, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(335, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtborrow
            // 
            this.txtborrow.AutoSize = true;
            this.txtborrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrow.Location = new System.Drawing.Point(242, 71);
            this.txtborrow.Name = "txtborrow";
            this.txtborrow.Size = new System.Drawing.Size(96, 16);
            this.txtborrow.TabIndex = 3;
            this.txtborrow.Text = "Borrow Date:";
            // 
            // txtbook
            // 
            this.txtbook.AutoSize = true;
            this.txtbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbook.Location = new System.Drawing.Point(332, 23);
            this.txtbook.Name = "txtbook";
            this.txtbook.Size = new System.Drawing.Size(47, 16);
            this.txtbook.TabIndex = 2;
            this.txtbook.Text = "Book:";
            // 
            // txtstaff
            // 
            this.txtstaff.AutoSize = true;
            this.txtstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaff.Location = new System.Drawing.Point(173, 23);
            this.txtstaff.Name = "txtstaff";
            this.txtstaff.Size = new System.Drawing.Size(103, 16);
            this.txtstaff.TabIndex = 1;
            this.txtstaff.Text = "Staff\'s Name: ";
            // 
            // txtmembers
            // 
            this.txtmembers.AutoSize = true;
            this.txtmembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmembers.Location = new System.Drawing.Point(22, 23);
            this.txtmembers.Name = "txtmembers";
            this.txtmembers.Size = new System.Drawing.Size(128, 16);
            this.txtmembers.TabIndex = 0;
            this.txtmembers.Text = "Member\'s Name: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(304, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 38);
            this.label6.TabIndex = 3;
            this.label6.Text = "LOAN RECORDS";
            // 
            // borrowdatePicker
            // 
            this.borrowdatePicker.Location = new System.Drawing.Point(245, 90);
            this.borrowdatePicker.Name = "borrowdatePicker";
            this.borrowdatePicker.Size = new System.Drawing.Size(200, 22);
            this.borrowdatePicker.TabIndex = 14;
            // 
            // duedatePicker
            // 
            this.duedatePicker.Location = new System.Drawing.Point(25, 90);
            this.duedatePicker.Name = "duedatePicker";
            this.duedatePicker.Size = new System.Drawing.Size(200, 22);
            this.duedatePicker.TabIndex = 16;
            // 
            // txtdue
            // 
            this.txtdue.AutoSize = true;
            this.txtdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdue.Location = new System.Drawing.Point(22, 71);
            this.txtdue.Name = "txtdue";
            this.txtdue.Size = new System.Drawing.Size(76, 16);
            this.txtdue.TabIndex = 15;
            this.txtdue.Text = "Due Date:";
            this.txtdue.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.member,
            this.book,
            this.borrowdate,
            this.duedate,
            this.returndate,
            this.status,
            this.edit,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(21, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(754, 215);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // member
            // 
            this.member.HeaderText = "Member Name";
            this.member.MinimumWidth = 6;
            this.member.Name = "member";
            this.member.ReadOnly = true;
            // 
            // book
            // 
            this.book.HeaderText = "Book";
            this.book.MinimumWidth = 6;
            this.book.Name = "book";
            this.book.ReadOnly = true;
            // 
            // borrowdate
            // 
            this.borrowdate.HeaderText = "Borrow Date";
            this.borrowdate.MinimumWidth = 6;
            this.borrowdate.Name = "borrowdate";
            this.borrowdate.ReadOnly = true;
            // 
            // duedate
            // 
            this.duedate.HeaderText = "Due Date";
            this.duedate.MinimumWidth = 6;
            this.duedate.Name = "duedate";
            this.duedate.ReadOnly = true;
            // 
            // returndate
            // 
            this.returndate.HeaderText = "Return Date";
            this.returndate.MinimumWidth = 6;
            this.returndate.Name = "returndate";
            this.returndate.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Items.AddRange(new object[] {
            "Active",
            "Returned",
            "Overdue"});
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.staffdetails);
            this.Name = "Loan";
            this.Text = "Loan";
            this.staffdetails.ResumeLayout(false);
            this.staffdetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox staffdetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtborrow;
        private System.Windows.Forms.Label txtbook;
        private System.Windows.Forms.Label txtstaff;
        private System.Windows.Forms.Label txtmembers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker borrowdatePicker;
        private System.Windows.Forms.DateTimePicker duedatePicker;
        private System.Windows.Forms.Label txtdue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn member;
        private System.Windows.Forms.DataGridViewTextBoxColumn book;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn duedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn returndate;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}