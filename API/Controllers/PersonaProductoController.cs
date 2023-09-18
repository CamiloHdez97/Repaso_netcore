using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PersonaProductoController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public PersonaProductoController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaProducto>>> Get()
    {
        var personaProductos = await unitOfWork.PersonaProductos.GetAllAsync();
        return  Ok(personaProductos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Microsoft.AspNetCore.Mvc.ActionResult> Get(string id)
    {
        var personaProducto = await unitOfWork.PersonaProductos.GetByIdAsync(id); 
        return Ok(personaProducto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaProducto>> Post(PersonaProducto personaProducto)
    {
        this.unitOfWork.PersonaProductos.Add(personaProducto);
        await unitOfWork.SaveAsync();

        if(personaProducto == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = personaProducto.IdPersona}, personaProducto);
    }
}