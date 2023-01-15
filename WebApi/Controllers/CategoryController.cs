using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[Controller]")]
public class CategoryController:ControllerBase
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService=new CategoryService();
    }
[HttpGet("Get")]
    public List<Categor> Get(){
        return _categoryService.GetCat();
    }
     [HttpPost("Add")]
    public bool Add(Categor categor){
        return _categoryService.AddCat(categor);
    }

}
