﻿using Business.Abstracts;
using Entities;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Product;
using Core.CrossCuttingConcerns.Types;
using Business.Dtos.Product.Requests;
using Business.Dtos.Product.Responses;
using Business.Dtos.Product.Responses;


namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        // DI => Bu servis, servisler arasına eklendi mi?
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        // DTO => Data Transfer Object


       

        //public async Task Add(ProductForAddDto dto)

        // Request-Response Pattern
        public async Task Add(AddProductRequest dto)
        // public void Add(Product product)
        // public async void Add(Product product)
        {
            // ürün ismini kontrol et
            // fiyatını kontrol et

            if (dto.UnitPrice < 0)
                throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");
            // Aynı isimde 2. ürün eklenemez.

            //  Product? productWithSameName = _productRepository.Get(p => p.Name == product.Name);
            Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == dto.Name);

            if (productWithSameName is not null)
                // throw new Exception("Aynı isimde 2. ürün eklenemez.");
                throw new System.Exception("Aynı isimde 2. ürün eklenemez.");

            if (dto.Stock < 20)
            {
                throw new BusinessException("Stok miktarı 20'den küçük olamaz.");
            }

            // Async işlemler ✅
            // Global Ex. Handling.
            // İş kuralları, Validaton => Daha temiz yazarız?
            // Pipeline Mediator pattern ??

            //_productRepository.Add(product);


            // Mapping (Manual)
            // AutoMapping
            /* Product product = new();
            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.UnitPrice = dto.UnitPrice;
            product.CategoryId = dto.CategoryId;
            product.CreatedDate = DateTime.Now; 
            */

            Product product = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(product);

        }

        public void Delete(int id)
        {
            Product? productToDelete = _productRepository.Get(i => i.Id == id);
            throw new NotImplementedException();
        }

        // public List<Product> GetAll()
        // public async Task<List<ProductForListingDto>> GetAll()

        public async Task<List<ListProductResponse>> GetAll()

        {
            // Cacheleme?
            //  return _productRepository.GetList();
            // return await _productRepository.GetListAsync();

            List<Product> products = await _productRepository.GetListAsync();
            List<ListProductResponse> response = _mapper.Map<List<ListProductResponse>>(products);
            return response;
        }
        //List<ProductForListingDto> response = new List<ProductForListingDto>();

        //foreach (Product product in products)
        //{
        //    ProductForListingDto dto = new();
        //    dto.Name = product.Name;
        //    dto.UnitPrice = product.UnitPrice;
        //    dto.Id = product.Id;
        //    response.Add(dto);  
        //}

        // Manual Mapping
        // AutoMapping
        /* List<ProductForListingDto> response = products.Select(p => new ProductForListingDto()
        {
            Id = p.Id,
            Name = p.Name,
            UnitPrice = p.UnitPrice,
        }).ToList();
        */

        // List<ProductForListingDto> response = _mapper.Map<List<ProductForListingDto>>(products);




        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
