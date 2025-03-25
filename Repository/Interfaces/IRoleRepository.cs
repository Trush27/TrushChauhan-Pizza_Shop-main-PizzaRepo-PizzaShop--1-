using Entity.Models;
using Entity.ViewModel;

namespace Repository.Interfaces;

public interface IRoleRepository
{
    public Task<string> GetRoleById(int id);
    List<PermissionViewModel>  GetPermissionsByRole(int roleId);
    void UpdatePermissions(int roleId, List<PermissionUpdateModel> permissions);
}
