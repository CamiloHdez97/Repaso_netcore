using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Infrastucture.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class EstadoController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public EstadoController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estados = await unitOfWork.Estados.GetAllAsync();
        return  Ok(estados);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Microsoft.AspNetCore.Mvc.ActionResult> Get(string id)
    {
        var estado = await unitOfWork.Estados.GetByIdAsync(id); 
        return Ok(estado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(Estado estado)
    {
        this.unitOfWork.Estados.Add(estado);
        await unitOfWork.SaveAsync();

        if(estado == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = estado.CodEstado}, estado);
    }

}
