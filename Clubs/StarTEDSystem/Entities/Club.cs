﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("EmployeeID", Name = "IX_EmployeeID")]
public partial class Club
{
    //Confirmed with Don, only handle the ClubID as a string when doing deliverable 2. 
    [Key]
    [StringLength(10, ErrorMessage = "ClubID is limited to 10 characters.")]
    [Unicode(false)]
    public string ClubID { get; set; }

    // added error message for required field, and limited the length to 50
    [Required(ErrorMessage = "Club name is required.")]
    [StringLength(50, ErrorMessage = "Club name is limited to 50 characters.")]
    [Unicode(false)]
    public string ClubName { get; set; }

    public bool Active { get; set; }

    public int? EmployeeID { get; set; }

    // not null field, added required attribute and set the range
    [Column(TypeName = "money")]
    [Required(ErrorMessage = "Fee is required.")]
    [Range(0.00, double.MaxValue, ErrorMessage ="Fee cannot be a negative number.")]
    public decimal Fee { get; set; }

    [InverseProperty("Club")]
    public virtual ICollection<ClubActivity> ClubActivities { get; set; } = new List<ClubActivity>();

    [InverseProperty("Club")]
    public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();

    [ForeignKey("EmployeeID")]
    [InverseProperty("Clubs")]
    public virtual Employee Employee { get; set; }
}