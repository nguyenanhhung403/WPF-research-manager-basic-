using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Enities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ResearchProjectService
    {
        private readonly IResearchProjectRepository _projectRepository;
        private readonly IResearcherRepository _researcherRepository;

        public ResearchProjectService(IResearchProjectRepository projectRepository, IResearcherRepository researcherRepository)
        {
            _projectRepository = projectRepository;
            _researcherRepository = researcherRepository;
        }

        public async Task<List<ResearchProject>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsWithLeadResearcherAsync();
        }

        public async Task<List<IGrouping<string, ResearchProject>>> GetProjectsBySearchTermGroupedAsync(string searchTerm)
        {
            return await _projectRepository.SearchProjectsGroupedByFieldAsync(searchTerm);
        }

        public async Task<ResearchProject> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectWithLeadResearcherByIdAsync(id);
        }

        public async Task<int> AddProjectAsync(ResearchProject project)
        {
            // Validation
            ValidateProject(project);

            // Generate a new ID (this is a simplification - in real applications, often the database does this)
            if (project.ProjectId == 0)
            {
                var projects = await _projectRepository.GetAllAsync();
                var maxId = projects.Count > 0 ? projects.Max(p => p.ProjectId) : 0;
                project.ProjectId = maxId + 1;
            }

            await _projectRepository.AddAsync(project);
            return await _projectRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateProjectAsync(ResearchProject project)
        {
            // Validation
            ValidateProject(project);

            _projectRepository.Update(project);
            return await _projectRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return 0;

            _projectRepository.Delete(project);
            return await _projectRepository.SaveChangesAsync();
        }

        public async Task<List<Researcher>> GetAllResearchersAsync()
        {
            return await _researcherRepository.GetAllResearchersAsync();
        }

        private void ValidateProject(ResearchProject project)
        {
            // Validate all required fields
            if (string.IsNullOrWhiteSpace(project.ProjectTitle))
                throw new ArgumentException("Project Title is required.");
            
            if (string.IsNullOrWhiteSpace(project.ResearchField))
                throw new ArgumentException("Research Field is required.");
            
            if (project.LeadResearcherId == null)
                throw new ArgumentException("Lead Researcher is required.");

            // Validate project title (5-100 chars, words start with capital letter or digit)
            if (project.ProjectTitle.Length < 5 || project.ProjectTitle.Length > 100)
                throw new ArgumentException("Project Title must be between 5 and 100 characters.");

            // Check if each word starts with a capital letter or digit
            string[] words = project.ProjectTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (word.Length > 0 && !(char.IsUpper(word[0]) || char.IsDigit(word[0])))
                    throw new ArgumentException("Each word in Project Title must start with a capital letter or digit.");
            }

            // Check for special characters
            if (Regex.IsMatch(project.ProjectTitle, @"[$%^@]"))
                throw new ArgumentException("Project Title cannot contain special characters such as $, %, ^, @.");

            // Validate dates
            if (project.StartDate >= project.EndDate)
                throw new ArgumentException("Start Date must be earlier than End Date.");
        }
    }
} 