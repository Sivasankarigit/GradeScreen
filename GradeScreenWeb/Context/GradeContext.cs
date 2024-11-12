using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeScreenWeb.Models;
using GradeScreenWeb.Service;
using Microsoft.EntityFrameworkCore;

namespace GradeScreenWeb.Context
{
    public class GradeContext:DbContext
    {
        public GradeContext(DbContextOptions<GradeContext> options):base (options){}
          
        public DbSet<GradeEntity> Grades { get; set; }

        
        
        
    }
}