using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Infrastucture.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PaisController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public PaisController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await unitOfWork.Paises.GetAllAsync();
        return  Ok(paises);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(string id)
    {
        var pais = await unitOfWork.Paises.GetByIdAsync(id); 
        return Ok(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais pais)
    {
        this.unitOfWork.Paises.Add(pais);
        await unitOfWork.SaveAsync();

        if(pais == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = pais.CodPais}, pais);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Put(string id, [FromBody]Pais pais)
    {
        if(pais == null)
            return NotFound();
        unitOfWork.Paises.Update(pais);
        await unitOfWork.SaveAsync();
        return pais;

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        
        var pais = await unitOfWork.Paises.GetByIdAsync(id);

        if(pais == null)
            return NotFound();

        unitOfWork.Paises.Update(pais);
        await unitOfWork.SaveAsync();
        return NoContent();
        
    }


}
