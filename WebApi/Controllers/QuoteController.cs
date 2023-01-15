using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
  
  [ApiController]
[Route("[Controller]")]

public class QuoteController:ControllerBase
{
    private QuoteService _quoteService;
    public QuoteController()
    {
        _quoteService=new QuoteService();
    }

    [HttpGet("Get")]
    public List<Quote> Get(){
        return _quoteService.GetQuotes();
    }
    [HttpGet("GetCategoryId")]
    public List<Quote> GetCategoryId(int id){
        return _quoteService.GetBycategoryId(id);
    }
    [HttpGet("GetRandom")]
    public List<Quote> Random(){
        return _quoteService.GetRandom();
    }

    [HttpPost("Add")]
    public bool Add(Quote quote){
        return _quoteService.AddQuote(quote);
    }

    [HttpPut("Update")]
    public bool Update(Quote quote){
    return _quoteService.UpdateQuote(quote);
    }
    [HttpDelete("Delete")]
    public bool Delete(int id){
        return _quoteService.DeleteID(id);
    }
}
