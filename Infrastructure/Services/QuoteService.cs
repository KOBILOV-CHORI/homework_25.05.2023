using Dapper;
using Domain.Dtos;
using Infrastructure.Context;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    DapperContext dapperContext;
    public QuoteService()
    {
        dapperContext = new DapperContext();
    }
    public int AddQuote(QuoteDto _quoteDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into quotes(author, quote_text, category_id) values('{_quoteDto.Author}', '{_quoteDto.QuoteText}', '{_quoteDto.CategoryId}') returning id";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public int UpdateQuote(QuoteDto _quoteDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update quotes set id={_quoteDto.Id}, author = '{_quoteDto.Author}', quote_text = '{_quoteDto.QuoteText}' where id = @Id";
            var result = conn.Execute(sql, _quoteDto);
            return result;
        }
    }
    public List<QuoteDto> GetAllQuotes()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, author Author, quote_text QuoteText, category_id CategoryId from quotes";
            var result = conn.Query<QuoteDto>(sql).ToList();
            return result;
        }
    }
    public int DeleteQuote(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from quotes where id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public List<AuthorNumOfQuotesDto> AuthorNumOfQuotes()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select author, Count(*) as CountOfQuotes from quotes group by author";
            var result = conn.Query<AuthorNumOfQuotesDto>(sql).ToList();
            return result;
        }
    }
}
