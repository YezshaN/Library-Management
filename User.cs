using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LibraryManagement
{
    public partial class User : Form
    {
        string connectionString = "Server=localhost;Port=3306;Database=libmagementt;Uid=root;Pwd=yesh63780;";
        private MySqlConnection connection;

        public User()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void txtAddUN_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbUPmail_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelUs_Click(object sender, EventArgs e)
        {
            string username = txtDelUs.Text; // Username to be deleted

            // Check if the search field is empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username to search.");
                return;
            }

            try
            {
                connection.Open();

                // Step 1: Check if the user exists in the User Table
                string checkQuery = "SELECT COUNT(*) FROM user WHERE LOWER(username) = LOWER(@Username)";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Username", username);

                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount == 0)
                {
                    MessageBox.Show("User not found.");
                    return; // Exit if the user doesn't exist
                }

                // Step 2: Prompt for confirmation before deleting
                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    // Step 3: Delete the user from the User Table only
                    string deleteQuery = "DELETE FROM user WHERE username = @Username";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@Username", username);

                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("User deleted successfully.");
                    txtDelUs.Clear(); // Clear the search field after deletion
                }
                else
                {
                    MessageBox.Show("Delete operation cancelled.");
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

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void btnUseradd_Click(object sender, EventArgs e)
        {
            string username = txtAddUN.Text;
            string password = txtAddpass.Text;
            string staffIdText = txtAddID.Text; // TextBox for staff_id

            // Validate if fields are filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(staffIdText))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Validate that staff_id is a valid number
            if (!int.TryParse(staffIdText, out int staffId))
            {
                MessageBox.Show("Please enter a valid staff ID.");
                return;
            }

            try
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM user WHERE staff_id = @StaffId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@StaffId", staffId);

                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("This staff member is already assigned as a user. Please check the staff ID.");
                    return; // Exit the function if the user already exists
                }

                // Step 1: Insert the user credentials into the User Table using the manually entered staff_id
                string query = "INSERT INTO user (staff_id, username, password) VALUES (@StaffId, @Username, @Password)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery(); // Execute the query to add user

                MessageBox.Show("User added successfully.");

                txtAddUN.Clear();
                txtAddpass.Clear();
                txtAddID.Clear();

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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtSearch.Text;

            // Ensure the search field is filled
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username to search.");
                return;
            }

            try
            {
                connection.Open();

                // Step 1: Search for the user by username
                string searchQuery = "SELECT u.username, s.email, u.password FROM user u " +
                                     "JOIN staff s ON u.staff_id = s.staff_id WHERE u.username = @Username";
                MySqlCommand cmd = new MySqlCommand(searchQuery, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    txtUDname.Text = reader["username"].ToString();
                    txtUDmail.Text = reader["email"].ToString(); // Populating the email from the Staff Table
                    txtUDpass.Text = reader["password"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }

                reader.Close();
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

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUDname.Text;
            string password = txtUDpass.Text;
            string email = txtUDmail.Text;

            // Check if the fields are filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                connection.Open();

                // Step 2: Update the user information (username, email, password) in the User Table
                string updateQuery = "UPDATE user u JOIN staff s ON u.staff_id = s.staff_id " +
                                     "SET u.username = @Username, u.password = @Password, s.email = @Email " +
                                     "WHERE u.username = @Username";
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("Error updating the user profile.");
                }

                // Clear the textboxes after updating the profile
                txtUDname.Clear();
                txtUDmail.Clear();
                txtUDpass.Clear();
                txtSearch.Clear(); // Optionally clear the search field

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUDname.Text;
            string password = txtUDpass.Text;
            string email = txtUDmail.Text;

            // Check if the fields are filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                connection.Open();

                // Step 1: Update the user information (username, email, password) in the User Table
                string updateQuery = "UPDATE user u JOIN staff s ON u.staff_id = s.staff_id " +
                                     "SET u.username = @Username, u.password = @Password, s.email = @Email " +
                                     "WHERE u.username = @Username";
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("Error updating the user profile.");
                }

                // Clear the textboxes after updating the profile
                txtUDname.Clear();
                txtUDmail.Clear();
                txtUDpass.Clear();
                txtSearch.Clear(); // Optionally clear the search field

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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            string username = txtUDname.Text; // This will still get the username, but it's not editable
            string password = txtUDpass.Text;
            string email = txtUDmail.Text;

            // Check if the fields are filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                connection.Open();

                // Step 1: Check if the user exists in the User Table before updating
                string checkQuery = "SELECT COUNT(*) FROM user WHERE LOWER(username) = LOWER(@Username)";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Username", username); // We will use the old username to update
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount == 0)
                {
                    MessageBox.Show("User not found.");
                    return; // Exit if the user doesn't exist
                }

                // Step 2: Update the user information (username, email, password) in the User Table
                string updateQuery = "UPDATE user u JOIN staff s ON u.staff_id = s.staff_id " +
                     "SET u.password = @Password, u.temp_password = 0, s.email = @Email " +
                     "WHERE u.username = @OldUsername";  // Using old username to find the correct user
                MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@OldUsername", txtSearch.Text); // Old username for identification

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes made or error occurred.");
                }

                // Clear the textboxes after updating the profile
                txtUDname.Clear(); // This will be cleared even though it's disabled
                txtUDmail.Clear();
                txtUDpass.Clear();
                txtSearch.Clear(); // Optionally clear the search field

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

        private void btnLogoutUser_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtAddpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

