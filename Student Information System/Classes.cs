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
    public partial class Classes : Form
    {
        public Classes()
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

        private void pnlCanteen_Click(object sender, EventArgs e)
        {
            
            Canteen canteenForm = new Canteen();
            canteenForm.Show();
            this.Hide();
        }

        private void pnlUsers_Click(object sender, EventArgs e)
        {
            
            Users usersForm = new Users();
            usersForm.Show();
            this.Hide();
        }

        private void picAddClasses_Click(object sender, EventArgs e)
        {
            Add addForm = new Add("Classes");
            addForm.Show();
        }
        private void get_data()
        {
            try
            {
                // Define your query
                string query = "SELECT * FROM [SchoolDB].[dbo].[Class]";

                // Create a new DataTable to hold the query results
                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

                // Fill the DataTable with the results from the SQL query
                adapter.Fill(dataTable);


                // Bind the DataTable to the DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridViewClasses.Rows.Add(row["ClassID"], row["className"]);
                }

            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void picDeleteClasses_Click(object sender, EventArgs e)
        {
            if (dataGridViewClasses.SelectedRows.Count > 0)
            {
                // Assuming the first column contains the Class ID
                int classId = Convert.ToInt32(dataGridViewClasses.SelectedRows[0].Cells[0].Value);

                try
                {
                    // Define the delete query
                    string query = "DELETE FROM [SchoolDB].[dbo].[Class] WHERE [ClassID] = @ClassID";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@ClassID", classId);

                        // Open the connection if it is not already open
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                        }

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Inform the class about the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Class deleted successfully!");

                            // Optionally, refresh the data in the DataGridView
                            dataGridViewClasses.Rows.Clear();
                            get_data();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the class.");
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
                MessageBox.Show("Please select a class to delete.");
            }
        }
    }
}
