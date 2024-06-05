using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Student_Information_System
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            get_data();
        }
        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {

            homepage homepageForm = new homepage();
            homepageForm.Show();
            this.Hide();
        }

        private void pnlStudents_Click(object sender, EventArgs e)
        {

            Students studentsForm = new Students();
            studentsForm.Show();
            this.Hide();
        }

        private void pnlTeachers_Click(object sender, EventArgs e)
        {

            Teachers teachersForm = new Teachers();
            teachersForm.Show();
            this.Hide();
        }

        private void pnlClasses_Click(object sender, EventArgs e)
        {

            Classes classesForm = new Classes();
            classesForm.Show();
            this.Hide();
        }

        private void pnlCanteen_Click(object sender, EventArgs e)
        {

            Canteen canteenForm = new Canteen();
            canteenForm.Show();
            this.Hide();
        }

        private void get_data()
        {
            try
            {
                // Define your query
                string query = "SELECT TOP (1000) [User ID], [Username], [Password] FROM [SchoolDB].[dbo].[Users]";

                // Create a new DataTable to hold the query results
                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

                // Fill the DataTable with the results from the SQL query
                adapter.Fill(dataTable);


                // Bind the DataTable to the DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridViewUsers.Rows.Add(row["User ID"], row["Username"], row["Password"]);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnSaveUsers_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string username = txtUsernameUsers.Text;
            string password = txtPasswordUsers.Text;

            try
            {
                // Define the insert query
                string query = "INSERT INTO [SchoolDB].[dbo].[Users] (Username, Password) VALUES (@Username, @Password)";

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection if it is not already open
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Inform the user about the result
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!");

                        // Optionally, refresh the data in the DataGridView
                        dataGridViewUsers.Rows.Clear();
                        get_data();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the user.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void picDeleteUsers_Click(object sender, EventArgs e)
        {

            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                // Assuming the first column contains the User ID
                int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells[0].Value);

                try
                {
                    // Define the delete query
                    string query = "DELETE FROM [SchoolDB].[dbo].[Users] WHERE [User ID] = @UserID";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@UserID", userId);

                        // Open the connection if it is not already open
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Inform the user about the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully!");

                            // Optionally, refresh the data in the DataGridView
                            dataGridViewUsers.Rows.Clear();
                            get_data();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the user.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
    }
}
