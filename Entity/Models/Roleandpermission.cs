using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("roleandpermission")]
public partial class Roleandpermission
{
    [Key]
    [Column("rapid")]
    public int Rapid { get; set; }

    [Column("roleid")]
    public int? Roleid { get; set; }

    [Column("permissionid")]
    public int? Permissionid { get; set; }

    [Column("canview")]
    public bool? Canview { get; set; }

    [Column("canaddedit")]
    public bool? Canaddedit { get; set; }

    [Column("candelete")]
    public bool? Candelete { get; set; }

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
    [InverseProperty("RoleandpermissionCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("RoleandpermissionModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Permissionid")]
    [InverseProperty("Roleandpermissions")]
    public virtual Userpermission? Permission { get; set; }

    [ForeignKey("Roleid")]
    [InverseProperty("Roleandpermissions")]
    public virtual Userrole? Role { get; set; }
}
