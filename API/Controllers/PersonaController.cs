using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Infrastucture.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PersonaController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public PersonaController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var personas = await unitOfWork.Personas.GetAllAsync();
        return  Ok(personas);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Microsoft.AspNetCore.Mvc.ActionResult> Get(string id)
    {
        var persona = await unitOfWork.Personas.GetByIdAsync(id); 
        return Ok(persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(Persona persona)
    {
        this.unitOfWork.Personas.Add(persona);
        await unitOfWork.SaveAsync();

        if(persona == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = persona.IdPersona}, persona);
    }
}
