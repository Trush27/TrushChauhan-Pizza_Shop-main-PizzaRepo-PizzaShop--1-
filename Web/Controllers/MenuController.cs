using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using Entity.ViewModel;
using System.Linq;
using Service.Interfaces;
using Service.Implementations;
public class MenuController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly MappingService _mappingService;
    public MenuController(ApplicationDbContext context, MappingService mappingService)
    {
        _context = context;
        _mappingService = mappingService;
    }
    // GET: Menu/Index
    public IActionResult Index()
    {
        var categories = _context.Menucategories
            .Where(c => !c.Isdeleted)
            .ToList();
        var categoryViewModels = categories
            .Select(c => _mappingService.MapToViewModel(c))
            .ToList();
        return View(categoryViewModels);
    }
    // GET: Menu/GetItems?categoryId=1
    public IActionResult GetItems(int categoryId)
    {
        var items = _context.Menuitems
            .Where(i => i.Categoryid == categoryId && !i.Isdeleted)
            .ToList();
        var itemViewModels = items
            .Select(i => _mappingService.MapToViewModel(i))
            .ToList();
        return Json(itemViewModels);
    }
    // POST: Menu/AddCategory
    [HttpPost]
    public IActionResult AddCategory([FromBody] MenuCategoryViewModel model)
    {
            var category = new Menucategory
            {
                Categoryid= model.CategoryId,
                Categoryname = model.CategoryName,
                Description = model.Description,
                Createddate = DateTime.Now,
                Isdeleted = false
            };
            _context.Menucategories.Add(category);
            _context.SaveChanges();
            return Ok();
    }
    // POST: Menu/AddItem
    [HttpPost]
    public IActionResult AddItem([FromBody] MenuItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            var item = new Menuitem
            {
                Categoryid = model.CategoryId,
                Itemname = model.ItemName,
                Itemtype = model.ItemType,
                Rate = model.Rate,
                Quantity = model.Quantity,
                Available = model.Available,
                Createddate = DateTime.Now,
                Isdeleted = false
            };
            _context.Menuitems.Add(item);
            _context.SaveChanges();
            return Ok();
        }
        return BadRequest(ModelState);
    }
    // POST: Menu/DeleteItem/1
    [HttpPost]
    public IActionResult DeleteItem(int id)
    {
        var item = _context.Menuitems.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        item.Isdeleted = true;
        _context.SaveChanges();
        return Ok();
    }
    public IActionResult GetModifierGroups()
    {
        var groups = _context.Modifiergroups
            .Where(g => !g.Isdeleted)
            .ToList();
            
        var viewModels = groups.Select(g => _mappingService.ModifierToViewModel(g)).ToList();
        return Json(viewModels);
    }

    // GET: Menu/GetModifiers?modifierGroupId=1
    public IActionResult GetModifiers(int modifierGroupId)
    {
        var group = _context.Modifiergroups.Find(modifierGroupId);
        if (group == null) return NotFound();

        var modifiers = _context.Modifiergroupandmodifiers
            .Where(m => m.Modifiergroupid == modifierGroupId && !m.Isdeleted)
            .Select(m => m.Modifier)
            .ToList();

        var viewModels = modifiers.Select(m => 
            _mappingService.MapToViewModifier(m, modifierGroupId)).ToList();
            
        return Json(viewModels);
    }

    [HttpPost]
    public IActionResult AddModifier([FromBody] ModifierViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Create modifier
            var modifier = new Modifier
            {
                Modifiername = model.ModifierName,
                Unit = model.Unit,
                Rate = model.Rate,
                Quantity = model.Quantity,
                Description = model.Description,
                Createddate = DateTime.Now,
                Isdeleted = false
            };
            _context.Modifiers.Add(modifier);
            _context.SaveChanges();

            // Create junction entry
            var junction = new Modifiergroupandmodifier
            {
                Modifiergroupid = model.ModifierGroupId,
                Modifierid = modifier.Modifierid,
                Createdat = DateTime.Now,
                Isdeleted = false
            };
            _context.Modifiergroupandmodifiers.Add(junction);
            _context.SaveChanges();

            return Ok();
        }
        return BadRequest(ModelState);
    }
    // POST: Menu/AddModifierGroup
    [HttpPost]
// Update AddModifierGroup to return the new ID
[HttpPost]
public IActionResult AddModifierGroup([FromBody] ModifierGroupViewModel model)
{
    if (ModelState.IsValid)
    {
        var modifierGroup = new Modifiergroup
        {
            Modifiergroupname = model.ModifierGroupName,
            Description = model.Description,
            Minselect = model.MinSelect,
            Maxselect = model.MaxSelect,
            Createddate = DateTime.Now,
            Isdeleted = false
        };
        _context.Modifiergroups.Add(modifierGroup);
        _context.SaveChanges();
        
        return Json(new { modifierGroupId = modifierGroup.Modifiergroupid });
    }
    return BadRequest(ModelState);
}
// Add these endpoints to your MenuController
[HttpGet]
public IActionResult GetAllModifiers(int page = 1, int pageSize = 10, string search = "")
{
    var query = _context.Modifiers.Where(m => !m.Isdeleted);
    
    if (!string.IsNullOrEmpty(search))
    {
        query = query.Where(m => m.Modifiername.Contains(search));
    }
    
    var totalItems = query.Count();
    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    
    var modifiers = query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    
    return Json(new {
        modifiers = modifiers.Select(m => new {
            modifierId = m.Modifierid,
            modifierName = m.Modifiername,
            unit = m.Unit,
            rate = m.Rate,
            quantity = m.Quantity
        }),
        totalPages = totalPages
    });
}

[HttpPost]
public IActionResult AddModifiersToGroup([FromBody] AddModifiersToGroupRequest request)
{
    try
    {
        foreach (var modifierId in request.ModifierIds)
        {
            if (!_context.Modifiergroupandmodifiers.Any(m => 
                m.Modifiergroupid == request.ModifierGroupId && 
                m.Modifierid == modifierId))
            {
                _context.Modifiergroupandmodifiers.Add(new Modifiergroupandmodifier
                {
                    Modifiergroupid = request.ModifierGroupId,
                    Modifierid = modifierId,
                    Createdat = DateTime.Now,
                    Isdeleted = false
                });
            }
        }
        _context.SaveChanges();
        return Ok();
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error adding modifiers: {ex.Message}");
    }
}

[HttpPost]
public IActionResult RemoveModifierFromGroup([FromBody] RemoveModifierRequest request)
{
    try
    {
        var junction = _context.Modifiergroupandmodifiers
            .FirstOrDefault(m => m.Modifiergroupid == request.ModifierGroupId 
                            && m.Modifierid == request.ModifierId);
                            
        if (junction != null)
        {
            junction.Isdeleted = true;
            _context.SaveChanges();
        }
        
        return Ok();
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error removing modifier: {ex.Message}");
    }
}

public class RemoveModifierRequest
{
    public int ModifierGroupId { get; set; }
    public int ModifierId { get; set; }
}

public class AddModifiersToGroupRequest
{
    public int ModifierGroupId { get; set; }
    public List<int> ModifierIds { get; set; }
}
}