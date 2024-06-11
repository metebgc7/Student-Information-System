using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Student_Information_System
{
    public partial class loginpage : Form
    {
        public loginpage()
        {
            InitializeComponent();
        }
        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection 
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Define the query to check username and password
                string query = "SELECT COUNT(1) FROM [SchoolDB].[dbo].[Users] WHERE [Username] = @Username AND [Password] = @Password";

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);

                    // Execute the query and get the result
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        // Authentication successful, navigate to homepage
                        new SplashScreen().Show();
                        this.Hide();
                    }
                    else
                    {
                        // Authentication failed, show error message
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı, tekrar deneyiniz.");
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
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
                    connect.Close();
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        bool mouseDown;
        private Point offset;

        private void MouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if(mouseDown==true) 
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location=new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
