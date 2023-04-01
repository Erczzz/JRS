using JRS.Models;

namespace JRS.Repository
{
    public interface IUserDBRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int? UserId);
        Task<User?> AddUser(User User);
        Task<User?> UpdateUser(int UserId, User User);
        Task<User?> DeleteUser(int UserId);
        Task<List<Role>> FetchRoleList();
    }
}
