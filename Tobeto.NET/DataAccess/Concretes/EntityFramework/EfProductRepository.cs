﻿using Core.DataAccess;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductRepository : EfRepositoryBase<Product, BaseDbContext>, IProductRepository
    {
        public EfProductRepository(BaseDbContext context) : base(context)
        {

        }

    }


}



/*




// ORM yapısı
public void Add(Product product)
{
    using (BaseDbContext context = new())   // using bloğu ya da scope u tıpkı liste gibi kullandık
    {
        context.Products.Add(product);
        context.SaveChanges();
    }   // Dispose
}

public void Delete(Product product)
{
    using (BaseDbContext context = new())
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }
}

public List<Product> GetAll()
{
    using (BaseDbContext context = new())
    {
        return context.Products.ToList();
    }
}


public Product GetById(int id)
{
    using (BaseDbContext context = new())
    {
        return context.Products.FirstOrDefault(p => p.Id == id);

    }
}

public void Update(Product product)
{
    using (BaseDbContext context = new())
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }
}
}
}
*/