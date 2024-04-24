using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballStatistics
{
    public partial class LogInForm : Form
    {
        UserDataAccess userDataAccess;
        public LogInForm()
        {
            InitializeComponent();
            userDataAccess = new UserDataAccess();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //check if username & password matches any doc
            //save user details - stay logged in
            string userID = userDataAccess.AuthenticateUser(usernametxt.Text, passwordtxt.Text);
            if (userID == "")
            {
                MessageBox.Show("Username or Password is incorrect or user does not exist");
            }
            else
                MessageBox.Show("Log in successful");
            //save userId somewhere somehow
        }

        private void passwprdlbl_Click(object sender, EventArgs e)
        {

        }

        private void usernamelbl_Click(object sender, EventArgs e)
        {

        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
