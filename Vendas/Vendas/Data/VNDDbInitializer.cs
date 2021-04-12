using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Data
{
    public class VNDDbInitializer
    {
        public static void Initialize(VNDContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Vendedores.Any())
            {
                context.Vendedores.Add(new Vendedores { Nome = "JOAO", Celular = "16 99988-7654" });

                context.Clientes.Add(new Clientes{ 
                    Nome = "MARIA APARECIDA", 
                    Celular = "11 98877-1234",
                    Endereco = "RUA 15 DE NOVEMBRO,1000",
                    Cidade = "SAO PAULO",
                    Uf = "SP",
                    email = "aparecidamaria@terra.com.br"
                });

                context.SaveChanges();
            }
        }
    }
}
