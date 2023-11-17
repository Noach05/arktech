using ArkTech.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkTech;
using ArkTech.Enums;
using Microsoft.VisualBasic;
using ArkTech.Domains;

namespace ArkTechWindowsFormsApp
{
    public partial class UserManagementForm : Form
    {
        private IUserService userService;
        private List<User> users;
        private bool checkboxAdminIsVisible;
        User cUser;
        public UserManagementForm(IUserService userService, User user)
        {
            InitializeComponent();
            this.userService = userService;
            AddToListBox();
            cbSearchBy.DataSource = Enum.GetValues(typeof(UserSearchByEnum));
            this.cUser = user;
        }

        private async void AddToListBox()
        {
            lbUsers.Items.Clear();

            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbAddress.Clear();
            chbIsAdmin.Checked = false;
            tbSearch.Clear();

            lbUsers.Items.Add("Loading...");
            this.users = await userService.GetAllUsers();

            lbUsers.Items.Add("");
            lbUsers.Items.AddRange(users.ToArray());
            lbUsers.Items.RemoveAt(0);

            chbIsAdmin.Show();
            tbPassword.Show();
            checkboxAdminIsVisible = true;
        }

        private bool TextBoxValidation()
        {
            if (!string.IsNullOrWhiteSpace(tbFirstName.Text) && !string.IsNullOrWhiteSpace(tbLastName.Text) && !string.IsNullOrWhiteSpace(tbEmail.Text)
                && !string.IsNullOrWhiteSpace(tbPhone.Text) && !string.IsNullOrEmpty(tbAddress.Text))
            {
                return true;
            }
            else { return false; }
        }

        private bool EmailContainsEmail()
        {
            if (!tbEmail.Text.Contains("@gmail.com") && !tbEmail.Text.Contains("@email.com") && !tbEmail.Text.Contains("@hotmail.com")
                && !tbEmail.Text.Contains("@outlook.com") && !tbEmail.Text.Contains("@arktech.nl"))
            {
                return false;
            }
            else { return true; }
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            int isAdmin;
            if (chbIsAdmin.Checked && checkboxAdminIsVisible) 
            {
                isAdmin = 2; 
            } else if (!chbIsAdmin.Checked && checkboxAdminIsVisible) 
            {
                isAdmin = 1; 
            } else { isAdmin = 0; }
            var emailUnique = await userService.CheckEmailUniqueness(tbEmail.Text);
            if (!emailUnique.Success)
            {
                if (TextBoxValidation() && EmailContainsEmail() && tbPassword.Text.Length >= 8)
                {
                    var createdUser = await userService.CreateUser(new User(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhone.Text, tbAddress.Text, isAdmin, tbPassword.Text));
                    
                    MessageBox.Show(createdUser.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    AddToListBox();
                } else
                {
                    MessageBox.Show("Email or Password not valid, or not all required fields are filled in", "Unsuccessful Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show(emailUnique.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnAllUsers_Click(object sender, EventArgs e)
        {
            AddToListBox();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            this.users = await userService.SearchUser((UserSearchByEnum)cbSearchBy.SelectedValue, tbSearch.Text);
            lbUsers.Items.Clear();
            lbUsers.Items.AddRange(users.ToArray());
        }

        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int isAdmin;
            User? sUser = lbUsers.SelectedItem as User;

            if (sUser?.UID != cUser.UID)
            {
                if (chbIsAdmin.Checked && checkboxAdminIsVisible) 
                {
                    isAdmin = 2; 
                } else if (!chbIsAdmin.Checked && checkboxAdminIsVisible) 
                {
                    isAdmin = 1; 
                } else { isAdmin = 0; }
            } 
            
            else
            {
                isAdmin = cUser.AuthorisationLevel;
                MessageBox.Show("Cannot change authorisation level of currently logged in user", "Unsuccessful Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (TextBoxValidation() && EmailContainsEmail())
            {
                var userUpdated = await userService.UpdateUser(sUser, tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhone.Text, tbAddress.Text, isAdmin);
                MessageBox.Show(userUpdated.Message, "Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Email not valid, or not all required fields are filled in", "Unsuccessful Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User? sUser = lbUsers.SelectedItem as User;
            if (sUser != null)
            {
                tbFirstName.Text = sUser.FirstName;
                tbLastName.Text = sUser.LastName;
                tbEmail.Text = sUser.Email;
                tbPhone.Text = sUser.Phone;
                tbAddress.Text = sUser.Adress;
                tbPassword.Hide();
                if (sUser.AuthorisationLevel  == 2) { chbIsAdmin.Checked = true; chbIsAdmin.Show(); checkboxAdminIsVisible = true; }
                else if (sUser.AuthorisationLevel  == 1) { chbIsAdmin.Checked = false; chbIsAdmin.Show(); checkboxAdminIsVisible = true; }
                else { chbIsAdmin.Hide(); checkboxAdminIsVisible = false; }
            }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            User? sUser = lbUsers.SelectedItem as User;
            if (sUser?.UID != cUser.UID) 
            {
                string confirm = Interaction.InputBox("Are you sure you want to ban this user? Type Confirm to continue.", "Ban User", "");
                userService.DeactivateUser(sUser, confirm);
            }
            else { MessageBox.Show("Cannot ban currently logged in user", "Unsuccessful Operation", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
