using Práctica_Controller_Service_Repository.Entities;
using Práctica_Controller_Service_Repository.Models.DTOs.Requests;
using Práctica_Controller_Service_Repository.Models.DTOs.Responses;
using Práctica_Controller_Service_Repository.Repositories.Implementations;
using Práctica_Controller_Service_Repository.Repositories.Interfaces;
using Práctica_Controller_Service_Repository.Services.Interfaces;
using System.Xml.Linq;
namespace Práctica_Controller_Service_Repository.Services.Implemetations;

public class ProductService : IProductService
{
    private ProductRepository _repository = new ProductRepository();
    public ProductService()
    {
        _repository = new ProductRepository();
    }

    public List<ProductForReadDto> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        var dtoList = new List<ProductForReadDto>();

        foreach (var product in products)
        {
            if (product != null)
            {
                dtoList.Add(new ProductForReadDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                });
            };
        }
        return dtoList;
    }

    public ProductForReadDto? GetProductById(int id)
    {
       var product = _repository.GetProductById(id);

        if (product is null)
        {
            return null;
        }

        return(new ProductForReadDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                });
    }

    public ProductForReadDto CreateProduct(ProductForCreateDto dto)
    {
        var allProducts = _repository.GetAllProducts();
        int newId = allProducts.Any() ? allProducts.Max(p => p.Id) + 1 : 1;

        var newProduct = new Product
        {
            Id = newId,
            Name = dto.Name,
            Price = dto.Price,
        };

       _repository.AddProduct(newProduct);

        return new ProductForReadDto
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Price = newProduct.Price,
        };
    }


    public void UpdateProduct(int id, ProductForUpdateDto dto)
    {
        var updatedProduct = _repository.GetProductById(id);
        if(updatedProduct is not null)
        {
            updatedProduct.Name = dto.Name;
            updatedProduct.Price = dto.Price;

            _repository.UpdateProduct(updatedProduct);
        }

    }

    public void DeleteProduct(int id)
    {
        var product = _repository.GetProductById(id);
        if(product is not null)
        {
            _repository.DeleteProduct(product);
        }
    }
}
