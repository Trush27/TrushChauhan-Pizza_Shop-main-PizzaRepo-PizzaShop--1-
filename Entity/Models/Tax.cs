using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("tax")]
public partial class Tax
{
    [Key]
    [Column("taxid")]
    public int Taxid { get; set; }

    [Column("taxname")]
    [StringLength(50)]
    public string Taxname { get; set; } = null!;

    [Column("taxtype")]
    [StringLength(50)]
    public string Taxtype { get; set; } = null!;

    [Column("isenabled")]
    public bool Isenabled { get; set; }

    [Column("isdefaulttax")]
    public bool Isdefaulttax { get; set; }

    [Column("taxamount")]
    public int Taxamount { get; set; }

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
    [InverseProperty("TaxCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [InverseProperty("Tax")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    [InverseProperty("Tax")]
    public virtual ICollection<Menuitem> Menuitems { get; } = new List<Menuitem>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("TaxModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Tax")]
    public virtual ICollection<Ordertax> Ordertaxes { get; } = new List<Ordertax>();
}
