﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("ClubID", Name = "IX_ClubID")]
[Index("StudentNumber", Name = "IX_StudentNumber")]
public partial class ClubMember
{
    [Key]
    public int MemberID { get; set; }

    public int StudentNumber { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string ClubID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EnrolledDate { get; set; }

    public bool Active { get; set; }

    public bool? FeePaid { get; set; }

    public int? RoleID { get; set; }

    [ForeignKey("ClubID")]
    [InverseProperty("ClubMembers")]
    public virtual Club Club { get; set; }

    [ForeignKey("RoleID")]
    [InverseProperty("ClubMembers")]
    public virtual Role Role { get; set; }

    [ForeignKey("StudentNumber")]
    [InverseProperty("ClubMembers")]
    public virtual Student StudentNumberNavigation { get; set; }
}