using JRS.Models;
using JRS.Repository;
using Microsoft.EntityFrameworkCore;
using JRS.Data;
using JRS.Models;

namespace JRS.Repository.MSSQL
{
    public class UserDBRepository : IUserDBRepository
    {
        private readonly JRSDBContext _JRSDbContext;

        public UserDBRepository(JRSDBContext JRSDBContext)
        {
            _JRSDbContext = JRSDBContext;
        }
        public async Task<User?> AddUser(User User)
        {
            await _JRSDbContext.Users.AddAsync(User);
            await _JRSDbContext.SaveChangesAsync();

            return User;
        }

        public async Task<User?> DeleteUser(int UserId)
        {
            var oldUser = await GetUserById(UserId);
            if (oldUser != null)
            {
                _JRSDbContext.Users.Remove(oldUser);
                await _JRSDbContext.SaveChangesAsync();
                return oldUser;
            }
            return null;
        }

        public async Task<List<Role>> FetchRoleList()
        {
            return await _JRSDbContext.Roles.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {

            return await _JRSDbContext.Users.Include(x => x.Role).ToListAsync();
        }

        public async Task<User?> GetUserById(int? UserId)
        {
            return await _JRSDbContext.Users
            .AsNoTracking()
            .Include(e => e.Role)
            .SingleOrDefaultAsync(x => x.UserId == UserId);
        }

        public async Task<User?> UpdateUser(int UserId, User User)
        {
            _JRSDbContext.Users.Update(User);
            await _JRSDbContext.SaveChangesAsync();
            return User;
        }
    }
}
