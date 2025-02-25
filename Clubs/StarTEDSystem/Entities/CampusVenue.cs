﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

public partial class CampusVenue
{
    [Key]
    public int CampusVenueID { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string Location { get; set; }

    [InverseProperty("CampusVenue")]
    public virtual ICollection<ClubActivity> ClubActivities { get; set; } = new List<ClubActivity>();
}