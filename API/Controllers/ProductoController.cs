using Core.Estities;
using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductoController : BaseApiController{

    private readonly IUnitOfWork unitOfWork;
    public ProductoController(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get()
    {
        var productos = await unitOfWork.Productos.GetAllAsync();
        return  Ok(productos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Get(string id)
    {
        var producto = await unitOfWork.Productos.GetByIdAsync(id); 
        return Ok(producto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(Producto producto)
    {
        this.unitOfWork.Productos.Add(producto);
        await unitOfWork.SaveAsync();

        if(producto == null)
        {
            return BadRequest();
        } 
        return CreatedAtAction(nameof(Post), new {id = producto.IdProducto}, producto);
    }

        [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Put(string id, [FromBody]Producto producto)
    {
        if(producto == null)
            return NotFound();
        unitOfWork.Productos.Update(producto);
        await unitOfWork.SaveAsync();
        return producto;

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        
        var producto = await unitOfWork.Productos.GetByIdAsync(id);

        if(producto == null)
            return NotFound();

        unitOfWork.Productos.Update(producto);
        await unitOfWork.SaveAsync();
        return NoContent();
        
    }
}
