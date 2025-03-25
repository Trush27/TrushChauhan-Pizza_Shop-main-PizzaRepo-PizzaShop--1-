public class ModifierViewModel
{
    public int ModifierId { get; set; }
    public int ModifierGroupId { get; set; }
    public string ModifierGroupName { get; set; }
    public string ModifierName { get; set; }
    public string Unit { get; set; }
    public int Rate { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}