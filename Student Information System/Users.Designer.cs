namespace Student_Information_System
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picQuit = new System.Windows.Forms.PictureBox();
            this.panelPagesSidebar = new System.Windows.Forms.Panel();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.pnlCanteen = new System.Windows.Forms.Panel();
            this.lblCanteen = new System.Windows.Forms.Label();
            this.pnlClasses = new System.Windows.Forms.Panel();
            this.lblClasses = new System.Windows.Forms.Label();
            this.pnlTeachers = new System.Windows.Forms.Panel();
            this.lblTeachers = new System.Windows.Forms.Label();
            this.pnlStudents = new System.Windows.Forms.Panel();
            this.lblStudents = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.txtUsernameUsers = new System.Windows.Forms.TextBox();
            this.txtPasswordUsers = new System.Windows.Forms.TextBox();
            this.btnSaveUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDeleteUsers = new System.Windows.Forms.PictureBox();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).BeginInit();
            this.panelPagesSidebar.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            this.pnlCanteen.SuspendLayout();
            this.pnlClasses.SuspendLayout();
            this.pnlTeachers.SuspendLayout();
            this.pnlStudents.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.pnlTopBar.Controls.Add(this.label1);
            this.pnlTopBar.Controls.Add(this.picQuit);
            this.pnlTopBar.Location = new System.Drawing.Point(-1, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1124, 53);
            this.pnlTopBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // picQuit
            // 
            this.picQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuit.Image = ((System.Drawing.Image)(resources.GetObject("picQuit.Image")));
            this.picQuit.Location = new System.Drawing.Point(1065, 0);
            this.picQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picQuit.Name = "picQuit";
            this.picQuit.Size = new System.Drawing.Size(57, 54);
            this.picQuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuit.TabIndex = 8;
            this.picQuit.TabStop = false;
            this.picQuit.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panelPagesSidebar
            // 
            this.panelPagesSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.panelPagesSidebar.Controls.Add(this.pnlUsers);
            this.panelPagesSidebar.Controls.Add(this.pnlCanteen);
            this.panelPagesSidebar.Controls.Add(this.pnlClasses);
            this.panelPagesSidebar.Controls.Add(this.pnlTeachers);
            this.panelPagesSidebar.Controls.Add(this.pnlStudents);
            this.panelPagesSidebar.Controls.Add(this.lblMenu);
            this.panelPagesSidebar.Controls.Add(this.pnlHome);
            this.panelPagesSidebar.Location = new System.Drawing.Point(0, 52);
            this.panelPagesSidebar.Name = "panelPagesSidebar";
            this.panelPagesSidebar.Size = new System.Drawing.Size(208, 598);
            this.panelPagesSidebar.TabIndex = 17;
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.White;
            this.pnlUsers.Controls.Add(this.lblUsers);
            this.pnlUsers.Location = new System.Drawing.Point(15, 407);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(184, 63);
            this.pnlUsers.TabIndex = 5;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsers.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblUsers.Location = new System.Drawing.Point(9, 17);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(83, 33);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "Users";
            // 
            // pnlCanteen
            // 
            this.pnlCanteen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.pnlCanteen.Controls.Add(this.lblCanteen);
            this.pnlCanteen.Location = new System.Drawing.Point(15, 301);
            this.pnlCanteen.Name = "pnlCanteen";
            this.pnlCanteen.Size = new System.Drawing.Size(184, 63);
            this.pnlCanteen.TabIndex = 4;
            // 
            // lblCanteen
            // 
            this.lblCanteen.AutoSize = true;
            this.lblCanteen.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCanteen.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblCanteen.Location = new System.Drawing.Point(9, 15);
            this.lblCanteen.Name = "lblCanteen";
            this.lblCanteen.Size = new System.Drawing.Size(119, 33);
            this.lblCanteen.TabIndex = 0;
            this.lblCanteen.Text = "Canteen";
            // 
            // pnlClasses
            // 
            this.pnlClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.pnlClasses.Controls.Add(this.lblClasses);
            this.pnlClasses.Location = new System.Drawing.Point(15, 232);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Size = new System.Drawing.Size(184, 63);
            this.pnlClasses.TabIndex = 3;
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClasses.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblClasses.Location = new System.Drawing.Point(9, 15);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(105, 33);
            this.lblClasses.TabIndex = 0;
            this.lblClasses.Text = "Classes";
            // 
            // pnlTeachers
            // 
            this.pnlTeachers.Controls.Add(this.lblTeachers);
            this.pnlTeachers.Location = new System.Drawing.Point(15, 163);
            this.pnlTeachers.Name = "pnlTeachers";
            this.pnlTeachers.Size = new System.Drawing.Size(184, 63);
            this.pnlTeachers.TabIndex = 2;
            // 
            // lblTeachers
            // 
            this.lblTeachers.AutoSize = true;
            this.lblTeachers.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTeachers.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTeachers.Location = new System.Drawing.Point(9, 15);
            this.lblTeachers.Name = "lblTeachers";
            this.lblTeachers.Size = new System.Drawing.Size(125, 33);
            this.lblTeachers.TabIndex = 0;
            this.lblTeachers.Text = "Teachers";
            // 
            // pnlStudents
            // 
            this.pnlStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.pnlStudents.Controls.Add(this.lblStudents);
            this.pnlStudents.Location = new System.Drawing.Point(15, 94);
            this.pnlStudents.Name = "pnlStudents";
            this.pnlStudents.Size = new System.Drawing.Size(184, 63);
            this.pnlStudents.TabIndex = 1;
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStudents.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblStudents.Location = new System.Drawing.Point(9, 15);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(125, 33);
            this.lblStudents.TabIndex = 0;
            this.lblStudents.Text = "Students";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Montserrat SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenu.Location = new System.Drawing.Point(27, 4);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(50, 18);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "MENU";
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.pnlHome.Controls.Add(this.lblHome);
            this.pnlHome.Location = new System.Drawing.Point(15, 25);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(184, 63);
            this.pnlHome.TabIndex = 0;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHome.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblHome.Location = new System.Drawing.Point(9, 14);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(89, 33);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Home";
            // 
            // txtUsernameUsers
            // 
            this.txtUsernameUsers.BackColor = System.Drawing.Color.White;
            this.txtUsernameUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsernameUsers.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUsernameUsers.ForeColor = System.Drawing.Color.Black;
            this.txtUsernameUsers.Location = new System.Drawing.Point(235, 96);
            this.txtUsernameUsers.MaximumSize = new System.Drawing.Size(312, 53);
            this.txtUsernameUsers.Name = "txtUsernameUsers";
            this.txtUsernameUsers.Size = new System.Drawing.Size(183, 44);
            this.txtUsernameUsers.TabIndex = 18;
            this.txtUsernameUsers.Text = "Username";
            // 
            // txtPasswordUsers
            // 
            this.txtPasswordUsers.BackColor = System.Drawing.Color.White;
            this.txtPasswordUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordUsers.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPasswordUsers.ForeColor = System.Drawing.Color.Black;
            this.txtPasswordUsers.Location = new System.Drawing.Point(424, 96);
            this.txtPasswordUsers.MaximumSize = new System.Drawing.Size(312, 53);
            this.txtPasswordUsers.Name = "txtPasswordUsers";
            this.txtPasswordUsers.Size = new System.Drawing.Size(183, 44);
            this.txtPasswordUsers.TabIndex = 19;
            this.txtPasswordUsers.Text = "Password";
            // 
            // btnSaveUsers
            // 
            this.btnSaveUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(72)))), ((int)(((byte)(192)))));
            this.btnSaveUsers.Font = new System.Drawing.Font("Montserrat Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaveUsers.ForeColor = System.Drawing.Color.White;
            this.btnSaveUsers.Location = new System.Drawing.Point(637, 97);
            this.btnSaveUsers.Name = "btnSaveUsers";
            this.btnSaveUsers.Size = new System.Drawing.Size(76, 43);
            this.btnSaveUsers.TabIndex = 20;
            this.btnSaveUsers.Text = "SAVE";
            this.btnSaveUsers.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.picDeleteUsers);
            this.panel1.Location = new System.Drawing.Point(719, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(42, 42);
            this.panel1.TabIndex = 21;
            // 
            // picDeleteUsers
            // 
            this.picDeleteUsers.Image = ((System.Drawing.Image)(resources.GetObject("picDeleteUsers.Image")));
            this.picDeleteUsers.Location = new System.Drawing.Point(0, 0);
            this.picDeleteUsers.Name = "picDeleteUsers";
            this.picDeleteUsers.Size = new System.Drawing.Size(40, 40);
            this.picDeleteUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeleteUsers.TabIndex = 22;
            this.picDeleteUsers.TabStop = false;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1122, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveUsers);
            this.Controls.Add(this.txtPasswordUsers);
            this.Controls.Add(this.txtUsernameUsers);
            this.Controls.Add(this.panelPagesSidebar);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).EndInit();
            this.panelPagesSidebar.ResumeLayout(false);
            this.panelPagesSidebar.PerformLayout();
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.pnlCanteen.ResumeLayout(false);
            this.pnlCanteen.PerformLayout();
            this.pnlClasses.ResumeLayout(false);
            this.pnlClasses.PerformLayout();
            this.pnlTeachers.ResumeLayout(false);
            this.pnlTeachers.PerformLayout();
            this.pnlStudents.ResumeLayout(false);
            this.pnlStudents.PerformLayout();
            this.pnlHome.ResumeLayout(false);
            this.pnlHome.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picQuit;
        private System.Windows.Forms.Panel panelPagesSidebar;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Panel pnlCanteen;
        private System.Windows.Forms.Label lblCanteen;
        private System.Windows.Forms.Panel pnlClasses;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.Panel pnlTeachers;
        private System.Windows.Forms.Label lblTeachers;
        private System.Windows.Forms.Panel pnlStudents;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.TextBox txtUsernameUsers;
        private System.Windows.Forms.TextBox txtPasswordUsers;
        private System.Windows.Forms.Button btnSaveUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picDeleteUsers;
    }
}