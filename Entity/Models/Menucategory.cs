using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("menucategory")]
public partial class Menucategory
{
    [Key]
    [Column("categoryid")]
    public int Categoryid { get; set; }

    [Column("categoryname")]
    [StringLength(50)]
    public string Categoryname { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [Column("createddate", TypeName = "timestamp without time zone")]
    public DateTime Createddate { get; set; }

    [Column("modifieddate", TypeName = "timestamp without time zone")]
    public DateTime? Modifieddate { get; set; }

    [Column("createdby")]
    public int? Createdby { get; set; }

    [Column("modifiedby")]
    public int? Modifiedby { get; set; }

    [Column("isdeleted")]
    public bool Isdeleted { get; set; }

    [ForeignKey("Createdby")]
    [InverseProperty("MenucategoryCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Menuitem> Menuitems { get; } = new List<Menuitem>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("MenucategoryModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }
}
