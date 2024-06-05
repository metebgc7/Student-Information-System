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
    public partial class Add : Form
    {


        static string ConnString = "Data Source=METEHAN\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(ConnString);

        public Add(string _initial_tabview)
        {
            InitializeComponent();
            open_tabview(_initial_tabview);
        }

        private void open_tabview(string _tabview)
        {
            foreach (TabPage tab in tabControlAdd.TabPages)
            {
                if (tab.Text == _tabview)
                {
                    tabControlAdd.SelectedTab = tab;
                    return;
                }
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
