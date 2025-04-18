namespace WindowsFormsApp1
{
    partial class Reservation
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
            this.duedatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtreserve = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtstat = new System.Windows.Forms.Label();
            this.txtbook = new System.Windows.Forms.Label();
            this.txtstaff = new System.Windows.Forms.Label();
            this.txtmembers = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.label6.Location = new System.Drawing.Point(230, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(337, 38);
            this.label6.TabIndex = 5;
            this.label6.Text = "RESERVATION RECORDS";
            // 
            // staffdetails
            // 
            this.staffdetails.BackColor = System.Drawing.Color.LightSteelBlue;
            this.staffdetails.Controls.Add(this.comboBox1);
            this.staffdetails.Controls.Add(this.duedatePicker);
            this.staffdetails.Controls.Add(this.txtreserve);
            this.staffdetails.Controls.Add(this.btnClear);
            this.staffdetails.Controls.Add(this.btnSave);
            this.staffdetails.Controls.Add(this.textBox3);
            this.staffdetails.Controls.Add(this.textBox2);
            this.staffdetails.Controls.Add(this.textBox1);
            this.staffdetails.Controls.Add(this.txtstat);
            this.staffdetails.Controls.Add(this.txtbook);
            this.staffdetails.Controls.Add(this.txtstaff);
            this.staffdetails.Controls.Add(this.txtmembers);
            this.staffdetails.Location = new System.Drawing.Point(12, 50);
            this.staffdetails.Name = "staffdetails";
            this.staffdetails.Size = new System.Drawing.Size(776, 125);
            this.staffdetails.TabIndex = 4;
            this.staffdetails.TabStop = false;
            this.staffdetails.Text = "Staff Details";
            // 
            // duedatePicker
            // 
            this.duedatePicker.Location = new System.Drawing.Point(433, 42);
            this.duedatePicker.Name = "duedatePicker";
            this.duedatePicker.Size = new System.Drawing.Size(200, 22);
            this.duedatePicker.TabIndex = 16;
            // 
            // txtreserve
            // 
            this.txtreserve.AutoSize = true;
            this.txtreserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreserve.Location = new System.Drawing.Point(430, 23);
            this.txtreserve.Name = "txtreserve";
            this.txtreserve.Size = new System.Drawing.Size(132, 16);
            this.txtreserve.TabIndex = 15;
            this.txtreserve.Text = "Reservation Date:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(404, 84);
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
            this.btnSave.Location = new System.Drawing.Point(292, 84);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(153, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 22);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(292, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 22);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 22);
            this.textBox1.TabIndex = 4;
            // 
            // txtstat
            // 
            this.txtstat.AutoSize = true;
            this.txtstat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstat.Location = new System.Drawing.Point(657, 23);
            this.txtstat.Name = "txtstat";
            this.txtstat.Size = new System.Drawing.Size(54, 16);
            this.txtstat.TabIndex = 3;
            this.txtstat.Text = "Status:";
            // 
            // txtbook
            // 
            this.txtbook.AutoSize = true;
            this.txtbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbook.Location = new System.Drawing.Point(289, 23);
            this.txtbook.Name = "txtbook";
            this.txtbook.Size = new System.Drawing.Size(47, 16);
            this.txtbook.TabIndex = 2;
            this.txtbook.Text = "Book:";
            // 
            // txtstaff
            // 
            this.txtstaff.AutoSize = true;
            this.txtstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaff.Location = new System.Drawing.Point(150, 23);
            this.txtstaff.Name = "txtstaff";
            this.txtstaff.Size = new System.Drawing.Size(103, 16);
            this.txtstaff.TabIndex = 1;
            this.txtstaff.Text = "Staff\'s Name: ";
            // 
            // txtmembers
            // 
            this.txtmembers.AutoSize = true;
            this.txtmembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmembers.Location = new System.Drawing.Point(12, 23);
            this.txtmembers.Name = "txtmembers";
            this.txtmembers.Size = new System.Drawing.Size(128, 16);
            this.txtmembers.TabIndex = 0;
            this.txtmembers.Text = "Member\'s Name: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pending",
            "Cancelled",
            "Completed"});
            this.comboBox1.Location = new System.Drawing.Point(660, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 24);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.member,
            this.book,
            this.reservedate,
            this.status,
            this.edit,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 181);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 257);
            this.dataGridView1.TabIndex = 6;
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
            // reservedate
            // 
            this.reservedate.HeaderText = "Reservation Date";
            this.reservedate.MinimumWidth = 6;
            this.reservedate.Name = "reservedate";
            this.reservedate.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Items.AddRange(new object[] {
            "Pending",
            "Completed",
            "Cancelled"});
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
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.staffdetails);
            this.Name = "Reservation";
            this.Text = "Reservation";
            this.staffdetails.ResumeLayout(false);
            this.staffdetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox staffdetails;
        private System.Windows.Forms.DateTimePicker duedatePicker;
        private System.Windows.Forms.Label txtreserve;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtstat;
        private System.Windows.Forms.Label txtbook;
        private System.Windows.Forms.Label txtstaff;
        private System.Windows.Forms.Label txtmembers;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn member;
        private System.Windows.Forms.DataGridViewTextBoxColumn book;
        private System.Windows.Forms.DataGridViewTextBoxColumn reservedate;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}