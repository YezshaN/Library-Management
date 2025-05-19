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
    public partial class Login : Form
    {
        string connectionString = "Server=localhost;Port=3306;Database=libmagementt;Uid=root;Pwd=yesh63780;";
        private MySqlConnection connection;

        public Login()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void SetUserRolePermissions(string role)
        {
            if (role == "Admin")
            {
                // Enable Admin permissions
            }
            else if (role == "Librarian")
            {
                // Enable Librarian permissions
            }
            else if (role == "Assistant")
            {
                // Enable Assistant permissions
            }
        }

        private void OpenUserManagerForm()
        {
            // Open the User Manager form for Admin users
            User userManagerForm = new User(); 
            userManagerForm.Show();
            this.Hide();
        }

        private void OpenDashboard()
        {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private bool IsTemporaryPassword(string password)
        {
            // Assume temporary passwords are alphanumeric and 8 characters long
            return password.Length == 8 && password.All(c => Char.IsLetterOrDigit(c));
        }



        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUN.Text;
            string password = txtPass.Text;

            try
            {
                connection.Open();

                // Updated query to include role, email, and temp_password flag
                string query = @"
            SELECT u.*, s.email, s.role, u.temp_password 
            FROM user u 
            JOIN staff s ON u.staff_id = s.staff_id 
            WHERE u.username = @username AND u.password = @password";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    string storedPassword = reader["password"].ToString();
                    string role = reader["role"].ToString();
                    string email = reader["email"].ToString();
                    bool isTemporaryPassword = Convert.ToBoolean(reader["temp_password"]);

                    SetUserRolePermissions(role);

                    MessageBox.Show(

                    isTemporaryPassword
                    ? "Logged in successfully with a temporary password. Please inform the Admin to change your password."
                    : "Logged in successfully!"
);

                    reader.Close(); 
                    connection.Close(); 

                    // Open appropriate form
                    if (role == "Admin")
                    {
                        OpenUserManagerForm(); // Admin user
                    }
                    else
                    {
                        OpenDashboard(); // Librarian or Assistant
                    }

                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    reader.Close();
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

        private void btnForgot_Click(object sender, EventArgs e)
        {
            Forgot_Password forgotPasswordForm = new Forgot_Password();
            forgotPasswordForm.Show();
            this.Hide();
        }

        private void txtUN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


    
