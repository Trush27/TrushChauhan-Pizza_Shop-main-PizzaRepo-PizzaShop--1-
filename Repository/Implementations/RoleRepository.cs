using Entity.Models;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> GetRoleById(int id)
    {
        Userrole user = await _context.Userroles
                .FirstOrDefaultAsync(u => u.Roleid == id);
        return user.Rolename;
    }
    public List<PermissionViewModel> GetPermissionsByRole(int roleId)
    {
        var role = _context.Userroles
        .Include(r => r.Roleandpermissions)
        .FirstOrDefault(r => r.Roleid == roleId && !r.Isdeleted);

        var rolePermissions = role.Roleandpermissions
            .ToDictionary(rp => rp.Permissionid);

        var permissions = _context.Userpermissions
            .Where(p => !p.Isdeleted)
            .AsEnumerable()
            .Select(p =>
            {
                rolePermissions.TryGetValue(p.Permissionid, out var rp);
                return new PermissionViewModel
                {
                    PermissionId = p.Permissionid,
                    PermissionName = p.Permissionname,
                    CanView = rp?.Canview ?? true,
                    CanAddEdit = rp?.Canaddedit ?? true,
                    CanDelete = rp?.Candelete ?? true
                };
            })
            .ToList();

        return permissions;
    }
    public void UpdatePermissions(int roleId, List<PermissionUpdateModel> permissions)
    {
        var existingPermissions = _context.Roleandpermissions
                .Where(rp => rp.Roleid == roleId)
                .ToList();

        foreach (var perm in permissions)
        {
            var existing = existingPermissions
                .FirstOrDefault(rp => rp.Permissionid == perm.PermissionId);

            if (existing != null)
            {
                existing.Canview = perm.CanView;
                existing.Canaddedit = perm.CanAddEdit;
                existing.Candelete = perm.CanDelete;
            }
        }

        _context.SaveChanges();

    }
}
