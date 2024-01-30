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
using System.Xml.Linq;

namespace Portal
{
    public partial class UpdateStudentForm : Form
    {
        private User studentToUpdate;
        public UpdateStudentForm(User student)
        {
            InitializeComponent();
            studentToUpdate = student;
            PopulateForm();
            label1.Text = $"Update Student {student.Name} {student.LastName}";
        }
        private void PopulateForm()
        {
            txtName.Text = studentToUpdate.Name;
            txtLastName.Text = studentToUpdate.LastName;
            txtEmail.Text = studentToUpdate.Email;
            txtPersonalId.Text = studentToUpdate.PersonalID;
            dtpBirthDate.Value = studentToUpdate.BirthDate;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            studentToUpdate.Name = txtName.Text;
            studentToUpdate.LastName = txtLastName.Text;
            studentToUpdate.Email = txtEmail.Text;
            studentToUpdate.PersonalID = txtPersonalId.Text;
            studentToUpdate.BirthDate = dtpBirthDate.Value;

            // Check if a new password is provided
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                // Update the password if a new one is provided
                studentToUpdate.PasswordHash = Methods.HashPassword(txtNewPassword.Text);
            }

            DatabaseHelper.Instance.UpdateStudent(studentToUpdate);

            // Close the form with DialogResult.OK to indicate changes were saved
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
