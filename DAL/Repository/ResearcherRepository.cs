using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ResearcherRepository : Repository<Researcher>, IResearcherRepository
    {
        public ResearcherRepository(Sp25researchDbContext context) : base(context)
        {
        }

        public async Task<List<Researcher>> GetAllResearchersAsync()
        {
            return await _context.Researchers.ToListAsync();
        }
    }

    public interface IResearcherRepository : IRepository<Researcher>
    {
        Task<List<Researcher>> GetAllResearchersAsync();
    }
} 