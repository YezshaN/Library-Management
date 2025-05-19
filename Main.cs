using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;
using Org.BouncyCastle.Asn1.Cmp;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using DocumentFormat.OpenXml;


namespace LibraryManagement
{
    public partial class Main : Form
    {
        string connectionString = "Server=localhost;Port=3306;Database=libmagementt;Uid=root;Pwd=yesh63780;";
        private MySqlConnection connection;

        private System.Windows.Forms.Timer reviewTimer;
        private List<Review> reviews;  // List to store reviews
        private int currentReviewIndex = 0;
        //new
        // private bool comboBoxesPopulated = false;

        private string selectedBookTitle = string.Empty;
        private int selectedBookId = 0;
        private int selectedMemberId = 0;
        private int selectedLoanId = 0;
        private int selectedReservationId = 0;
        private int selectedTransactionId = 0;
        private int selectedStaffId = 0;
        private DataTable _loansTable;



        public Main()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);

            // Initialize the list of reviews
            reviews = new List<Review>();

            //review timer to refresh every 10 seconds
            reviewTimer = new System.Windows.Forms.Timer();
            reviewTimer.Interval = 10000;  // 10 seconds
            reviewTimer.Tick += ReviewTimer_Tick;  
            reviewTimer.Start();  

        }

       
        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();
            LoadLoans();
            LoadReservations();
            LoadTransactions();
            LoadStaff();
            LoadReviews();

            PopulateComboBox();
            PopulateStatusComboBox();
            PopulateRoleComboBox();
            PopulateReportTypeComboBox();

            await PopulateMembersComboBoxAsync();
            await PopulateStaffComboBoxAsync();
            await PopulateBooksComboBoxAsync();

            UpdateBookCountLabel();
            UpdateAvailableBooksLabel();
            UpdateLoanedBooksLabel();
            UpdateLoanedBooksLabel();
            UpdateOverdueBooksLabel();
            UpdatePopularBookLabel();
        }

        private void LoadMembers()
        {
            string selectQuery = "SELECT member_id, first_name, last_name, email, phone, address, join_date FROM members";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
            DataTable dataTable = new DataTable();

           
            dataAdapter.Fill(dataTable);
            gridViewMembers.DataSource = dataTable;

        }

        private void LoadBooks()
        {
            string selectQuery = "SELECT book_id, title, author, genre, published_year, total_copies, available_copies FROM books";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connectionString);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            gridViewBooks.DataSource = dataTable;

        }
        private void ViewAvailableBooks()
        {
            string query = "SELECT title, author, available_copies FROM books WHERE available_copies > 0";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            gridViewBooks.DataSource = dataTable;
        }
        private void ViewBookSummary()
        {
            string query = "SELECT genre, total_books, total_copies FROM view_books_summary";  // Example query
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            gridViewBooks.DataSource = dataTable;
        }

        private void PopulateComboBox()
        {
            comboBox1.Items.Add("View Available Books");
            comboBox1.Items.Add("View Book Summary");
        }


        private async Task PopulateMembersComboBoxAsync()
        {
            string query = "SELECT member_id, CONCAT(first_name, ' ', last_name) AS full_name FROM members";
            comboBoxMemL.Items.Clear();

            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    await connection.OpenAsync();  
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));  

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            var fullName = row["full_name"]?.ToString();
                            if (!string.IsNullOrEmpty(fullName))
                            {
                                comboBoxMemL.Items.Add(fullName);  // Loan Member ComboBox
                                comboBoxMemR.Items.Add(fullName);  // Reservations Member ComboBox
                                comboMemT.Items.Add(fullName); //Transacions Member ComboBox
                            }
                        }

                        //Loan
                        comboBoxMemL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxMemL.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //Reservation
                        comboBoxMemR.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxMemR.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //Transactions
                        comboMemT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboMemT.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }

                    else
                    {
                        MessageBox.Show("No members found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  // Handle any exceptions
                }
            }
        }

        private async Task PopulateStaffComboBoxAsync()
        {
            string query = "SELECT staff_id, CONCAT(first_name, ' ', last_name) AS full_name FROM staff";
            comboBoxStaffL.Items.Clear();

            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    await connection.OpenAsync();  
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));  

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            var fullName = row["full_name"]?.ToString();
                            if (!string.IsNullOrEmpty(fullName))
                            {
                                comboBoxStaffL.Items.Add(fullName);  // Loan Staff ComboBox
                                comboBoxStaffR.Items.Add(fullName);  // Reservation Staff ComboBox
                                comboBoxStaffT.Items.Add(fullName);  //Transaction Staff ComboBox
                            }
                        }

                        // Set AutoComplete properties for better user experience
                        //Loan
                        comboBoxStaffL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxStaffL.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //Reservation
                        comboBoxStaffR.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxStaffR.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //Transaction
                        comboBoxStaffT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxStaffT.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                    else
                    {
                        MessageBox.Show("No staff members found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  
                }
            }
        }

        private async Task PopulateBooksComboBoxAsync()
        {
            string query = "SELECT book_id, title FROM books";
            comboloanBook.Items.Clear();

            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    await connection.OpenAsync();  
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));  

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            var title = row["title"]?.ToString();
                            if (!string.IsNullOrEmpty(title))
                            {
                                comboloanBook.Items.Add(title);  // Loan Books ComboBox
                                comboreserBook.Items.Add(title); //Reservation Books Combo Box
                            }
                        }

       
                        //Loan
                        comboloanBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboloanBook.AutoCompleteSource = AutoCompleteSource.ListItems;
                        //Reservation
                        comboreserBook.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboreserBook.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                    else
                    {
                        MessageBox.Show("No books found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  
                }
            }
        }

        private void PopulateStatusComboBox()
        {
            //LOAN
            comboloanStat.Items.Clear();
            comboloanStat.Items.Add("borrowed");
            comboloanStat.Items.Add("returned");
            comboloanStat.Items.Add("overdue");

            comboloanStat.SelectedItem = "borrowed";

            //RESERVATION
            comboreserStatus.Items.Clear();
            comboreserStatus.Items.Add("Pending");
            comboreserStatus.Items.Add("Completed");
            comboreserStatus.Items.Add("Cancelled");

            
            comboreserStatus.SelectedItem = "Pending";

            //TRANSACTION TYPE
            combotransac.Items.Clear();
            combotransac.Items.Add("Membership Fee");
            combotransac.Items.Add("Fine");
            combotransac.Items.Add("Damage Book Fee");
            combotransac.Items.Add("Lost Book Fee");
        }

        private void PopulateRoleComboBox()
        {
            comboBoxRole.Items.Clear(); 
            comboBoxRole.Items.Add("Librarian");
            comboBoxRole.Items.Add("Assistant");
        }

        private void LoadLoans()
        {
            //Automatically update the status based on the return date and due date
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = new MySqlCommand(@"
          UPDATE loans
             SET status = CASE
               WHEN return_date IS NOT NULL THEN 'returned'
               WHEN return_date IS NULL AND due_date < CURDATE() THEN 'overdue'
               WHEN return_date IS NULL AND due_date >= CURDATE() THEN 'borrowed'
               ELSE status
             END
           WHERE return_date IS NULL OR return_date IS NOT NULL;", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            foreach (var combo in gridViewLoans.Columns
                                    .OfType<DataGridViewComboBoxColumn>()
                                    .ToList())
                gridViewLoans.Columns.Remove(combo);

            
            const string sql = @"
              SELECT
                l.loan_id,
                CONCAT(m.first_name,' ',m.last_name) AS member_name,
                b.title                           AS book_title,
                CONCAT(s.first_name,' ',s.last_name) AS staff_name,
                l.borrow_date,
                l.due_date,
                l.return_date,
                l.status
              FROM loans l
              JOIN members m ON l.member_id = m.member_id
              JOIN books   b ON l.book_id   = b.book_id
              JOIN staff   s ON l.staff_id  = s.staff_id
              ORDER BY l.loan_id DESC;";

            /* var dt = new DataTable();
             using (var da = new MySqlDataAdapter(sql, connectionString))
                 da.Fill(dt);

             //added this line
             gridViewLoans.DataSource = null;
             gridViewLoans.DataSource = dt;
             gridViewLoans.Refresh(); */

            _loansTable = new DataTable();
            using (var da = new MySqlDataAdapter(sql, connectionString))
                da.Fill(_loansTable);

            gridViewLoans.DataSource = _loansTable;
            gridViewLoans.Refresh();
        }


        private void ViewOverdueLoans()
        {
            string query = "SELECT * FROM view_overdue_loans";  // Use your view if already created
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            gridViewLoans.DataSource = dataTable;
        }


        private void ViewReturnedLoans()
        {
            string query = "SELECT * FROM loans WHERE status = 'returned'";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            gridViewLoans.DataSource = dataTable;
        }



        private void LoadReservations()
        {
            
            const string sql = @"
        SELECT
            r.reservation_id,
            CONCAT(m.first_name, ' ', m.last_name) AS member_name,
            b.title AS book_title,
            CONCAT(s.first_name, ' ', s.last_name) AS staff_name,
            r.reservation_date,
            r.status
        FROM reservation r
        JOIN members m ON r.member_id = m.member_id
        JOIN books b ON r.book_id = b.book_id
        JOIN staff s ON r.staff_id = s.staff_id
        ORDER BY r.reservation_id DESC;";

            var dt = new DataTable();
            using (var da = new MySqlDataAdapter(sql, connectionString))
                da.Fill(dt);

            // Bind the data to the DataGridView
            gridViewReservation.DataSource = null;
            gridViewReservation.DataSource = dt;
            gridViewReservation.Refresh();
        }


        private void LoadTransactions()
        {
            //Pull data from the transactions table and format it for the DataGridView
            const string sql = @"
    SELECT
        t.transaction_id,
        CONCAT(m.first_name, ' ', m.last_name) AS member_name,
        CONCAT(s.first_name, ' ', s.last_name) AS staff_name,
        t.transaction_type,
        t.amount,
        t.transaction_date
    FROM transactions t
    JOIN members m ON t.member_id = m.member_id
    JOIN staff s ON t.staff_id = s.staff_id
    ORDER BY t.transaction_id DESC;";

            var dt = new DataTable();
            using (var da = new MySqlDataAdapter(sql, connectionString))
                da.Fill(dt);

            // Bind the data to the DataGridView
            dataGridViewTransaction.DataSource = null;  
            dataGridViewTransaction.DataSource = dt;
            dataGridViewTransaction.Refresh();
        }


        private void LoadStaff()
        {
            string selectQuery = "SELECT staff_id, first_name, last_name, email, phone, role FROM staff WHERE role != 'Admin'";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
            DataTable dataTable = new DataTable();

            // Fill the data table
            dataAdapter.Fill(dataTable);

            // Bind the data table to the DataGridView
            gridViewStaff.DataSource = dataTable;
        }


        private int GetTotalBooks()
        {
            int totalBooks = 0;

            // Define the query to count the distinct books (titles)
            string selectQuery = "SELECT COUNT(DISTINCT title) FROM books";  // Adjust table name and column if necessary

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    // Execute the query and get the result (total number of distinct books)
                    totalBooks = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return totalBooks;
        }

        private void UpdateTotalBooksLabel()
        {
            int totalBooks = GetTotalBooks();
            Totalnum.Text = totalBooks.ToString();
        }


        private void UpdateBookCountLabel()
        {
            int totalBooks = GetTotalBooks();
            Totalnum.Text = totalBooks.ToString();  // Update only the number
        }


        private int GetTotalAvailableBooks()  
        {
            int totalAvailableBooks = 0;

            
            string selectQuery = "SELECT SUM(available_copies) FROM books";  

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                   
                    totalAvailableBooks = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return totalAvailableBooks;
        }

        private void UpdateAvailableBooksLabel()
        {
            int totalAvailableBooks = GetTotalAvailableBooks();
            lbAvailnum.Text = totalAvailableBooks.ToString();  
        }


        private int GetLoanedBooksToday()
        {
            int loanedBooksToday = 0;

            
            string selectQuery = "SELECT COUNT(*) FROM loans WHERE borrow_date = CURDATE() AND status != 'returned'";  

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    // Execute the query and get the result (total loaned books today)
                    loanedBooksToday = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return loanedBooksToday;
        }


        private void UpdateLoanedBooksLabel()
        {
            int loanedBooksToday = GetLoanedBooksToday();  
            lbLoanednum.Text = loanedBooksToday.ToString();  
        }


        private int GetOverdueBooksThisWeek()
        {
            int overdueBooksThisWeek = 0;

            
            string selectQuery = "SELECT COUNT(*) FROM view_overdue_loans WHERE return_date IS NULL AND borrow_date <= CURDATE() AND WEEK(borrow_date, 1) = WEEK(CURDATE(), 1)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    // Execute the query and get the result (overdue books count this week)
                    overdueBooksThisWeek = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return overdueBooksThisWeek;
        }


        private void UpdateOverdueBooksLabel()
        {
            int overdueBooksThisWeek = GetOverdueBooksThisWeek();  // Get overdue books count this week
            lbOvernum.Text = overdueBooksThisWeek.ToString();  // Update the label with the overdue books count
        }


        private string GetMostLoanedBookOfTheMonth()
        {
            string? mostLoanedBook = string.Empty;
            string selectQuery = @"
        SELECT b.title 
        FROM loans l
        JOIN books b ON l.book_id = b.book_id
        WHERE MONTH(l.borrow_date) = MONTH(CURDATE())
        AND YEAR(l.borrow_date) = YEAR(CURDATE())
        GROUP BY l.book_id
        ORDER BY COUNT(l.book_id) DESC
        LIMIT 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    // Execute the query and get the title of the most loaned book
                    mostLoanedBook = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return mostLoanedBook;
        }


        private void UpdatePopularBookLabel()
        {
            string mostLoanedBook = GetMostLoanedBookOfTheMonth();  // Get the most loaned book of the month
            lbBookpop.Text = mostLoanedBook;  // Update the label with the most loaned book title
        }


        private void ReviewTimer_Tick(object sender, EventArgs e)
        {
            DisplayNextReview();  // Display the next review on the labels
        }


        private List<Review> GetReviewsFromDatabase()
        {
            List<Review> reviews = new List<Review>();

            string selectQuery = "SELECT books.title, review.rating, review.comment FROM review INNER JOIN books ON review.book_id = books.book_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string bookTitle = reader["title"].ToString();
                        int rating = Convert.ToInt32(reader["rating"]);
                        string comment = reader["comment"].ToString();

                        reviews.Add(new Review
                        {
                            BookTitle = bookTitle,
                            Rating = rating,
                            Comment = comment
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return reviews;
        }


        private void LoadReviews()
        {
            reviews = GetReviewsFromDatabase();  // Fetch the reviews

            // Display the first review if available
            if (reviews.Count > 0)
            {
                DisplayNextReview();  // Display the first review
            }
        }

        // Method to display the next review (or the first review initially)
        private void DisplayNextReview()
        {
            if (reviews.Count == 0)
                return;  // No reviews to display

            // Get the current review
            Review currentReview = reviews[currentReviewIndex];

            // Update the labels with the current review's details
            lbrevB.Text = "Title: " + currentReview.BookTitle;
            lbRate.Text = "Rating: " + currentReview.Rating.ToString();
            lbComment.Text = "Comment: " + currentReview.Comment;


            // Move to the next review (cycle back to the first one if at the end)
            currentReviewIndex = (currentReviewIndex + 1) % reviews.Count;
        }

        // Review class to hold review data
        public class Review
        {
            public string BookTitle { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; }
        }


        private void LoadReportData(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    gridViewLoans.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading report: " + ex.Message);
                }
            }
        }


        private void ExportToExcel(DataGridView dgv)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Create a spreadsheet document
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
                {
                    // Create the workbook and worksheet
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                    sheets.Append(sheet);

                    // Get the sheet data
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    // Add the header row
                    Row headerRow = new Row();
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            headerRow.AppendChild(new Cell() { CellValue = new CellValue(column.HeaderText), DataType = CellValues.String });
                        }
                    }
                    sheetData.AppendChild(headerRow);

                    // Add data rows
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        Row dataRow = new Row();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Visible)
                            {
                                // Check if cell value is null and handle it
                                string cellValue = cell.Value?.ToString() ?? ""; // Use empty string if null
                                dataRow.AppendChild(new Cell() { CellValue = new CellValue(cellValue), DataType = CellValues.String });
                            }
                        }
                        sheetData.AppendChild(dataRow);
                    }

                    // Save the file to disk
                    document.Save();
                }

                // Save the memory stream as a file
                File.WriteAllBytes("ExportedData.xlsx", ms.ToArray());
            }

            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void ClearTextBoxes()
        {
            txtTitle.Clear();
            textAuth.Clear();
            txtGenre.Clear();
            txtYP.Clear();
            txtTotal.Clear();
            txtNamemem.Clear();
            txtMailmem.Clear();
            txtPhonemem.Clear();
            txtAddmem.Clear();
        }


        private void ClearStaffForm()
        {
            txtStaffName.Clear();
            txtStaffEmail.Clear();
            txtStaffPhone.Clear();
            comboBoxRole.SelectedIndex = -1;
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string phone = txtPhonemem.Text.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes
            string fullName = txtNamemem.Text.Trim();
            string[] nameParts = fullName.Split(' ');  // Split into first and last name
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please enter both first and last names.");
                return;
            }
            string firstName = nameParts[0];
            string lastName = nameParts[1];
            string email = txtMailmem.Text;
            string phone = txtPhonemem.Text;
            string address = txtAddmem.Text;
            DateTime joinDate = dTPMem.Value;

            // SQL query to insert new member
            string insertQuery = "INSERT INTO members (first_name, last_name, email, phone, address, join_date) " +
                                 "VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @JoinDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@JoinDate", joinDate);

                try
                {
                    connection.Open();  // Open connection to the database
                    cmd.ExecuteNonQuery();  // Execute the insert query

                    MessageBox.Show("Member added successfully!");  // Show success message

                    ClearTextBoxes();
                    // Optionally refresh the DataGridView to show the new member
                    LoadMembers();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  // Show error message if something goes wrong
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void dTPBorrow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the click is on a valid row (not on the column header)
            if (e.RowIndex >= 0)
            {
                // Get the data from the clicked row
                selectedBookTitle = gridViewBooks.Rows[e.RowIndex].Cells["title"].Value.ToString();
                selectedBookId = Convert.ToInt32(gridViewBooks.Rows[e.RowIndex].Cells["book_id"].Value);  // Retrieve book_id

                string bookAuthor = gridViewBooks.Rows[e.RowIndex].Cells["author"].Value.ToString();
                string bookGenre = gridViewBooks.Rows[e.RowIndex].Cells["genre"].Value.ToString();
                int bookPublishedYear = Convert.ToInt32(gridViewBooks.Rows[e.RowIndex].Cells["published_year"].Value);
                int bookTotalCopies = Convert.ToInt32(gridViewBooks.Rows[e.RowIndex].Cells["total_copies"].Value);

                // Fill the textboxes with the selected book data
                txtTitle.Text = selectedBookTitle;
                textAuth.Text = bookAuthor;
                txtGenre.Text = bookGenre;
                txtYP.Text = bookPublishedYear.ToString();
                txtTotal.Text = bookTotalCopies.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the data from the clicked row
                selectedMemberId = Convert.ToInt32(gridViewMembers.Rows[e.RowIndex].Cells["member_id"].Value);  // Retrieve member_id

                string firstName = gridViewMembers.Rows[e.RowIndex].Cells["first_name"].Value?.ToString() ?? string.Empty;
                string lastName = gridViewMembers.Rows[e.RowIndex].Cells["last_name"].Value?.ToString() ?? string.Empty;
                string email = gridViewMembers.Rows[e.RowIndex].Cells["email"].Value?.ToString() ?? string.Empty;
                string phone = gridViewMembers.Rows[e.RowIndex].Cells["phone"].Value?.ToString() ?? string.Empty;
                string address = gridViewMembers.Rows[e.RowIndex].Cells["address"].Value?.ToString() ?? string.Empty;

                // Fill the textboxes with the selected member's details
                txtNamemem.Text = firstName + " " + lastName;
                txtMailmem.Text = email;
                txtPhonemem.Text = phone;
                txtAddmem.Text = address;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Resert_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtreserMN_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboreserBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedBookTitle = comboreserBook.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedBookTitle))
            {

            }
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedStatus = comboreserStatus.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedStatus))
            {
                // You can perform additional actions based on the selected status here
                // For example, updating the reservation status in the database or UI
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridViewReservation.Rows.Count) return;

            // Get the selected row
            DataGridViewRow selectedRow = gridViewReservation.Rows[e.RowIndex];

            // Populate controls with the values from the selected row
            if (selectedRow.Cells["member_name"].Value != DBNull.Value)
                comboBoxMemR.Text = selectedRow.Cells["member_name"].Value.ToString();
            else
                comboBoxMemR.Text = string.Empty;

            if (selectedRow.Cells["staff_name"].Value != DBNull.Value)
                comboBoxStaffR.Text = selectedRow.Cells["staff_name"].Value.ToString();
            else
                comboBoxStaffR.Text = string.Empty;

            if (selectedRow.Cells["book_title"].Value != DBNull.Value)
                comboreserBook.Text = selectedRow.Cells["book_title"].Value.ToString();
            else
                comboreserBook.Text = string.Empty;

            // Handle reservation_date
            var reservationDateCell = selectedRow.Cells["reservation_date"];
            if (reservationDateCell.Value != DBNull.Value)
            {
                DateTime reservationDate = Convert.ToDateTime(reservationDateCell.Value);
                // gridViewReservation.Value = reservationDate;
                selectedRow.Cells["reservation_date"].Value = reservationDate;
            }
            else
            {
                //gridViewReservation.Value = DateTime.Today;  // Default to today's date if reservation_date is null
                selectedRow.Cells["reservation_date"].Value = DateTime.Today;  // Default to today's date if reservation_date is null
            }

            // Retrieve the status value directly from the status column
            var statusValue = selectedRow.Cells["status"].Value?.ToString();

            // Now you have the current status in 'statusValue'
            comboreserStatus.Text = statusValue ?? string.Empty;  // Assuming you have a ComboBox for status

            // Handle reservation_id (for updates or deletions)
            if (selectedRow.Cells["reservation_id"].Value != DBNull.Value)
                selectedReservationId = Convert.ToInt32(selectedRow.Cells["reservation_id"].Value);
            else
                selectedReservationId = 0;  // Reset to an invalid reservation_id if it's null

            // Optionally highlight the selected row
            selectedRow.Selected = true;
        }

        private void lbreserMN_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string email = txtStaffEmail.Text.Trim();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string phone = txtStaffPhone.Text.Trim();
        }

        private void gridViewStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the data from the clicked row
                selectedStaffId = Convert.ToInt32(gridViewStaff.Rows[e.RowIndex].Cells["staff_id"].Value);  // Retrieve staff_id

                string firstName = gridViewStaff.Rows[e.RowIndex].Cells["first_name"].Value?.ToString() ?? string.Empty;
                string lastName = gridViewStaff.Rows[e.RowIndex].Cells["last_name"].Value?.ToString() ?? string.Empty;
                string email = gridViewStaff.Rows[e.RowIndex].Cells["email"].Value?.ToString() ?? string.Empty;
                string phone = gridViewStaff.Rows[e.RowIndex].Cells["phone"].Value?.ToString() ?? string.Empty;
                string role = gridViewStaff.Rows[e.RowIndex].Cells["role"].Value?.ToString() ?? string.Empty;

                // Fill the textboxes with the selected staff's details
                txtStaffName.Text = firstName + " " + lastName;
                txtStaffEmail.Text = email;
                txtStaffPhone.Text = phone;
                comboBoxRole.SelectedItem = role;  // Set role in the combo box
            }
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void lbPopular_Click(object sender, EventArgs e)
        {

        }

        private void lbRate_Click(object sender, EventArgs e)
        {

        }

        private void lbComment_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTotal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxBooks_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = textAuth.Text;
            string genre = txtGenre.Text;
            int yearPublished = int.Parse(txtYP.Text); // Assuming the Year Published is an integer
            int totalCopies = int.Parse(txtTotal.Text);

            string insertQuery = "INSERT INTO books (title, author, genre, published_year, total_copies) " +
                                 "VALUES (@Title, @Author, @Genre, @YearPublished, @TotalCopies)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@YearPublished", yearPublished);
                cmd.Parameters.AddWithValue("@TotalCopies", totalCopies);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book details saved successfully!");

                    ClearTextBoxes();

                    // Refresh the DataGridView to show updated data
                    LoadBooks();
                    UpdateTotalBooksLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelB_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Please select a book to delete.");
                return;
            }

            string deleteQuery = "DELETE FROM books WHERE book_id = @BookId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@BookId", selectedBookId);  // Use book_id for deletion

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book deleted successfully!");

                    ClearTextBoxes();
                    LoadBooks();  // Refresh DataGridView after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEditB_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = textAuth.Text;
            string genre = txtGenre.Text;

            // Declare variables for yearPublished, totalCopies, and availableCopies
            int yearPublished = 0;
            int totalCopies = 0;
            int availableCopies = 0; // Add a variable for available copies

            // Validate the Year Published input
            if (!int.TryParse(txtYP.Text, out yearPublished))
            {
                MessageBox.Show("Please enter a valid number for 'Year Published'.");
                return;  // Exit the method if the input is invalid
            }

            // Validate the Total Copies input
            if (!int.TryParse(txtTotal.Text, out totalCopies))
            {
                MessageBox.Show("Please enter a valid number for 'Total Copies'.");
                return;  // Exit the method if the input is invalid
            }

            // Set available copies equal to total copies if needed
            availableCopies = totalCopies;

            
            string updateQuery = "UPDATE books SET author = @Author, genre = @Genre, published_year = @YearPublished, total_copies = @TotalCopies, available_copies = @AvailableCopies WHERE book_id = @BookId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@BookId", selectedBookId); // Use the stored book_id for updating
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@YearPublished", yearPublished);
                cmd.Parameters.AddWithValue("@TotalCopies", totalCopies);
                cmd.Parameters.AddWithValue("@AvailableCopies", availableCopies); // Add the available copies parameter

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book details updated successfully!");

                    ClearTextBoxes();
                    LoadBooks();  // Refresh DataGridView after update
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_2(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "View Available Books")
            {
                ViewAvailableBooks();
            }
            else if (comboBox1.SelectedItem.ToString() == "View Book Summary")
            {
                ViewBookSummary();
            }

        }

        private void PopulateReportTypeComboBox()
        {
            comboLoan.Items.Clear();
            comboLoan.Items.Add("All Loans");
            comboLoan.Items.Add("Overdue Loans");
            comboLoan.Items.Add("Returned Loans");
            comboLoan.SelectedIndex = 0;
        }


        private void btnBackBook_Click(object sender, EventArgs e)
        {
            gridViewBooks.DataSource = null;  // Removes any data source
            gridViewBooks.Columns.Clear();    // Clear columns
            gridViewBooks.Rows.Clear();

            LoadBooks();
        }

        private void btnDelM_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Please select a member to delete.");
                return;
            }

            string query = "DELETE FROM members WHERE member_id = @memberId";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@memberId", selectedMemberId); // Use selectedMemberId

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member deleted successfully!");

                    // Optionally refresh the DataGridView to remove the deleted member
                    LoadMembers();
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void txtNamemem_TextChanged(object sender, EventArgs e)
        {
            string fullName = txtNamemem.Text.Trim();
            string[] nameParts = fullName.Split(' '); // Assuming the full name is first and last name
            if (nameParts.Length < 2)
            {
                return; // Exit if the name doesn't have a first and last name
            }

            string firstName = nameParts[0];
            string lastName = nameParts[1];

            // Query the database based on the first and last name
            string query = "SELECT * FROM members WHERE first_name = @firstName AND last_name = @lastName";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                try
                {
                    // Open connection
                    connection.Open();

                    // Execute the query and fill the DataGridView with the results
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        gridViewMembers.DataSource = dt; // Bind results to DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close connection
                    connection.Close();
                }

            }
        }

        private void btnUpdateM_Click(object sender, EventArgs e)
        {
            string fullName = txtNamemem.Text.Trim();
            string[] nameParts = fullName.Split(' '); // Assuming the full name is first and last name
            if (nameParts.Length < 2) return;

            string firstName = nameParts[0];
            string lastName = nameParts[1];
            string email = txtMailmem.Text;
            string phone = txtPhonemem.Text;
            string address = txtAddmem.Text;

            string query = "UPDATE members SET first_name = @firstName, last_name = @lastName, email = @email, phone = @phone, address = @address WHERE member_id = @memberId";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@memberId", selectedMemberId); // Ensure selectedMemberId is set when selecting a member row.

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member details updated successfully!");

                    // Optionally refresh the DataGridView to show the updated member
                    LoadMembers();
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void txtYP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearmem_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            LoadMembers();
        }

        private void btnClearBook_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void comboBoxMemL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can handle the selection change logic here
            // For example, get the selected member and do something with it.
            string selectedMember = comboBoxMemL.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMember))
            {

            }
        }

        private void comboBoxStaffL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change logic
            string selectedStaff = comboBoxStaffL.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStaff))
            {

            }
        }

        private void comboloanBook_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedBookTitle = comboloanBook.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedBookTitle))
            {

            }
        }

        private void btnUpdateL_Click(object sender, EventArgs e)
        {
            // 1) Get the selected loan ID
            int rowIdx = gridViewLoans.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridViewLoans.Rows[rowIdx];
            int loanId = Convert.ToInt32(row.Cells["loan_id"].Value);

            // 2) Read new values from your UI
            string memberName = comboBoxMemL.Text;
            string staffName = comboBoxStaffL.Text;
            string bookTitle = comboloanBook.Text;
            string newStatus = comboloanStat.SelectedItem?.ToString()
                                 ?? row.Cells["status"].Value.ToString();
            DateTime? returnDate = newStatus == "returned"
                                    ? (DateTime?)DateTime.Today
                                    : null;

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 3) Pre-fetch the foreign-key IDs
                int memberId, staffId, bookId;
                using (var cmd = new MySqlCommand(
                    "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name)=@nm", conn))
                {
                    cmd.Parameters.AddWithValue("@nm", memberName);
                    memberId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (var cmd = new MySqlCommand(
                    "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name)=@ns", conn))
                {
                    cmd.Parameters.AddWithValue("@ns", staffName);
                    staffId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (var cmd = new MySqlCommand(
                    "SELECT book_id FROM books WHERE title = @bt", conn))
                {
                    cmd.Parameters.AddWithValue("@bt", bookTitle);
                    bookId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 4) Update only the loans table
                string sql = @"
            UPDATE loans
               SET member_id  = @MemberId,
                   staff_id   = @StaffId,
                   book_id    = @BookId,
                   status     = @Status"
                    + (newStatus == "returned"
                         ? ", return_date = @ReturnDate"
                         : "")
                    + @"
             WHERE loan_id   = @LoanId;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@StaffId", staffId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@LoanId", loanId);
                    if (newStatus == "returned")
                        cmd.Parameters.AddWithValue("@ReturnDate", returnDate.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            // 5) Refresh your grid and notify
            LoadLoans();
            MessageBox.Show("Loan details updated successfully.");
        }


        private void btnDeleteL_Click(object sender, EventArgs e)
        {
            // Check if a loan is selected
            if (selectedLoanId == 0)  // Similar to how member deletion checks `selectedMemberId`
            {
                MessageBox.Show("Please select a loan to delete.");
                return;
            }

            string deleteQuery = "DELETE FROM loans WHERE loan_id = @loanId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@loanId", selectedLoanId); // Use selectedLoanId, which should be set on row selection

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();  

                    // Check if rows were affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Loan deleted successfully!");

                        // Optionally refresh the DataGridView to remove the deleted loan
                        LoadLoans();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. The loan may not exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnClearL_Click(object sender, EventArgs e)
        {
            // Clear ComboBoxes
            comboBoxMemL.SelectedIndex = -1;  // Reset ComboBox selection
            comboBoxStaffL.SelectedIndex = -1;
            comboloanBook.SelectedIndex = -1;

            // Clear DatePickers
            dTPBorrow.Value = DateTime.Today;  // Reset to today's date (or default)

            // Reset loan ID (if needed)
            selectedLoanId = -1;

            // Optional: Refresh DataGridView to show unmodified data
            gridViewLoans.ClearSelection();  

        }

        private void gridViewLoans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridViewLoans.Rows.Count) return;

            // Get the selected row
            DataGridViewRow selectedRow = gridViewLoans.Rows[e.RowIndex];

            // Check if the row and cells are not null and update controls for the whole row
            if (selectedRow.Cells["member_name"].Value != DBNull.Value)
                comboBoxMemL.Text = selectedRow.Cells["member_name"].Value.ToString();
            else
                comboBoxMemL.Text = string.Empty;  

            if (selectedRow.Cells["staff_name"].Value != DBNull.Value)
                comboBoxStaffL.Text = selectedRow.Cells["staff_name"].Value.ToString();
            else
                comboBoxStaffL.Text = string.Empty;

            if (selectedRow.Cells["book_title"].Value != DBNull.Value)
                comboloanBook.Text = selectedRow.Cells["book_title"].Value.ToString();
            else
                comboloanBook.Text = string.Empty;

            // Handle Borrow Date and Due Date
            var borrowDateCell = selectedRow.Cells["borrow_date"];
            if (borrowDateCell.Value != DBNull.Value)
            {
                DateTime borrowDate = Convert.ToDateTime(borrowDateCell.Value);
                dTPBorrow.Value = borrowDate;
            }
            else
            {
                dTPBorrow.Value = DateTime.Today;  
            }

            // Retrieve the status value directly from the status column
            var statusValue = selectedRow.Cells["status"].Value?.ToString();

            

            // Handle loan_id
            if (selectedRow.Cells["loan_id"].Value != DBNull.Value)
                selectedLoanId = Convert.ToInt32(selectedRow.Cells["loan_id"].Value);
            else
                selectedLoanId = -1;  // Reset to an invalid loan_id if it's null

            // Debugging output to confirm loan_id
            Console.WriteLine("Selected Loan ID: " + selectedLoanId);

            // Optionally highlight the selected row
            selectedRow.Selected = true;
        }

        private void btnSaveL_Click(object sender, EventArgs e)
        {
            // 1) Read UI values
            string memberName = comboBoxMemL.Text;
            string staffName = comboBoxStaffL.Text;
            string bookTitle = comboloanBook.Text;
            DateTime borrowDate = dTPBorrow.Value;
            string status = "borrowed";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 2) Fetch each foreign-key ID up front
                    int memberId, staffId, bookId;
                    using (var cmd = new MySqlCommand(
                        "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name)=@nm", conn))
                    {
                        cmd.Parameters.AddWithValue("@nm", memberName);
                        memberId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (var cmd = new MySqlCommand(
                        "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name)=@ns", conn))
                    {
                        cmd.Parameters.AddWithValue("@ns", staffName);
                        staffId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (var cmd = new MySqlCommand(
                        "SELECT book_id FROM books WHERE title = @bt", conn))
                    {
                        cmd.Parameters.AddWithValue("@bt", bookTitle);
                        bookId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 3) Insert into loans WITHOUT subqueries on books
                    string insertSql = @"
                INSERT INTO loans
                  (member_id, staff_id, book_id, borrow_date, status)
                VALUES
                  (@MemberId, @StaffId, @BookId, @BorrowDate, @Status);";
                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.Parameters.AddWithValue("@BookId", bookId);
                        cmd.Parameters.AddWithValue("@BorrowDate", borrowDate);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.ExecuteNonQuery();
                    }
                }

               
                LoadLoans();
                MessageBox.Show("Loan saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label1_Click_5(object sender, EventArgs e)
        {

        }

        private void comboloanStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected status value from the ComboBox
            string selectedStatus = comboloanStat.SelectedItem?.ToString();
        }

        private void comboBoxMemR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedMember = comboBoxMemR.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMember))
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1) Get the selected reservation ID
            int rowIdx = gridViewReservation.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridViewReservation.Rows[rowIdx];
            int reservationId = Convert.ToInt32(row.Cells["reservation_id"].Value);

            // 2) Read new values from the UI
            string memberName = comboBoxMemR.Text;
            string staffName = comboBoxStaffR.Text;
            string bookTitle = comboreserBook.Text;
            string newStatus = comboreserStatus.SelectedItem?.ToString()
                                 ?? row.Cells["status"].Value.ToString();
            DateTime? reservationDate = dTPReserve.Value;

            // 3) Open connection and fetch the foreign-key IDs
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                int memberId, staffId, bookId;
                using (var cmd = new MySqlCommand(
                    "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name)=@nm", conn))
                {
                    cmd.Parameters.AddWithValue("@nm", memberName);
                    memberId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (var cmd = new MySqlCommand(
                    "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name)=@ns", conn))
                {
                    cmd.Parameters.AddWithValue("@ns", staffName);
                    staffId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (var cmd = new MySqlCommand(
                    "SELECT book_id FROM books WHERE title = @bt", conn))
                {
                    cmd.Parameters.AddWithValue("@bt", bookTitle);
                    bookId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 4) Update reservation table with new values
                string updateQuery = @"
            UPDATE reservation
            SET member_id = @MemberId,
                staff_id = @StaffId,
                book_id = @BookId,
                status = @Status,
                reservation_date = @ReservationDate
            WHERE reservation_id = @ReservationId;";

                using (var cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
                    cmd.Parameters.AddWithValue("@StaffId", staffId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@ReservationDate", reservationDate);
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd.ExecuteNonQuery();
                }
            }

           
            LoadReservations();
            MessageBox.Show("Reservation updated successfully.");
        }

        private void comboBoxStaffR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedStaff = comboBoxStaffR.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStaff))
            {

            }
        }

        private void btnSaveR_Click(object sender, EventArgs e)
        {
            // 1) Read UI values
            string memberName = comboBoxMemR.Text;
            string staffName = comboBoxStaffR.Text;
            string bookTitle = comboreserBook.Text;
            DateTime reservationDate = dTPReserve.Value;
            string status = comboreserStatus.Text; // Assuming status is selected in ComboBox

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 2) Fetch each foreign-key ID up front
                    int memberId, staffId, bookId;
                    using (var cmd = new MySqlCommand(
                        "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name)=@nm", conn))
                    {
                        cmd.Parameters.AddWithValue("@nm", memberName);
                        memberId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (var cmd = new MySqlCommand(
                        "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name)=@ns", conn))
                    {
                        cmd.Parameters.AddWithValue("@ns", staffName);
                        staffId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    using (var cmd = new MySqlCommand(
                        "SELECT book_id FROM books WHERE title = @bt", conn))
                    {
                        cmd.Parameters.AddWithValue("@bt", bookTitle);
                        bookId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 3) Insert into reservation
                    string insertSql = @"
            INSERT INTO reservation
                (member_id, staff_id, book_id, reservation_date, status)
            VALUES
                (@MemberId, @StaffId, @BookId, @ReservationDate, @Status);";
                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.Parameters.AddWithValue("@BookId", bookId);
                        cmd.Parameters.AddWithValue("@ReservationDate", reservationDate);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.ExecuteNonQuery();
                    }
                }

               
                LoadReservations(); 
                MessageBox.Show("Reservation saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            
            if (selectedReservationId == 0)  
            {
                MessageBox.Show("Please select a reservation to delete.");
                return;
            }

            
            string deleteQuery = "DELETE FROM reservation WHERE reservation_id = @reservationId";

            // 3) Execute the query to delete the reservation
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@reservationId", selectedReservationId);  

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();  

                    // Check if the delete was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Reservation deleted successfully!");

                        
                        LoadReservations();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. The reservation may not exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnClearR_Click(object sender, EventArgs e)
        {
           
            comboBoxMemR.SelectedIndex = -1;
            comboBoxStaffR.SelectedIndex = -1;
            comboreserBook.SelectedIndex = -1;
            comboreserStatus.SelectedIndex = -1;

            // 2) Clear DateTimePicker
            dTPReserve.Value = DateTime.Today;

            // 3) Reset reservation ID (if needed)
            selectedReservationId = 0;

          
            gridViewReservation.ClearSelection();
        }

        private void comboMemT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedMember = comboMemT.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMember))
            {
                // Perform necessary actions for the Reservation tab when a member is selected
                // e.g., load reservation details for the selected member
            }
        }

        private void comboBoxStaffT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedStaff = comboBoxStaffR.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStaff))
            {

            }
        }

        private void combotransac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedTransactionType = combotransac.SelectedItem?.ToString();

            // Check for null or empty selection
            if (!string.IsNullOrEmpty(selectedTransactionType))
            {
                // Set the amount based on the selected transaction type
                decimal amount = 0;

                switch (selectedTransactionType)
                {
                    case "Membership Fee":
                        amount = 100;  // Predefined amount for membership fee
                        break;

                    case "Fine":
                    case "Damage Book Fee":
                    case "Lost Book Fee":
                        // For these transaction types, prompt the user to enter the amount manually
                        txtAmount.Clear();  
                        txtAmount.Enabled = true;  
                        return;  
                }

                // Set the amount text box with the predefined amount for Membership Fee
                txtAmount.Text = amount.ToString();
                txtAmount.Enabled = false;  // Disable the amount field to prevent manual changes when the amount is predefined
            }
        }

        private void dTPReserve_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewTransaction.Rows.Count) return;

            // Get the selected row
            DataGridViewRow selectedRow = dataGridViewTransaction.Rows[e.RowIndex];

            // Populate controls with the values from the selected row
            if (selectedRow.Cells["member_name"].Value != DBNull.Value)
                comboMemT.Text = selectedRow.Cells["member_name"].Value.ToString();
            else
                comboMemT.Text = string.Empty;

            if (selectedRow.Cells["staff_name"].Value != DBNull.Value)
                comboBoxStaffT.Text = selectedRow.Cells["staff_name"].Value.ToString();
            else
                comboBoxStaffT.Text = string.Empty;

            if (selectedRow.Cells["transaction_type"].Value != DBNull.Value)
                combotransac.Text = selectedRow.Cells["transaction_type"].Value.ToString();
            else
                combotransac.Text = string.Empty;

            // Handle the amount field
            if (selectedRow.Cells["amount"].Value != DBNull.Value)
                txtAmount.Text = selectedRow.Cells["amount"].Value.ToString();
            else
                txtAmount.Text = string.Empty;

            // Handle transaction date
            var transactionDateCell = selectedRow.Cells["transaction_date"];
            if (transactionDateCell.Value != DBNull.Value)
            {
                DateTime transactionDate = Convert.ToDateTime(transactionDateCell.Value);
                dTPTransac.Value = transactionDate;   
            }
            else
            {
                dTPTransac.Value = DateTime.Now;
            }

            // Handle transaction_id (for updates or deletions)
            if (selectedRow.Cells["transaction_id"].Value != DBNull.Value)
                selectedTransactionId = Convert.ToInt32(selectedRow.Cells["transaction_id"].Value);
            else
                selectedTransactionId = 0;  // Reset to an invalid transaction_id if it's null
        }

        private void btnSaveT_Click(object sender, EventArgs e)
        {
           
            string memberName = comboMemT.Text;
            string staffName = comboBoxStaffT.Text;
            string transactionType = combotransac.Text;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Invalid amount format.");
                return;
            }
            DateTime transactionDate = dTPTransac.Value;  

           
            if (string.IsNullOrEmpty(memberName) || string.IsNullOrEmpty(staffName) ||
                string.IsNullOrEmpty(transactionType) || amount <= 0)
            {
                MessageBox.Show("Please fill in all fields and ensure the amount is valid.");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    
                    int memberId, staffId;

                   
                    using (var cmd = new MySqlCommand(
                        "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name) = @nm", conn))
                    {
                        cmd.Parameters.AddWithValue("@nm", memberName);
                        memberId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    
                    using (var cmd = new MySqlCommand(
                        "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name) = @ns", conn))
                    {
                        cmd.Parameters.AddWithValue("@ns", staffName);
                        staffId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                   
                    string insertSql = @"
                INSERT INTO transactions
                    (member_id, staff_id, transaction_type, amount, transaction_date)
                VALUES
                    (@MemberId, @StaffId, @TransactionType, @Amount, @TransactionDate);";

                    using (var cmd = new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        cmd.ExecuteNonQuery();
                    }
                }

                
                LoadTransactions();
                MessageBox.Show("Transaction saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdateT_Click(object sender, EventArgs e)
        {

            string memberName = comboMemT.Text;
            string staffName = comboBoxStaffT.Text;
            string transactionType = combotransac.Text;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Invalid amount format.");
                return;
            }
            DateTime transactionDate = dTPTransac.Value;  // Assuming DateTimePicker control is used for the date

           
            if (string.IsNullOrEmpty(memberName) || string.IsNullOrEmpty(staffName) ||
                string.IsNullOrEmpty(transactionType) || amount <= 0)
            {
                MessageBox.Show("Please fill in all fields and ensure the amount is valid.");
                return;
            }

            // 3) Get the transaction ID (assumed to be set when a row is selected)
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a transaction to update.");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                  
                    int memberId, staffId;

                    
                    using (var cmd = new MySqlCommand(
                        "SELECT member_id FROM members WHERE CONCAT(first_name,' ',last_name) = @nm", conn))
                    {
                        cmd.Parameters.AddWithValue("@nm", memberName);
                        memberId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    
                    using (var cmd = new MySqlCommand(
                        "SELECT staff_id FROM staff WHERE CONCAT(first_name,' ',last_name) = @ns", conn))
                    {
                        cmd.Parameters.AddWithValue("@ns", staffName);
                        staffId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string updateSql = @"
                UPDATE transactions
                SET 
                    member_id = @MemberId,
                    staff_id = @StaffId,
                    transaction_type = @TransactionType,
                    amount = @Amount,
                    transaction_date = @TransactionDate
                WHERE transaction_id = @TransactionId;";

                    using (var cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@StaffId", staffId);
                        cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        cmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);  // Use selected transaction ID for updating
                        cmd.ExecuteNonQuery();
                    }
                }

                
                LoadTransactions(); 
                MessageBox.Show("Transaction updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btdDeleteT_Click(object sender, EventArgs e)
        {
            // Ensure a valid transaction is selected
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return; 
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                   
                    string deleteSql = "DELETE FROM transactions WHERE transaction_id = @TransactionId;";

                    using (var cmd = new MySqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TransactionId", selectedTransactionId);
                        cmd.ExecuteNonQuery(); 
                    }
                }

                
                LoadTransactions(); 
                MessageBox.Show("Transaction deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting transaction: " + ex.Message);
            }
        }

        private void btnClearT_Click(object sender, EventArgs e)
        {
            // 1) Clear ComboBoxes
            comboMemT.SelectedIndex = -1;
            comboBoxStaffT.SelectedIndex = -1;
            combotransac.SelectedIndex = -1;
            txtAmount.Clear();

            // 2) Clear DateTimePicker
            dTPTransac.Value = DateTime.Now;

            // 3) Reset reservation ID (if needed)
            selectedTransactionId = 0;

            // 4) Optional: Refresh DataGridView to show unmodified data
            dataGridViewTransaction.ClearSelection();
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            string fullName = txtStaffName.Text.Trim();
            string[] nameParts = fullName.Split(' '); 
            if (nameParts.Length < 2)
            {
                return; 
            }

            string firstName = nameParts[0];
            string lastName = nameParts[1];

            
            string query = "SELECT * FROM staff WHERE first_name = @firstName AND last_name = @lastName";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                try
                {
                    
                    connection.Open();

                    // Execute the query and fill the DataGridView with the results
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        gridViewStaff.DataSource = dt; // Bind results to DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    
                    connection.Close();
                }
            }
        }

        private void txtMailmem_TextChanged(object sender, EventArgs e)
        {
            string email = txtMailmem.Text.Trim();
        }

        private void btnClearS_Click(object sender, EventArgs e)
        {
            ClearStaffForm();
            LoadStaff();
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedItem != null)
            {
                string selectedRole = comboBoxRole.SelectedItem.ToString();
                
            }
            else
            {
                // Handle the case where no item is selected
                string selectedRole = string.Empty; 
            }
        }

        private void txtAddmem_TextChanged(object sender, EventArgs e)
        {
            string phone = txtAddmem.Text.Trim();

        }

        private void btnSaveS_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes
            string fullName = txtStaffName.Text.Trim();
            string[] nameParts = fullName.Split(' ');  
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please enter both first and last names.");
                return;
            }
            string firstName = nameParts[0];
            string lastName = nameParts[1];
            string email = txtStaffEmail.Text.Trim();
            string phone = txtStaffPhone.Text.Trim();
            string role = comboBoxRole.SelectedItem.ToString(); 


            // SQL query to insert new staff
            string insertQuery = "INSERT INTO staff (first_name, last_name, email, phone, role) " +
                                 "VALUES (@FirstName, @LastName, @Email, @Phone, @Role)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Role", role);

                try
                {
                    connection.Open();  
                    cmd.ExecuteNonQuery();  

                    MessageBox.Show("Staff added successfully!");  

                    ClearStaffForm();  
                    LoadStaff();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  // Show error message if something goes wrong
                }
            }
        }

        private void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the textboxes
            string fullName = txtStaffName.Text.Trim();
            string[] nameParts = fullName.Split(' ');  // Split into first and last name
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please enter both first and last names.");
                return;
            }
            string firstName = nameParts[0];
            string lastName = nameParts[1];
            string email = txtStaffEmail.Text.Trim();
            string phone = txtStaffPhone.Text.Trim();
            string role = comboBoxRole.SelectedItem.ToString();

           
            string updateQuery = "UPDATE staff SET first_name = @FirstName, last_name = @LastName, email = @Email, phone = @Phone, role = @Role " +
                                 "WHERE staff_id = @StaffId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@StaffId", selectedStaffId); 

                try
                {
                    connection.Open();  
                    cmd.ExecuteNonQuery();  

                    MessageBox.Show("Staff details updated successfully!");  

                    
                    LoadStaff();
                    ClearStaffForm();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  
                }
                finally
                {
                    connection.Close();  
                }
            }
        }

        private void btnStaffDel_Click(object sender, EventArgs e)
        {
            
            if (selectedStaffId == 0)
            {
                MessageBox.Show("Please select a staff member to delete.");
                return;
            }

            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return; 
            }

          
            string deleteQuery = "DELETE FROM staff WHERE staff_id = @StaffId";

            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StaffId", selectedStaffId);  

                try
                {
                    connection.Open();  
                    cmd.ExecuteNonQuery();  
                    MessageBox.Show("Staff deleted successfully!");  

                    
                    LoadStaff();  
                    ClearStaffForm();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  
                }
                finally
                {
                    connection.Close();  
                }
            }
        }

        private void lbAvailnum_Click(object sender, EventArgs e)
        {

        }

        private void lbLoanednum_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable the button to prevent multiple clicks during refresh
                btnRefresh.Enabled = false;

               
                UpdateAvailableBooksLabel();
                UpdateTotalBooksLabel();
                UpdateLoanedBooksLabel();
                UpdateOverdueBooksLabel();
                UpdatePopularBookLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Re-enable the refresh button after the refresh process is complete
                btnRefresh.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void comboLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = comboLoan.SelectedItem.ToString();
            string query = "";

            if (selectedReport == "All Loans")
            {
                LoadLoans();
            }
            else if (selectedReport == "Overdue Loans")
            {
                query = "SELECT * FROM view_overdue_loans";
            }
            else if (selectedReport == "Returned Loans")
            {
                query = "SELECT * FROM loans WHERE status = 'returned'";
            }

            LoadReportData(query);
        }

        private void btnLoanEx_Click(object sender, EventArgs e)
        {
            ExportToExcel(gridViewLoans);
        }

        private void comboLoan_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string selected = comboLoan.SelectedItem.ToString();

            switch (selected)
            {
                case "All Loans":
                    LoadLoans(); 
                    break;
                case "Overdue Loans":
                    ViewOverdueLoans();
                    break;
                case "Returned Loans":
                    ViewReturnedLoans();
                    break;
            }
        }

        private void lbReviews_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchLoans_TextChanged(object sender, EventArgs e)
        {
            if (_loansTable == null) return;

            string filterText = txtSearchLoans.Text.Trim().Replace("'", "''"); 

            if (string.IsNullOrEmpty(filterText))
            {
                _loansTable.DefaultView.RowFilter = string.Empty; // clear filter
            }
            else
            {
                
                _loansTable.DefaultView.RowFilter =
                    $"member_name LIKE '%{filterText}%' OR book_title LIKE '%{filterText}%' OR staff_name LIKE '%{filterText}%' OR status LIKE '%{filterText}%'";
            }
        }
    }
}


