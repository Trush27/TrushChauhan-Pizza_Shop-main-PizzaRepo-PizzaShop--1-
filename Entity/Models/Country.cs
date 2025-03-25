using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("country")]
public partial class Country
{
    [Key]
    [Column("countryid")]
    public int Countryid { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

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
    [InverseProperty("CountryCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("CountryModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<State> States { get; } = new List<State>();

    [InverseProperty("Country")]
    public virtual ICollection<Userdetail> Userdetails { get; } = new List<Userdetail>();
}
