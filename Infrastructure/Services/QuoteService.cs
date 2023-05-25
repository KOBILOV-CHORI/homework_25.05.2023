using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    string connString = $"Server=localhost;Port=5432; User id=postgres; Database=quotes; Password=01062007";

    public int AddQuote(QuoteDto _quoteDto)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"insert into categories(author, quote_text, category_id) values('{_quoteDto.Author}', '{_quoteDto.QuoteText}', '{_quoteDto.CategoryId}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public int UpdateQuote(QuoteDto _quoteDto, int Id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update quotes set quote_text='{_quoteDto.QuoteText}' where id = {Id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public List<QuoteDto> GetAll()
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"select q.quote_text, c.name from quotes q join categories c";
            var result = conn.Query<QuoteDto>(sql).ToList();
            return result;
        }
    }
    public List<QuoteDto> GetById(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"select q.quote_text from quotes q join categories c where c.id={id}";
            var result = conn.Query<QuoteDto>(sql).ToList();
            return result;
        }
    }
}
