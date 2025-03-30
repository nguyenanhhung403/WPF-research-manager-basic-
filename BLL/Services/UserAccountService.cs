using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Enities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<(UserAccount User, string ErrorMessage)> AuthenticateAsync(string email, string password)
        {
            var user = await _userAccountRepository.GetByEmailAndPasswordAsync(email, password);
            
            // Nếu không tìm thấy tài khoản
            if (user == null)
            {
                return (null, "Invalid email or password. Please try again.");
            }
            
            // Kiểm tra role
            if (user.Role == 1 || user.Role == 4) // Administrator hoặc Member
            {
                return (null, "You have no permission to access this function!");
            }
            
            // Nếu là Manager (role=2) hoặc Staff (role=3)
            return (user, null);
        }

        public bool HasPermissionToAccess(int? role, bool isWriteOperation)
        {
            if (role == null) return false;

            // Administrator = 1; Manager = 2; Staff = 3; Member = 4
            if (isWriteOperation) // For Create, Update, Delete operations
            {
                return role == 2; // Chỉ Manager có quyền thêm/sửa/xóa
            }
            else // For Read operations
            {
                return role == 2 || role == 3; // Manager hoặc Staff có quyền xem
            }
        }
    }
} 