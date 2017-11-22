using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Survey> Survey { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Sur_Dis> Sur_Dis { get; set; }
        public DbSet<Type_Client> Type_Client { get; set; }




    }
}
