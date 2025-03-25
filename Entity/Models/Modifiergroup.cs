using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("modifiergroup")]
public partial class Modifiergroup
{
    [Key]
    [Column("modifiergroupid")]
    public int Modifiergroupid { get; set; }

    [Column("modifiergroupname")]
    [StringLength(50)]
    public string Modifiergroupname { get; set; } = null!;

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

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("minselect")]
    public int Minselect { get; set; }

    [Column("maxselect")]
    public int Maxselect { get; set; }

    [ForeignKey("Createdby")]
    [InverseProperty("ModifiergroupCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("ModifiergroupModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Modifiergroup")]
    public virtual ICollection<Modifiergroupandmodifier> Modifiergroupandmodifiers { get; } = new List<Modifiergroupandmodifier>();
}
