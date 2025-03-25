using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("orderdetail")]
public partial class Orderdetail
{
    [Key]
    [Column("orderdetailid")]
    public int Orderdetailid { get; set; }

    [Column("itemid")]
    public int Itemid { get; set; }

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

    [Column("orderid")]
    public int Orderid { get; set; }

    [Column("invoiceid")]
    public int Invoiceid { get; set; }

    [ForeignKey("Createdby")]
    [InverseProperty("OrderdetailCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Itemid")]
    [InverseProperty("Orderdetails")]
    public virtual Menuitem Item { get; set; } = null!;

    [ForeignKey("Modifiedby")]
    [InverseProperty("OrderdetailModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Orderdetails")]
    public virtual Customerorder Order { get; set; } = null!;
}
