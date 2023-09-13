using System.Web.Mvc;
using Core.Estites;
using Infrastucture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PaisController : BaseApiController{

    private readonly InventarioContext _context;
    
    public PaisController(InventarioContext context)
    {
         _context = context;
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await _context.Paises.ToListAsync();
        return  Ok(paises);
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Microsoft.AspNetCore.Mvc.ActionResult> Get(string id)
    {
        var pais = await _context.Paises.FindAsync(id); 
        return Ok(pais);
    }
}
