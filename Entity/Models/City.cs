using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("city")]
public partial class City
{
    [Key]
    [Column("cityid")]
    public int Cityid { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("stateid")]
    public int? Stateid { get; set; }

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
    [InverseProperty("CityCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("CityModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Stateid")]
    [InverseProperty("Cities")]
    public virtual State? State { get; set; }

    [InverseProperty("City")]
    public virtual ICollection<Userdetail> Userdetails { get; } = new List<Userdetail>();
}
