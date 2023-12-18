using Api.Entities;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public Task<IEnumerable<ProductEntity>> Get()
    {
        return _productRepository.GetAll();
    }

    [HttpGet("search")]
    public Task<IEnumerable<ProductEntity>> Search(string name)
    {
        return _productRepository.Search(name);
    }

    [HttpGet("search_unsafe")]
    public Task<IEnumerable<ProductEntity>> SearchUnsafe(string name)
    {
        return _productRepository.Search2(name);
    }
}