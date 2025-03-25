using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("invoice")]
public partial class Invoice
{
    [Key]
    [Column("invoiceid")]
    public int Invoiceid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("customerid")]
    public int? Customerid { get; set; }

    [Column("tableid")]
    public int? Tableid { get; set; }

    [Column("taxid")]
    public int? Taxid { get; set; }

    [Column("sectionid")]
    public int? Sectionid { get; set; }

    [Column("waitingtime")]
    public TimeOnly Waitingtime { get; set; }

    [Column("paymentmode")]
    [StringLength(50)]
    public string Paymentmode { get; set; } = null!;

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
    [InverseProperty("InvoiceCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Invoices")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("InvoiceModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Invoices")]
    public virtual Customerorder? Order { get; set; }

    [ForeignKey("Sectionid")]
    [InverseProperty("Invoices")]
    public virtual Section? Section { get; set; }

    [ForeignKey("Tableid")]
    [InverseProperty("Invoices")]
    public virtual Dinetable? Table { get; set; }

    [ForeignKey("Taxid")]
    [InverseProperty("Invoices")]
    public virtual Tax? Tax { get; set; }
}
