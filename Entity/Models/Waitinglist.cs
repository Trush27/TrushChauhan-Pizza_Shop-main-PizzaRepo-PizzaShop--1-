using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("waitinglist")]
public partial class Waitinglist
{
    [Key]
    [Column("tokenid")]
    public int Tokenid { get; set; }

    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("numberofperson")]
    public int Numberofperson { get; set; }

    [Column("sectionid")]
    public int Sectionid { get; set; }

    [Column("waitingtime")]
    public TimeOnly? Waitingtime { get; set; }

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

    [Column("tableid")]
    public int Tableid { get; set; }

    [Column("isassigned")]
    public bool Isassigned { get; set; }

    [ForeignKey("Createdby")]
    [InverseProperty("WaitinglistCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Waitinglists")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("Modifiedby")]
    [InverseProperty("WaitinglistModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Sectionid")]
    [InverseProperty("Waitinglists")]
    public virtual Section Section { get; set; } = null!;

    [ForeignKey("Tableid")]
    [InverseProperty("Waitinglists")]
    public virtual Dinetable Table { get; set; } = null!;
}
