using System;
using System.Windows;
using BLL.Services;
using DAL.Enities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResearchProjectManagerment_SE180159.Views;

namespace ResearchProjectManagerment_SE180159
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();

            if (Current.MainWindow != null && Current.MainWindow.GetType().Name != "LoginWindow")
            {
                Current.MainWindow.Close();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<Sp25researchDbContext>(options => 
            {
                // DbContext is configured in its own class
            });

            // Register repositories
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IResearcherRepository, ResearcherRepository>();
            services.AddScoped<IResearchProjectRepository, ResearchProjectRepository>();

            // Register services
            services.AddScoped<UserAccountService>();
            services.AddScoped<ResearchProjectService>();

            // Register views
            services.AddTransient<LoginWindow>();
            services.AddTransient<ResearchProjectWindow>();
        }
    }
}
