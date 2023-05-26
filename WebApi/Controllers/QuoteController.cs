using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
    private QuoteService _QuoteService;
    public QuoteController()
    {
        _QuoteService = new QuoteService();
    }
    [HttpPost("Add Quote")]
    public int Add(QuoteDto _QuoteDto)
    {
        return _QuoteService.AddQuote(_QuoteDto);
    }
    [HttpPut("Update")]
    public int Update(QuoteDto _QuoteDto)
    {
        return _QuoteService.UpdateQuote(_QuoteDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _QuoteService.DeleteQuote(id);
    }
    [HttpGet("Get All")]
    public List<QuoteDto> GetAll()
    {
        return _QuoteService.GetAllQuotes();
    }
    [HttpGet("Get Author with number of quotes")]
    public List<AuthorNumOfQuotesDto> AuthorNumOfQuotes()
    {
        return _QuoteService.AuthorNumOfQuotes();
    }
}
