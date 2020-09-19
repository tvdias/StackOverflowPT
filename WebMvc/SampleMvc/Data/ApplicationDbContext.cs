using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleMvc.Data.Models;

namespace SampleMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SampleMvc.Data.Models.Patrimonio> Patrimonio { get; set; }
        public DbSet<SampleMvc.Data.Models.Local> Local { get; set; }
    }
}
