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
            UserAuthenticationResult authenticationResult = DatabaseHelper.Instance.AuthenticateUser(userEmail, hashedPassword);

            if (authenticationResult.IsAuthenticated)
            {
                string firstName = authenticationResult.FirstName;
                string lastName = authenticationResult.LastName;
                string role = authenticationResult.Role;
                MessageBox.Show($"Login successful for {role} {firstName} {lastName}!");
                if(role == "Student")
                {
                    Hide();
                    StudentForm studentForm = new StudentForm(authenticationResult);
                    studentForm.Show();
                }
                else if (role == "Lecturer")
                {
                    Hide();
                    LecturerForm lecturerForm = new LecturerForm(authenticationResult);
                    lecturerForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid user role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Login failed. Invalid email or password.");
            }
        }
    }
}
