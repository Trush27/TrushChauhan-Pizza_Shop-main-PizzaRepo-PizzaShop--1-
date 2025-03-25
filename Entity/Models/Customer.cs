using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("customer")]
[Index("Customerid", Name = "uq", IsUnique = true)]
public partial class Customer
{
    [Key]
    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("customername")]
    [StringLength(50)]
    public string Customername { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("phonenumber")]
    [StringLength(10)]
    public string Phonenumber { get; set; } = null!;

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("totalorder")]
    public int Totalorder { get; set; }

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
    [InverseProperty("CustomerCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("CustomerCustomerNavigation")]
    public virtual Userlogin CustomerNavigation { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Customerorder> Customerorders { get; } = new List<Customerorder>();

    [InverseProperty("Customer")]
    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    [InverseProperty("Customer")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("CustomerModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}
