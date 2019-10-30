using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleAppEntityUsuarios
{
    class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\jaime\\source\\repos\\ConsoleAppEntityUsuarios\\ConsoleAppEntityUsuarios\\TodoEmpresa.db");

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
