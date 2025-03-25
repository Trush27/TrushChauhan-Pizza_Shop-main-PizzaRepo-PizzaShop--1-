using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("menuitems")]
public partial class Menuitem
{
    [Key]
    [Column("itemid")]
    public int Itemid { get; set; }

    [Column("categoryid")]
    public int Categoryid { get; set; }

    [Column("itemname")]
    [StringLength(50)]
    public string Itemname { get; set; } = null!;

    [Column("itemtype")]
    [StringLength(50)]
    public string Itemtype { get; set; } = null!;

    [Column("rate")]
    public int Rate { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("available")]
    public bool Available { get; set; }

    [Column("shortcode")]
    [StringLength(5)]
    public string? Shortcode { get; set; }

    [Column("itemimage")]
    [StringLength(50)]
    public string? Itemimage { get; set; }

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

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

    [Column("isfavourite")]
    public bool? Isfavourite { get; set; }

    [Column("isdefaulttax")]
    public bool? Isdefaulttax { get; set; }

    [Column("taxid")]
    public int Taxid { get; set; }

    [ForeignKey("Categoryid")]
    [InverseProperty("Menuitems")]
    public virtual Menucategory Category { get; set; } = null!;

    [ForeignKey("Createdby")]
    [InverseProperty("MenuitemCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    [ForeignKey("Modifiedby")]
    [InverseProperty("MenuitemModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

    [ForeignKey("Taxid")]
    [InverseProperty("Menuitems")]
    public virtual Tax Tax { get; set; } = null!;
}
