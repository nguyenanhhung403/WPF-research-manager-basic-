using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ResearchProjectRepository : Repository<ResearchProject>, IResearchProjectRepository
    {
        public ResearchProjectRepository(Sp25researchDbContext context) : base(context)
        {
        }

        public async Task<List<ResearchProject>> GetAllProjectsWithLeadResearcherAsync()
        {
            return await _context.ResearchProjects
                .Include(p => p.LeadResearcher)
                .ToListAsync();
        }

        public async Task<ResearchProject> GetProjectWithLeadResearcherByIdAsync(int id)
        {
            return await _context.ResearchProjects
                .Include(p => p.LeadResearcher)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task<List<IGrouping<string, ResearchProject>>> SearchProjectsGroupedByFieldAsync(string searchTerm)
        {
            var query = _context.ResearchProjects
                .Include(p => p.LeadResearcher)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(p => 
                    p.ProjectTitle.ToLower().Contains(searchTerm) || 
                    p.ResearchField.ToLower().Contains(searchTerm));
            }

            var projects = await query.ToListAsync();
            return projects.GroupBy(p => p.ResearchField).ToList();
        }
    }

    public interface IResearchProjectRepository : IRepository<ResearchProject>
    {
        Task<List<ResearchProject>> GetAllProjectsWithLeadResearcherAsync();
        Task<ResearchProject> GetProjectWithLeadResearcherByIdAsync(int id);
        Task<List<IGrouping<string, ResearchProject>>> SearchProjectsGroupedByFieldAsync(string searchTerm);
    }
} 