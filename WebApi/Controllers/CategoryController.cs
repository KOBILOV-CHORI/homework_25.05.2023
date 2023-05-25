using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService = new CategoryService();
    }
    [HttpPost("Add Category")]
    public int Add(CategoryDto _categoryDto)
    {
        return _categoryService.AddCategory(_categoryDto);
    }
    [HttpGet("Update")]
    public int Update(CategoryDto _categoryDto, int id)
    {
        return _categoryService.UpdateCategory(_categoryDto, id);
    }
}
