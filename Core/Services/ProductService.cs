using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService
    {
        private readonly UnitOfWork unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Product> GetAll()
        {
            var results = unitOfWork.Products.GetAll();

            return results;
        }

        public ProductDto GetById(int productId)
        {
            var product = unitOfWork.Products.GetById(productId);

            var result = product.ToProductDto();

            return result;
        }

        public ProductAddDto AddProduct(ProductAddDto payload)
        {
            if (payload == null) return null;

           
            var newProduct = new Product
            {
                ProductName = payload.ProductName,
                Supplier = payload.Supplier,
                Strenght = payload.Strenght,
                PackingSize= payload.PackingSize,
                Unit = payload.Unit,
            };

            unitOfWork.Products.Insert(newProduct);
            unitOfWork.SaveChanges();

            return payload;
        }

        public bool DeleteById(int productId)
        {
            var product = unitOfWork.Products.GetById(productId);

            if (product == null)
            {
                return false;
            }

            var stock= unitOfWork.Stock.GetByProductId(productId);
            if(stock != null)
            {
                unitOfWork.Stock.Remove(stock);
                unitOfWork.SaveChanges();
            } 

            unitOfWork.Products.Remove(product);
            unitOfWork.SaveChanges();

            return true;

        }

        public bool UpdateProduct( UpdateProductDto updateProductDto)
        {

            var product = unitOfWork.Products.GetById(updateProductDto.Id);

            if (product == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(updateProductDto.ProductName))
            {
                product.ProductName = updateProductDto.ProductName;
            }
            if (!string.IsNullOrEmpty(updateProductDto.Supplier))
            {
                product.Supplier = updateProductDto.Supplier;
            }
            if (!string.IsNullOrEmpty(updateProductDto.Strength))
            {
                product.Strenght = updateProductDto.Strength;
            }
            if (!string.IsNullOrEmpty(updateProductDto.PackingSize))
            {
                product.PackingSize = updateProductDto.PackingSize;
            }
            if (!string.IsNullOrEmpty(updateProductDto.Unit))
            {
                product.Unit = updateProductDto.Unit;
            }

 
            unitOfWork.Products.Update(product);
            unitOfWork.SaveChanges();
            return true;
        }

    }
}
