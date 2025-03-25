using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("kot")]
public partial class Kot
{
    [Key]
    [Column("kotid")]
    public int Kotid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("tableid")]
    public int? Tableid { get; set; }

    [Column("sectionid")]
    public int? Sectionid { get; set; }

    [Column("itemid")]
    public int? Itemid { get; set; }

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
    [InverseProperty("KotCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Itemid")]
    [InverseProperty("Kots")]
    public virtual Menuitem? Item { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("KotModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Kots")]
    public virtual Customerorder? Order { get; set; }

    [ForeignKey("Sectionid")]
    [InverseProperty("Kots")]
    public virtual Section? Section { get; set; }

    [ForeignKey("Tableid")]
    [InverseProperty("Kots")]
    public virtual Dinetable? Table { get; set; }
}
