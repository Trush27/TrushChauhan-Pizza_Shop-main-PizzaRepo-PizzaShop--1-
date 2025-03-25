using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("userrole")]
public partial class Userrole
{
    [Key]
    [Column("roleid")]
    public int Roleid { get; set; }

    [Column("rolename")]
    [StringLength(50)]
    public string? Rolename { get; set; }

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
    [InverseProperty("UserroleCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("UserroleModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Roleandpermission> Roleandpermissions { get; } = new List<Roleandpermission>();

    [InverseProperty("Role")]
    public virtual ICollection<Userdetail> Userdetails { get; } = new List<Userdetail>();

    [InverseProperty("Role")]
    public virtual ICollection<Userlogin> Userlogins { get; } = new List<Userlogin>();
}
