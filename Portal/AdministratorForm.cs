using Bogus.DataSets;
using Portal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
    public partial class AdministratorForm : Form
    {
        public UserAuthenticationResult data;
        private const string UserEntityType = "User";
        private const string SubjectEntityType = "Subject";
        private const string EnrollmentEntityType = "Enrollment";
        public AdministratorForm(UserAuthenticationResult data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void AdministratorForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Welcome {data.FirstName} {data.LastName}";
            cmbEntityType.Items.AddRange(new string[] { "User", "Subject", "Enrollment" });

            // Set the default selection
            cmbEntityType.SelectedIndex = 0; // Select "Student" by default

            // Event handler for ComboBox selection change
            cmbEntityType.SelectedIndexChanged += cmbEntityType_SelectedIndexChanged;
        }

        private void AdministratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cmbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEntityType = cmbEntityType.SelectedItem.ToString();

            switch (selectedEntityType)
            {
                case "User":
                    break;
                case "Subject":
                    break;
                case "Enrollment":
                    break;
                default:
                    break;
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            string selectedEntityType = cmbEntityType.SelectedItem.ToString();

            // Open the corresponding form based on the selected entity type
            switch (selectedEntityType)
            {
                case UserEntityType:
                    OpenStudentForm();
                    break;
                case EnrollmentEntityType:
                    OpenEnrollmentForm();
                    break;
                case SubjectEntityType:
                    OpenSubjectForm();
                    break;
                default:
                    break;
            }
        }
        private void OpenStudentForm()
        {
            AdminUsersForm studentForm = new AdminUsersForm();
            studentForm.Show();
        }
        private void OpenEnrollmentForm() 
        { 
            AdminEnrollmentsForm enrollmentsForm = new AdminEnrollmentsForm();
            enrollmentsForm.Show();
        }
        private void OpenSubjectForm()
        {
           AdminSubjectsForm subjectForm = new AdminSubjectsForm();
           subjectForm.Show();
        }
    }
}
