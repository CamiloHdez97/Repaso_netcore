using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Infrastucture.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class TipoPersonaController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public TipoPersonaController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoPersona>>> Get()
    {
        var tipoPersonas = await unitOfWork.TipoPersonas.GetAllAsync();
        return  Ok(tipoPersonas);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(string id)
    {
        var tipoPersona = await unitOfWork.TipoPersonas.GetByIdAsync(id); 
        return Ok(tipoPersona);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersona>> Post(TipoPersona tipoPersona)
    {
        this.unitOfWork.TipoPersonas.Add(tipoPersona);
        await unitOfWork.SaveAsync();

        if(tipoPersona == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = tipoPersona.Id}, tipoPersona);
    }
}
