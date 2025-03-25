using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("userlogin")]
[Index("Email", Name = "userlogin_email_key", IsUnique = true)]
public partial class Userlogin
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("createddate", TypeName = "timestamp without time zone")]
    public DateTime? Createddate { get; set; }

    [Column("modifieddate", TypeName = "timestamp without time zone")]
    public DateTime? Modifieddate { get; set; }

    [Column("createdby")]
    public int? Createdby { get; set; }

    [Column("modifiedby")]
    public int? Modifiedby { get; set; }

    [Column("isdeleted")]
    public bool? Isdeleted { get; set; }

    [Column("roleid")]
    public int Roleid { get; set; }

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<City> CityCreatedbyNavigations { get; } = new List<City>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<City> CityModifiedbyNavigations { get; } = new List<City>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Country> CountryCreatedbyNavigations { get; } = new List<Country>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Country> CountryModifiedbyNavigations { get; } = new List<Country>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Customer> CustomerCreatedbyNavigations { get; } = new List<Customer>();

    [InverseProperty("CustomerNavigation")]
    public virtual Customer? CustomerCustomerNavigation { get; set; }

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Customer> CustomerModifiedbyNavigations { get; } = new List<Customer>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Customerorder> CustomerorderCreatedbyNavigations { get; } = new List<Customerorder>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Customerorder> CustomerorderModifiedbyNavigations { get; } = new List<Customerorder>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Dinetable> DinetableCreatedbyNavigations { get; } = new List<Dinetable>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Dinetable> DinetableModifiedbyNavigations { get; } = new List<Dinetable>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Feedback> FeedbackCreatedbyNavigations { get; } = new List<Feedback>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Feedback> FeedbackModifiedbyNavigations { get; } = new List<Feedback>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Invoice> InvoiceCreatedbyNavigations { get; } = new List<Invoice>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Invoice> InvoiceModifiedbyNavigations { get; } = new List<Invoice>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Kot> KotCreatedbyNavigations { get; } = new List<Kot>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Kot> KotModifiedbyNavigations { get; } = new List<Kot>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Menucategory> MenucategoryCreatedbyNavigations { get; } = new List<Menucategory>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Menucategory> MenucategoryModifiedbyNavigations { get; } = new List<Menucategory>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Menuitem> MenuitemCreatedbyNavigations { get; } = new List<Menuitem>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Menuitem> MenuitemModifiedbyNavigations { get; } = new List<Menuitem>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Modifier> ModifierCreatedbyNavigations { get; } = new List<Modifier>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Modifier> ModifierModifiedbyNavigations { get; } = new List<Modifier>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Modifiergroup> ModifiergroupCreatedbyNavigations { get; } = new List<Modifiergroup>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Modifiergroup> ModifiergroupModifiedbyNavigations { get; } = new List<Modifiergroup>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Orderdetail> OrderdetailCreatedbyNavigations { get; } = new List<Orderdetail>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Orderdetail> OrderdetailModifiedbyNavigations { get; } = new List<Orderdetail>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Ordertax> OrdertaxCreatedbyNavigations { get; } = new List<Ordertax>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Ordertax> OrdertaxModifiedbyNavigations { get; } = new List<Ordertax>();

    [ForeignKey("Roleid")]
    [InverseProperty("Userlogins")]
    public virtual Userrole Role { get; set; } = null!;

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Roleandpermission> RoleandpermissionCreatedbyNavigations { get; } = new List<Roleandpermission>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Roleandpermission> RoleandpermissionModifiedbyNavigations { get; } = new List<Roleandpermission>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Section> SectionCreatedbyNavigations { get; } = new List<Section>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Section> SectionModifiedbyNavigations { get; } = new List<Section>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<State> StateCreatedbyNavigations { get; } = new List<State>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<State> StateModifiedbyNavigations { get; } = new List<State>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Tax> TaxCreatedbyNavigations { get; } = new List<Tax>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Tax> TaxModifiedbyNavigations { get; } = new List<Tax>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Userdetail> UserdetailCreatedbyNavigations { get; } = new List<Userdetail>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Userdetail> UserdetailModifiedbyNavigations { get; } = new List<Userdetail>();

    [InverseProperty("User")]
    public virtual Userdetail? UserdetailUser { get; set; }

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Userpermission> UserpermissionCreatedbyNavigations { get; } = new List<Userpermission>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Userpermission> UserpermissionModifiedbyNavigations { get; } = new List<Userpermission>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Userrole> UserroleCreatedbyNavigations { get; } = new List<Userrole>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Userrole> UserroleModifiedbyNavigations { get; } = new List<Userrole>();

    [InverseProperty("CreatedbyNavigation")]
    public virtual ICollection<Waitinglist> WaitinglistCreatedbyNavigations { get; } = new List<Waitinglist>();

    [InverseProperty("ModifiedbyNavigation")]
    public virtual ICollection<Waitinglist> WaitinglistModifiedbyNavigations { get; } = new List<Waitinglist>();
}
