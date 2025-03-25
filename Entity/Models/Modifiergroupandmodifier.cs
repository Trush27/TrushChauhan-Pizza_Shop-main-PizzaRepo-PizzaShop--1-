using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("modifiergroupandmodifier")]
public partial class Modifiergroupandmodifier
{
    [Key]
    [Column("mandmid")]
    public int Mandmid { get; set; }

    [Column("modifierid")]
    public int? Modifierid { get; set; }

    [Column("modifiergroupid")]
    public int? Modifiergroupid { get; set; }

    [Column("isdeleted")]
    public bool Isdeleted { get; set; }

    [Column("createdby")]
    public int? Createdby { get; set; }

    [Column("modifiedby")]
    public int? Modifiedby { get; set; }

    [Column("createdat", TypeName = "timestamp without time zone")]
    public DateTime? Createdat { get; set; }

    [Column("modifiedat", TypeName = "timestamp without time zone")]
    public DateTime? Modifiedat { get; set; }

    [ForeignKey("Modifierid")]
    [InverseProperty("Modifiergroupandmodifiers")]
    public virtual Modifier? Modifier { get; set; }

    [ForeignKey("Modifiergroupid")]
    [InverseProperty("Modifiergroupandmodifiers")]
    public virtual Modifiergroup? Modifiergroup { get; set; }
}
