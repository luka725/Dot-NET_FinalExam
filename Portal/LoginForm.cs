using Portal.Classes;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Portal
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string userEmail = emailTextBox.Text;
            string hashedPassword = Methods.HashPassword(passwordTextBox.Text);
            bool isAuthenticated = DatabaseHelper.Instance.AuthenticateUser(userEmail, hashedPassword);

            if (isAuthenticated)
            {
                // User is authenticated, get the user's role

                // Display the user's role or perform any other actions
                MessageBox.Show($"Login successful!");
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Login failed. Invalid email or password.");
            }
        }
    }
}
