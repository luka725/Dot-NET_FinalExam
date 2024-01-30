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
    public partial class UpdateUserForm : Form
    {
        private User userToUpdate;
        public UpdateUserForm(User user)
        {
            InitializeComponent();
            userToUpdate = user;
            PopulateForm();
            label1.Text = $"Update User {user.Name} {user.LastName}";
        }
        private void PopulateForm()
        {
            txtName.Text = userToUpdate.Name;
            txtLastName.Text = userToUpdate.LastName;
            txtEmail.Text = userToUpdate.Email;
            txtPersonalId.Text = userToUpdate.PersonalID;
            dtpBirthDate.Value = userToUpdate.BirthDate;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            userToUpdate.Name = txtName.Text;
            userToUpdate.LastName = txtLastName.Text;
            userToUpdate.Email = txtEmail.Text;
            userToUpdate.PersonalID = txtPersonalId.Text;
            userToUpdate.BirthDate = dtpBirthDate.Value;

            // Check if a new password is provided
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                // Update the password if a new one is provided
                userToUpdate.PasswordHash = Methods.HashPassword(txtNewPassword.Text);
            }

            DatabaseHelper.Instance.UpdateStudent(userToUpdate);

            // Close the form with DialogResult.OK to indicate changes were saved
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
