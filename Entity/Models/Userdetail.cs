using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

[Table("userdetail")]
public partial class Userdetail
{
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    [Column("roleid")]
    public int Roleid { get; set; }

    [Column("firstname")]
    [StringLength(50)]
    public string Firstname { get; set; } = null!;

    [Column("lastname")]
    [StringLength(50)]
    public string Lastname { get; set; } = null!;

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("profileimage")]
    [StringLength(500)]
    public string? Profileimage { get; set; }

    [Column("phonenumber")]
    [StringLength(50)]
    public string Phonenumber { get; set; } = null!;

    [Column("address")]
    [StringLength(50)]
    public string Address { get; set; } = null!;

    [Column("zipcode")]
    [StringLength(10)]
    public string Zipcode { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

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

    [Column("countryid")]
    public int Countryid { get; set; }

    [Column("stateid")]
    public int Stateid { get; set; }

    [Column("cityid")]
    public int Cityid { get; set; }

    [ForeignKey("Cityid")]
    [InverseProperty("Userdetails")]
    public virtual City City { get; set; } = null!;

    [ForeignKey("Countryid")]
    [InverseProperty("Userdetails")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("Createdby")]
    [InverseProperty("UserdetailCreatedbyNavigations")]
    public virtual Userlogin? CreatedbyNavigation { get; set; }

    [ForeignKey("Modifiedby")]
    [InverseProperty("UserdetailModifiedbyNavigations")]
    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    [ForeignKey("Roleid")]
    [InverseProperty("Userdetails")]
    public virtual Userrole Role { get; set; } = null!;

    [ForeignKey("Stateid")]
    [InverseProperty("Userdetails")]
    public virtual State State { get; set; } = null!;

    [ForeignKey("Userid")]
    [InverseProperty("UserdetailUser")]
    public virtual Userlogin User { get; set; } = null!;
}
