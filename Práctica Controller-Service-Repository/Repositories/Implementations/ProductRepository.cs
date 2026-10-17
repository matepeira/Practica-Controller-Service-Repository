using Práctica_Controller_Service_Repository.Data;
using Práctica_Controller_Service_Repository.Entities;
using Práctica_Controller_Service_Repository.Repositories.Interfaces;

namespace Práctica_Controller_Service_Repository.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly PracticeContext _context;
    public ProductRepository(PracticeContext context)
    {
        _context = context;
    }
    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.Find(id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        Product? existingProduct = GetProductById(product.Id);
        if (existingProduct is not null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            _context.SaveChanges();
        }
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public List<Product> SearchProductsByName(string name)
    {
        return _context.Products
            .Where(p => p.Name.Contains(name))
            .ToList();
    }
}