﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

public partial class SchoolTerm
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Semester { get; set; }

    public bool Completed { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FirstDayOfClasses { get; set; }

    [InverseProperty("SemesterNavigation")]
    public virtual ICollection<Offering> Offerings { get; set; } = new List<Offering>();
}