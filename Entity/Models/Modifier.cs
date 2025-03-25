using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("modifier")]
public partial class Modifier
{
    [Key]
    [Column("modifierid")]
    public int Modifierid { get; set; }

    [Column("modifiername")]
    [StringLength(50)]
    public string Modifiername { get; set; } = null!;

    [Column("unit")]
    [StringLength(50)]
    public string Unit { get; set; } = null!;

    [Column("rate")]
    public int Rate { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

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
    [InverseProperty("ModifierCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("ModifierModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Modifier")]
    public virtual ICollection<Modifiergroupandmodifier> Modifiergroupandmodifiers { get; } = new List<Modifiergroupandmodifier>();
}
