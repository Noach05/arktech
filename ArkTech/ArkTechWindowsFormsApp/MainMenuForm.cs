using ArkTech.Domains;
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

namespace ArkTechWindowsFormsApp
{
    public partial class MainMenuForm : Form
    {
        private IUserService userService;
        private IProductService productService;
        private User cUser;
        public MainMenuForm(User user, IUserService userService, IProductService productService)
        {
            InitializeComponent();
            this.userService = userService;
            this.productService = productService;
            this.cUser = user;
            lbWelcomeBack.Text = String.Format($"Welcome back, {cUser.FirstName}");
        }

        private void btnProductRegistr_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            ProductRegistrationForm prForm = new ProductRegistrationForm(productService);
            prForm.TopLevel = false;
            prForm.AutoScroll = true;
            pnlMain.Controls.Add(prForm);
            prForm.Show();
        }

        private void btnUserMng_Click(object sender, EventArgs e)
        {
            if (cUser.AuthorisationLevel  == 2)
            {
                pnlMain.Controls.Clear();
                UserManagementForm umForm = new UserManagementForm(userService, cUser);
                umForm.TopLevel = false;
                umForm.AutoScroll = true;
                pnlMain.Controls.Add(umForm);
                umForm.Show();
            }
            else { MessageBox.Show("Authorisation requirements not met", "Not Authorised", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnProductMng_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is yet to be implemented", "Not Implemented Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDiscountMng_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is yet to be implemented", "Not Implemented Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is yet to be implemented", "Not Implemented Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is yet to be implemented", "Not Implemented Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
