using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("section")]
public partial class Section
{
    [Key]
    [Column("sectionid")]
    public int Sectionid { get; set; }

    [Column("sectionname")]
    [StringLength(50)]
    public string Sectionname { get; set; } = null!;

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
    [InverseProperty("SectionCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Dinetable> Dinetables { get; } = new List<Dinetable>();

    [InverseProperty("Section")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    [InverseProperty("Section")]
    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("SectionModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}
