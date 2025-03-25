using Entity.ViewModel;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations;

public class RolesAndPermissionsService : IRolesAndPermissionsService
{
    private readonly IRoleRepository _roleRepo;
    public RolesAndPermissionsService(IRoleRepository roleRepo)
    {
        _roleRepo = roleRepo;
    }
    public List<PermissionViewModel>  GetPermissionsByRole(int roleId){
        return _roleRepo.GetPermissionsByRole(roleId);
    }
    public void UpdatePermissions(int roleId, List<PermissionUpdateModel> permissions){
        _roleRepo.UpdatePermissions(roleId,permissions);
    }
}
