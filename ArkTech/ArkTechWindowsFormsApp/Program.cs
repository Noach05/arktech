using ArkTech.Domains;
using ArkTech.Services;
using ArkTechDAL.Repositories;

namespace ArkTechWindowsFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(
                new LoginForm(
                    new LoginService(
                        new UserRepository()
                        ),
                    new UserService(
                        new UserRepository()
                        ),
                    new ProductService(
                        new ProductRepository()
                        )

                    )
                );
        }
    }
}