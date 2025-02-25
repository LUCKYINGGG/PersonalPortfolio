﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("CourseID", Name = "IX_CourseID")]
public partial class PlannedAssessment
{
    [Key]
    public int AssessmentID { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string Name { get; set; }

    public int? AssessmentTypeID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; }

    [Required]
    [StringLength(7)]
    [Unicode(false)]
    public string CourseID { get; set; }

    public short Weight { get; set; }

    public bool RequiredPass { get; set; }

    [ForeignKey("AssessmentTypeID")]
    [InverseProperty("PlannedAssessments")]
    public virtual AssessmentType AssessmentType { get; set; }

    [ForeignKey("CourseID")]
    [InverseProperty("PlannedAssessments")]
    public virtual Course Course { get; set; }
}