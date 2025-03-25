using Entity.ViewModel;

namespace Service.Interfaces;

public interface IRolesAndPermissionsService
{
  List<PermissionViewModel>  GetPermissionsByRole(int roleId);
  void UpdatePermissions(int roleId, List<PermissionUpdateModel> permissions);
}
