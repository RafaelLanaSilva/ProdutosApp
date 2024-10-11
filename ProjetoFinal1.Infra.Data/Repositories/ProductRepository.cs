﻿using ProjetoFinal1.Domain.Contracts.Repositories;
using ProjetoFinal1.Domain.Models.Entities;
using ProjetoFinal1.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public Product? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Product>().Where(p => p.Id == id).FirstOrDefault();
            } 
        }

    }
}