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
    [HttpGet("Update")]
    public int Update(QuoteDto _QuoteDto, int id)
    {
        return _QuoteService.UpdateQuote(_QuoteDto, id);
    }

}
