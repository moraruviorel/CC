﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CC.Models.Database
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class ExcelentConstructWorks : DbContext
{
    public ExcelentConstructWorks()
        : base("name=ExcelentConstructWorks")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Work> Works { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

}

}

