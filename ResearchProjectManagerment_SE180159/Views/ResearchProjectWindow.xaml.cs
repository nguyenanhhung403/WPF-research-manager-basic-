using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BLL.Services;
using DAL.Enities;
using Microsoft.Extensions.DependencyInjection;

namespace ResearchProjectManagerment_SE180159.Views
{
    public partial class ResearchProjectWindow : Window
    {
        private readonly ResearchProjectService _projectService;
        private readonly UserAccountService _userAccountService;
        private ICollectionView _projectsView;
        
        public UserAccount CurrentUser { get; set; }

        public ResearchProjectWindow(ResearchProjectService projectService, UserAccountService userAccountService)
        {
            InitializeComponent();
            _projectService = projectService;
            _userAccountService = userAccountService;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set user info
                //if (CurrentUser != null)
                //{
                //    string roleName = GetRoleName(CurrentUser.Role);
                //    txtUserInfo.Text = $"User: {CurrentUser.Email} | Role: {roleName}";

                //    // Enable/disable buttons based on role
                //    bool canWrite = _userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: true);
                //    btnAdd.IsEnabled = canWrite;
                //    btnEdit.IsEnabled = canWrite;
                //    btnDelete.IsEnabled = canWrite;
                //}

                // Load projects
                await LoadProjectsAsync();
            } catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetRoleName(int? role)
        {
            return role switch
            {
                1 => "Administrator",
                2 => "Manager",
                3 => "Staff",
                4 => "Member",
                _ => "Unknown"
            };
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                
                // Check if user has permission
                if (!_userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: false))
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    // If search term is empty, reset the filter
                    _projectsView.Filter = null;
                }
                else
                {
                    // Apply filter based on search term (case-insensitive)
                    _projectsView.Filter = item =>
                    {
                        if (item is ResearchProject project)
                        {
                            return 
                                project.ProjectTitle.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 || 
                                project.ResearchField.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                (project.LeadResearcher?.FullName?.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
                        }
                        return false;
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching projects: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        //{
        //    await LoadProjectsAsync();
        //}

        private async System.Threading.Tasks.Task LoadProjectsAsync()
        {
            try
            {
                // Check if user has permission
                if (!_userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: false))
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                // Get all projects
                var projects = await _projectService.GetAllProjectsAsync();
                
                // Create a view for the collection
                _projectsView = CollectionViewSource.GetDefaultView(projects);
                
                // Set DataGrid's ItemsSource
                dgProjects.ItemsSource = _projectsView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if user has permission
                if (!_userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: true))
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                // Open project dialog
                var projectDialog = new ProjectDialog(_projectService);
                projectDialog.Owner = this;
                
                if (projectDialog.ShowDialog() == true)
                {
                    // Refresh project list
                    LoadProjectsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding project: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if user has permission
                if (!_userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: true))
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                // Get selected project
                var selectedProject = dgProjects.SelectedItem as ResearchProject;
                if (selectedProject == null)
                {
                    MessageBox.Show("Please select a project to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                
                // Open project dialog with selected project
                //var projectDialog = new ProjectDialog(_projectService, selectedProject);
                //projectDialog.Owner = this;
                
                //if (projectDialog.ShowDialog() == true)
                //{
                //    // Refresh project list
                //    LoadProjectsAsync();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing project: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if user has permission
                if (!_userAccountService.HasPermissionToAccess(CurrentUser.Role, isWriteOperation: true))
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                // Get selected project
                var selectedProject = dgProjects.SelectedItem as ResearchProject;
                if (selectedProject == null)
                {
                    MessageBox.Show("Please select a project to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                
                // Confirm deletion
                var result = MessageBox.Show($"Are you sure you want to delete project '{selectedProject.ProjectTitle}'?", 
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    // Delete project
                    await _projectService.DeleteProjectAsync(selectedProject.ProjectId);
                    
                    // Refresh project list
                    await LoadProjectsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting project: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 