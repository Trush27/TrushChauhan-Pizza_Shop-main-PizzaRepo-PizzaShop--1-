using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModel;

public class ModifierGroupViewModel
{
    public int ModifierGroupId { get; set; }
    [Required(ErrorMessage = "Modifier group name is required")]
    [StringLength(50, ErrorMessage = "Modifier group name cannot exceed 50 characters")]
    public string ModifierGroupName { get; set; }
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Minimum selection is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Minimum selection must be a positive number")]
    public int MinSelect { get; set; }
    [Required(ErrorMessage = "Maximum selection is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Maximum selection must be a positive number")]
    public int MaxSelect { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public List<ModifierViewModel> Modifiers { get; set; } = new List<ModifierViewModel>();
} 