using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("ordertax")]
public partial class Ordertax
{
    [Key]
    [Column("ordertaxid")]
    public int Ordertaxid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("taxid")]
    public int? Taxid { get; set; }

    [Column("taxvalue")]
    public double Taxvalue { get; set; }

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
    [InverseProperty("OrdertaxCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("OrdertaxModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Ordertaxes")]
    public virtual Customerorder? Order { get; set; }

    [ForeignKey("Taxid")]
    [InverseProperty("Ordertaxes")]
    public virtual Tax? Tax { get; set; }
}
