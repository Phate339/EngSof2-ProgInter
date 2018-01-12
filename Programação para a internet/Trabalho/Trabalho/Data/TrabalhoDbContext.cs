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

        public DbSet<Questions> Questions { get; set; }
        public DbSet<TuristAnswer> TuristAnswer { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Trails> Trails { get; set; }
        public DbSet<Turist> Turist { get; set; }
         public DbSet<Answer> Answer { get; set; }



    }
}
