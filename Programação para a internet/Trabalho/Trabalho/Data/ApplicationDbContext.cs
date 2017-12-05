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

        public DbSet<Question> Question { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Que_Dis> Que_Dis { get; set; }
        public DbSet<Type_Client> Type_Client { get; set; }
        public DbSet<Type_Answer> Type_Answer { get; set; }
        public DbSet<TrailsStatus> TrailsStatus { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tra_An> Tra_An { get; set; }


    }
}
