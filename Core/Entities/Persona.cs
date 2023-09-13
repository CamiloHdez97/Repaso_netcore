using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Core.Estites;

public class Persona {

    [Key]
    public string IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public int IdTipoPersona { get; set; }
    public TipoPersona TipoPersona{ get; set; } 
    public string IdRegion { get; set; }
    public Region Region { get; set; }
    public ICollection<PersonaProducto> PersonaProductos { get; set; }
    
}