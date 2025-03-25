using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("customerorder")]
public partial class Customerorder
{
    [Key]
    [Column("orderid")]
    public int Orderid { get; set; }

    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("paymentmode")]
    [StringLength(50)]
    public string Paymentmode { get; set; } = null!;

    [Column("rating")]
    public int Rating { get; set; }

    [Column("totalamount")]
    public int Totalamount { get; set; }

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
    [InverseProperty("CustomerorderCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Customerorders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    [InverseProperty("Order")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    [InverseProperty("Order")]
    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("CustomerorderModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

    [InverseProperty("Order")]
    public virtual ICollection<Ordertax> Ordertaxes { get; } = new List<Ordertax>();
}
