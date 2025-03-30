using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using BLL.Services;
using DAL.Enities;

namespace ResearchProjectManagerment_SE180159.Views
{
    public partial class ProjectDialog : Window
    {
        private readonly ResearchProjectService _projectService;
        private ResearchProject _currentProject;
        private bool _isEditMode;

        public ProjectDialog(ResearchProjectService projectService, ResearchProject project = null)
        {
            InitializeComponent();
            _projectService = projectService;
            _currentProject = project;
            _isEditMode = project != null;

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load researchers for combobox
                await LoadResearchersAsync();

                // If in edit mode, populate form fields
                if (_isEditMode && _currentProject != null)
                {
                    txtProjectTitle.Text = _currentProject.ProjectTitle;
                    txtResearchField.Text = _currentProject.ResearchField;
                    dpStartDate.SelectedDate = _currentProject.StartDate.ToDateTime(TimeOnly.MinValue);
                    dpEndDate.SelectedDate = _currentProject.EndDate.ToDateTime(TimeOnly.MinValue);
                    txtBudget.Text = _currentProject.Budget.ToString(CultureInfo.InvariantCulture);

                    if (_currentProject.LeadResearcherId.HasValue)
                    {
                        cmbLeadResearcher.SelectedValue = _currentProject.LeadResearcherId.Value;
                    }
                }
                else
                {
                    // Set default dates for new project
                    dpStartDate.SelectedDate = DateTime.Today;
                    dpEndDate.SelectedDate = DateTime.Today.AddMonths(6);
                }
            }
            catch (Exception ex)
            {
                txtErrorMessage.Text = $"Error loading data: {ex.Message}";
            }
        }

        private async Task LoadResearchersAsync()
        {
            var researchers = await _projectService.GetAllResearchersAsync();
            cmbLeadResearcher.ItemsSource = researchers;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtErrorMessage.Text = string.Empty;

                // Validate and collect form data
                if (!ValidateForm())
                {
                    return;
                }

                // Create or update project
                var project = _isEditMode ? _currentProject : new ResearchProject();

                project.ProjectTitle = txtProjectTitle.Text.Trim();
                project.ResearchField = txtResearchField.Text.Trim();
                project.LeadResearcherId = (int)cmbLeadResearcher.SelectedValue;
                project.StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value);
                project.EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value);
                project.Budget = decimal.Parse(txtBudget.Text.Trim(), CultureInfo.InvariantCulture);

                // Save to database
                if (_isEditMode)
                {
                    await _projectService.UpdateProjectAsync(project);
                }
                else
                {
                    await _projectService.AddProjectAsync(project);
                }

                // Close dialog with success
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                txtErrorMessage.Text = $"Error saving project: {ex.Message}";
            }
        }

        private bool ValidateForm()
        {
            // Check required fields
            if (string.IsNullOrWhiteSpace(txtProjectTitle.Text))
            {
                txtErrorMessage.Text = "Project Title is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResearchField.Text))
            {
                txtErrorMessage.Text = "Research Field is required.";
                return false;
            }

            if (cmbLeadResearcher.SelectedItem == null)
            {
                txtErrorMessage.Text = "Lead Researcher is required.";
                return false;
            }

            if (dpStartDate.SelectedDate == null)
            {
                txtErrorMessage.Text = "Start Date is required.";
                return false;
            }

            if (dpEndDate.SelectedDate == null)
            {
                txtErrorMessage.Text = "End Date is required.";
                return false;
            }

            // Validate dates
            if (dpStartDate.SelectedDate >= dpEndDate.SelectedDate)
            {
                txtErrorMessage.Text = "Start Date must be earlier than End Date.";
                return false;
            }

            // Validate budget
            if (string.IsNullOrWhiteSpace(txtBudget.Text) || !decimal.TryParse(txtBudget.Text, out _))
            {
                txtErrorMessage.Text = "Budget must be a valid number.";
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 