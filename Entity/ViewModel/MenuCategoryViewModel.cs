using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModel;

public class MenuCategoryViewModel
{
public int CategoryId { get; set; }
[Required(ErrorMessage = "Category name is required")]
[StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
public string CategoryName { get; set; }
[StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
public string? Description { get; set; }
public DateTime CreatedDate { get; set; }
public DateTime? ModifiedDate { get; set; }
public bool IsDeleted { get; set; }
// Optional: Include created/modified by user names if needed
public string? CreatedBy { get; set; }
public string? ModifiedBy { get; set; }
}
