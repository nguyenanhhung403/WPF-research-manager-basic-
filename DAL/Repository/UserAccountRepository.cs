using System.Threading.Tasks;
using DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(Sp25researchDbContext context) : base(context)
        {
        }

        public async Task<UserAccount> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
        }
    }

    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        Task<UserAccount> GetByEmailAndPasswordAsync(string email, string password);
    }
} 