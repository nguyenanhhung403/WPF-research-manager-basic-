using System;
using System.Windows;
using BLL.Services;
using DAL.Enities;
using Microsoft.Extensions.DependencyInjection;

namespace ResearchProjectManagerment_SE180159.Views
{
    public partial class LoginWindow : Window
    {
        private readonly UserAccountService _userAccountService;

        public UserAccount LoggedInUser { get; private set; }

        public LoginWindow(UserAccountService userAccountService)
        {
            InitializeComponent();
            _userAccountService = userAccountService;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Password.Trim();

                // Validate inputs
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    txtErrorMessage.Text = "Please enter both email and password.";
                    return;
                }

                // Kiểm tra tài khoản nhập vào
                var (user, errorMessage) = await _userAccountService.AuthenticateAsync(email, password);
                
                // Nếu có lỗi
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    txtErrorMessage.Text = errorMessage;
                    return;
                }
                
                // Tài khoản đã đúng
                LoggedInUser = user;

                // Open Research Project Management window
                var researchProjectWindow = App.ServiceProvider.GetRequiredService<ResearchProjectWindow>();
                researchProjectWindow.CurrentUser = LoggedInUser;
                
                // Show the Research Project window
                researchProjectWindow.Show();
                
                // Close login window
                this.Close();
            }
            catch (Exception ex)
            {
                txtErrorMessage.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
} 