﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankEntities : DbContext
    {
        public BankEntities()
            : base("name=BankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Personeelslid> Personeel { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }
        public DbSet<TotaleSaldoPerKlant> TotaleSaldoPerKlant { get; set; }
    }
}
