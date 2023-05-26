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
    public int UpdateCategory(CategoryDto _categoryDto)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update categories set name='{_categoryDto.CategoryName}' where id = @Id";
            var result = conn.Execute(sql, _categoryDto);
            return result;
        }
    }
    public int DeleteCategory(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"delete from categories where id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public List<CategoryDto> GetAllCetgories()
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"select id Id, name CategoryName from categories";
            var result = conn.Query<CategoryDto>(sql).ToList();
            return result;
        }
    }
}
