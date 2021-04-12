using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Data
{
    public class VNDContext : DbContext
    {
        public VNDContext(DbContextOptions<VNDContext> options) : base(options)
        {

        }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }
}
