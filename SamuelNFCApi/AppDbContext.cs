using SamuelNFCApi.Models.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SamuelNFCApi
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public AppDbContext() : base("name=remote")
        {
            Database.Log = e => Debug.WriteLine(e);
        }

        public DbSet<ClientPersonal> ClientsPersonal { get; set; }
        public DbSet<ClientSocial> ClientsSocial { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientPersonal>().ToTable("ClientsPersonal");
            modelBuilder.Entity<ClientSocial>().ToTable("ClientsSocial");
        }
    }
}