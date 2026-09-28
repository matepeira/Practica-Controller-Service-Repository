using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Práctica_Controller_Service_Repository.Models.DTOs.Requests;
using Práctica_Controller_Service_Repository.Models.DTOs.Responses;
using Práctica_Controller_Service_Repository.Services.Implemetations;

namespace Práctica_Controller_Service_Repository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private ProductService _service = new ProductService();

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetProductById(id);
        if(product is not null)
        {
            return Ok(product);
        }

        return NotFound();
    }

    [HttpPost]

    public IActionResult CreateProduct(ProductForCreateDto dto)
    {
        var newProduct = _service.CreateProduct(dto);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);

    }

    [HttpPut("{id}")]

    public IActionResult UpdateProduct(int id, ProductForUpdateDto dto)
    {
        var productToUpdate = _service.GetProductById(id);
        if (productToUpdate == null)
        {
            return NotFound();
        }

        _service.UpdateProduct(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteProduct(int id)
    {
        var productToDelete = _service.GetProductById(id);
        if (productToDelete == null)
        {
            return NotFound();
        }

        _service.DeleteProduct(id);
        return NoContent();
    }
}
