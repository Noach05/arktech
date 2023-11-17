using ArkTech.Domains;
using ArkTech.Interfaces;
using System.Security.Cryptography;

namespace ArkTechWindowsFormsApp
{
    public partial class LoginForm : Form
    {
        private Form mainMenu;
        private ILoginService login;
        private IUserService userService;
        private IProductService productService;
        private User cUser;
        public LoginForm(ILoginService login, IUserService userService, IProductService productService)
        {
            InitializeComponent();
            this.userService = userService;
            this.productService = productService;
            this.login = login;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            cUser = await login.VerifyUserDesktopApp(tbUsername.Text, tbPassword.Text);
            if (cUser != null)
            {
                this.mainMenu = new MainMenuForm(cUser, userService, productService);
                mainMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Username or Password Incorrect", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}