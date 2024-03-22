﻿using MyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    public class ProductServiceMySql : BaseProductService
    {
        public override void AddProduct(Product product)
        {
            Console.WriteLine("Ürün MYSQL'e eklendi.");
        }

        public override void DeleteProduct(Product product)
        {
        }

        public override void UpdateProduct(Product product)
        {
        }
    }
}