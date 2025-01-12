﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystem.Entities;

[Index("AddressID", Name = "IX_AddressID")]
[Index("ForwardingAddressID", Name = "IX_ForwardingAddressID")]
[Index("StudentID", Name = "IX_StudentID")]
public partial class StudentAddress
{
    [Key]
    public int StudentAddressID { get; set; }

    public int StudentID { get; set; }

    public int AddressID { get; set; }

    public DateOnly SinceDate { get; set; }

    public DateOnly? UntilDate { get; set; }

    public int? ForwardingAddressID { get; set; }

    public bool IsPrimaryResidence { get; set; }

    [ForeignKey("AddressID")]
    [InverseProperty("StudentAddressAddresses")]
    public virtual Address Address { get; set; }

    [ForeignKey("ForwardingAddressID")]
    [InverseProperty("StudentAddressForwardingAddresses")]
    public virtual Address ForwardingAddress { get; set; }

    [ForeignKey("StudentID")]
    [InverseProperty("StudentAddresses")]
    public virtual Student Student { get; set; }
}