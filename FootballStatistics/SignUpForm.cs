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
    public partial class SignUpForm : Form
    {
        UserDataAccess userDataAccess;
        public SignUpForm()
        {
            InitializeComponent();
            userDataAccess = new UserDataAccess();
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            //check so user not already exist with username
            //create new doc in db

            //check that there is text in txt fields

            if (usernametxt.Text == "" || passwordtxt.Text == "")
                MessageBox.Show("Username or Password is missing text");

            bool success = userDataAccess.AddUser(new UserModel{ Username = usernametxt.Text, Password = passwordtxt.Text});
            if(success)
            {
                usernametxt.Text = "";
                passwordtxt.Text = "";
            }
        }
    }
}
