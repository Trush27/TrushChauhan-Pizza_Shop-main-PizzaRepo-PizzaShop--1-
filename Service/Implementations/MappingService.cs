namespace Service.Implementations;
using Entity.Models;
using Entity.ViewModel;

public class MappingService
{
    private readonly ApplicationDbContext _context;
    public MappingService(ApplicationDbContext context)
    {
        _context = context;
    }
    // Map Menucategory to MenuCategoryViewModel
    public MenuCategoryViewModel MapToViewModel(Menucategory category)
    {
        return new MenuCategoryViewModel
        {
            CategoryId = category.Categoryid,
            CategoryName = category.Categoryname,
            Description = category.Description,
            CreatedDate = category.Createddate,
            ModifiedDate = category.Modifieddate,
            IsDeleted = category.Isdeleted,
        };
    }
    // Map Menuitem to MenuItemViewModel
    public MenuItemViewModel MapToViewModel(Menuitem item)
    {
        return new MenuItemViewModel
        {
            ItemId = item.Itemid,
            CategoryId = item.Categoryid,
            ItemName = item.Itemname,
            ItemType = item.Itemtype,
            Rate = item.Rate,
            Quantity = item.Quantity,
            Available = item.Available,
            Shortcode = item.Shortcode,
            ItemImage = item.Itemimage,
            Description = item.Description,
            CreatedDate = item.Createddate,
            ModifiedDate = item.Modifieddate,
            IsDeleted = item.Isdeleted,
            IsFavourite = item.Isfavourite,
            IsDefaultTax = item.Isdefaulttax,
            TaxId = item.Taxid,
            CategoryName = item.Category?.Categoryname // Example
        };
    }
    public ModifierGroupViewModel ModifierToViewModel(Modifiergroup group)
    {
        return new ModifierGroupViewModel
        {
            ModifierGroupId = group.Modifiergroupid,
            ModifierGroupName = group.Modifiergroupname,
            Description = group.Description,
            MinSelect = group.Minselect,
            MaxSelect = group.Maxselect,
            CreatedDate = group.Createddate,
            ModifiedDate = group.Modifieddate,
            IsDeleted = group.Isdeleted
        };
    }

    public ModifierViewModel MapToViewModifier(Modifier modifier, int modifierGroupId)
    {
        var group = _context.Modifiergroups.Find(modifierGroupId);
        return new ModifierViewModel
        {
            ModifierId = modifier.Modifierid,
            ModifierGroupId = modifierGroupId,
            ModifierGroupName = group?.Modifiergroupname ?? "N/A",
            ModifierName = modifier.Modifiername,
            Unit = modifier.Unit,
            Rate = modifier.Rate,
            Quantity = modifier.Quantity,
            Description = modifier.Description,
            CreatedDate = modifier.Createddate,
            ModifiedDate = modifier.Modifieddate,
            IsDeleted = modifier.Isdeleted
        };
    }
}