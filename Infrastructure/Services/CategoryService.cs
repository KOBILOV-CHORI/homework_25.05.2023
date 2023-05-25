namespace Infrastructure.Services;
using Npgsql;
using Dapper;
using Domain.Dtos;

public class CategoryService
{
    string connString = $"Server=localhost;Port=5432;User id=postgres;Database=quotes;Password=01062007";

    public int AddCategory(CategoryDto _categoryDto)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"insert into categories(name) values('{_categoryDto.CategoryName}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public int UpdateCategory(CategoryDto _categoryDto, int Id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update categories set name='{_categoryDto.CategoryName}' where id = {Id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    
    
}
