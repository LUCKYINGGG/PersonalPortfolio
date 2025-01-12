﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

public partial class RentalType
{
    [Key]
    public int RentalTypeID { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string Description { get; set; }

    [InverseProperty("RentalType")]
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}