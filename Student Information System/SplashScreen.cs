using System;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class SplashScreen : Form
    {
        private Timer timer;

        public SplashScreen()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 3500; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            OpenHomePage();
        }

        private void OpenHomePage()
        {
            homepage homepage = new homepage();
            homepage.Show();
            this.Close(); 
        }
    }
}