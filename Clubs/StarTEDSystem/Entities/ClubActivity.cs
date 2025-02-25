﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("ClubID", Name = "IX_ActivityClubID")]
public partial class ClubActivity
{
    [Key]
    public int ActivityID { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string ClubID { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Location { get; set; }

    public bool OffCampus { get; set; }

    public int? CampusVenueID { get; set; }

    [ForeignKey("CampusVenueID")]
    [InverseProperty("ClubActivities")]
    public virtual CampusVenue CampusVenue { get; set; }

    [ForeignKey("ClubID")]
    [InverseProperty("ClubActivities")]
    public virtual Club Club { get; set; }
}