using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itu.DAL
{
    public class ItuDbContext : DbContext
    {
        public ItuDbContext(DbContextOptions<ItuDbContext> options) : base(options) { }
    }
}
