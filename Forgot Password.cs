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
    public partial class Forgot_Password : Form
    {
        private MySqlConnection connection;
        string connectionString = "Server=localhost;Port=3306;Database=libmagementt;Uid=root;Pwd=yesh63780;";

        public Forgot_Password()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);

        }

        private string GenerateTemporaryPassword()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, 8).Select(_ => chars[rand.Next(chars.Length)]).ToArray());
        }

        private void Forgot_Password_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnbcklogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void txtunForgot_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGen_Click(object sender, EventArgs e)
        {

            string username = txtunForgot.Text;
            MySqlDataReader reader = null;

            try
            {
                connection.Open();

                // Check if the user exists
                string query = "SELECT * FROM user WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read(); // Move to the first row
                    string tempPassword = GenerateTemporaryPassword();

                    // Close the reader before executing the UPDATE query
                    reader.Close();

                    // Now, update the user with the new temporary password
                    string updateQuery = "UPDATE user SET password = @password, temp_password = 1 WHERE username = @username";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@password", tempPassword);
                    updateCmd.Parameters.AddWithValue("@username", username);

                    updateCmd.ExecuteNonQuery(); // Execute the update query

                    MessageBox.Show($"Your temporary password is: {tempPassword}. Please notify the Admin to change your password."); 
                }
                else
                {
                    MessageBox.Show("Username not found. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure that the connection is closed in the finally block
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();
            }

        }

    }

}
