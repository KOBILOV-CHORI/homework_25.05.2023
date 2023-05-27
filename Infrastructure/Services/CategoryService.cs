namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class CategoryService
{
    DapperContext dapperContext;
    public CategoryService()
    {
        dapperContext = new DapperContext();
    }
    public int AddCategory(CategoryDto _categoryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into categories(name) values('{_categoryDto.CategoryName}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public int UpdateCategory(CategoryDto _categoryDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update categories set name='{_categoryDto.CategoryName}' where id = @Id";
            var result = conn.Execute(sql, _categoryDto);
            return result;
        }
    }
    public int DeleteCategory(int id)
    {
        string text = "hello";
       var count =  text.VowelCount();
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from categories where id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public List<CategoryDto> GetAllCetgories()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, name CategoryName from categories";
            var result = conn.Query<CategoryDto>(sql).ToList();
            return result;
        }
    }
}
