using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModel;

public class MenuItemViewModel
{
public int ItemId { get; set; }
[Required(ErrorMessage = "Category ID is required")]
public int CategoryId { get; set; }
[Required(ErrorMessage = "Item name is required")]
[StringLength(50, ErrorMessage = "Item name cannot exceed 50 characters")]
public string ItemName { get; set; }
[Required(ErrorMessage = "Item type is required")]
[StringLength(50, ErrorMessage = "Item type cannot exceed 50 characters")]
public string ItemType { get; set; }
[Required(ErrorMessage = "Rate is required")]
[Range(0, int.MaxValue, ErrorMessage = "Rate must be a positive number")]
public int Rate { get; set; }
[Required(ErrorMessage = "Quantity is required")]
[Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
public int Quantity { get; set; }
public bool Available { get; set; }
[StringLength(5, ErrorMessage = "Shortcode cannot exceed 5 characters")]
public string? Shortcode { get; set; }
[StringLength(50, ErrorMessage = "Image URL cannot exceed 50 characters")]
public string? ItemImage { get; set; }
[StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
public string? Description { get; set; }
public DateTime CreatedDate { get; set; }
public DateTime? ModifiedDate { get; set; }
public bool IsDeleted { get; set; }
public bool? IsFavourite { get; set; }
public bool? IsDefaultTax { get; set; }
[Required(ErrorMessage = "Tax ID is required")]
public int TaxId { get; set; }
public string? CategoryName { get; set; }
public string? CreatedBy { get; set; }
public string? ModifiedBy { get; set; }
}
