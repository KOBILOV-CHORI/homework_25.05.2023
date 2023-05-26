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
    [HttpPut("Update")]
    public int Update(CategoryDto _categoryDto)
    {
        return _categoryService.UpdateCategory(_categoryDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
    [HttpGet("Get All")]
    public List<CategoryDto> GetAll()
    {
        return _categoryService.GetAllCetgories();
    }
}
