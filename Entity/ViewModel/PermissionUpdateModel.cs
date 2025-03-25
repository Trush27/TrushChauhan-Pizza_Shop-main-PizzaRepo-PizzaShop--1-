namespace Entity.ViewModel;

public class PermissionUpdateModel
{
    public int PermissionId { get; set; }
    public bool CanView { get; set; }
    public bool CanAddEdit { get; set; }
    public bool CanDelete { get; set; }
}
