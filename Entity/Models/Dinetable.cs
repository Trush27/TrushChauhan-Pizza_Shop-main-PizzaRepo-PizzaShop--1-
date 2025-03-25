using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("dinetable")]
public partial class Dinetable
{
    [Key]
    [Column("tableid")]
    public int Tableid { get; set; }

    [Column("sectionid")]
    public int Sectionid { get; set; }

    [Column("tablename")]
    [StringLength(50)]
    public string Tablename { get; set; } = null!;

    [Column("capacity")]
    public int Capacity { get; set; }

    [Column("status")]
    public bool Status { get; set; }

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
    [InverseProperty("DinetableCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [InverseProperty("Table")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    [InverseProperty("Table")]
    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("DinetableModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Sectionid")]
    [InverseProperty("Dinetables")]
    public virtual Section Section { get; set; } = null!;

    [InverseProperty("Table")]
    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}
