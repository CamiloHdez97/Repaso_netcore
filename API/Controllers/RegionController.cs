using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RegionController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public RegionController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var regiones = await unitOfWork.Regiones.GetAllAsync();
        return  Ok(regiones);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(string id)
    {
        var region = await unitOfWork.Regiones.GetByIdAsync(id); 
        return Ok(region);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(Region region)
    {
        this.unitOfWork.Regiones.Add(region);
        await unitOfWork.SaveAsync();

        if(region == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = region.CodRegion}, region);
    }
}
