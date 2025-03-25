using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("feedback")]
public partial class Feedback
{
    [Key]
    [Column("feedbackid")]
    public int Feedbackid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("customerid")]
    public int? Customerid { get; set; }

    [Column("ordercomment")]
    [StringLength(50)]
    public string? Ordercomment { get; set; }

    [Column("itemcomment")]
    [StringLength(50)]
    public string? Itemcomment { get; set; }

    [Column("food")]
    public int? Food { get; set; }

    [Column("ambience")]
    public int? Ambience { get; set; }

    [Column("service")]
    public int? Service { get; set; }

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
    [InverseProperty("FeedbackCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Feedbacks")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("FeedbackModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Feedbacks")]
    public virtual Customerorder? Order { get; set; }
}
