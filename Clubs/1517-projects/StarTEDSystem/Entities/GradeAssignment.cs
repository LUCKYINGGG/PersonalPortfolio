﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("AssignmentID", Name = "IX_AssignmentID")]
[Index("RegistrationID", Name = "IX_RegistrationID")]
public partial class GradeAssignment
{
    [Key]
    public int GradeID { get; set; }

    public int AssignmentID { get; set; }

    public int RegistrationID { get; set; }

    public short? PossibleMarks { get; set; }

    public short EarnedMark { get; set; }

    public short? OverrideMark { get; set; }

    public string Reason { get; set; }

    [ForeignKey("AssignmentID")]
    [InverseProperty("GradeAssignments")]
    public virtual Assignment Assignment { get; set; }

    [ForeignKey("RegistrationID")]
    [InverseProperty("GradeAssignments")]
    public virtual ClassMember Registration { get; set; }
}