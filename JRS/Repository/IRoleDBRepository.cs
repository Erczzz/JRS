using JRS.Models;

namespace JRS.Repository
{
    public interface IRoleDBRepository
    {
        Task<List<Role>> GetAllRoles();
        // Return Type -> Function Name -> Parameters
        Task<Role?> GetRoleById(int? RoleId);
        Task<Role?> AddRole(Role Role);
        Task<Role?> UpdateRole(int RoleId, Role Role);
        Task<Role?> DeleteRole(int RoleId);
    }
}
