using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class TrabalhoDbContext : DbContext
    {
        public TrabalhoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Question> Question { get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Que_Dis> Que_Dis { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Trails> Trails { get; set; }
        public DbSet<Turist> Turist { get; set; }
        public DbSet<Ans_For_Que> Ans_For_Que { get; set; }
        public DbSet<Type_Answer> Type_Answer { get; set; }
        public DbSet<Tra_Sur> Tra_Sur { get; set; }


    }
}
