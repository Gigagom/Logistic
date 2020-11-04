using logistic_app_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class LogisticContext : DbContext
    {
        public LogisticContext(DbContextOptions<LogisticContext> opt) : base(opt)
        {
         
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
    }
}
