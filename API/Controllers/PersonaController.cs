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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Put(string id, [FromBody]Persona persona)
    {
        if(persona == null)
            return NotFound();
        unitOfWork.Personas.Update(persona);
        await unitOfWork.SaveAsync();
        return persona;

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        
        var persona = await unitOfWork.Personas.GetByIdAsync(id);

        if(persona == null)
            return NotFound();

        unitOfWork.Personas.Update(persona);
        await unitOfWork.SaveAsync();
        return NoContent();
        
    }
}
