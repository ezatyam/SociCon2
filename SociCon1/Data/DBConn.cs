using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SociCon1.Models;

namespace SociCon1.Data
{
    public class DBConn : DbContext
    {
        public DBConn(DbContextOptions<DBConn> options) : base(options)
        {
        }

        public DbSet<UserBasicDetails> UserBasicDetails { set; get; }

    }
}