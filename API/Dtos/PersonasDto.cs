using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace API.Dtos;

public class PersonasDto {

    public string CC { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Correo { get; set; }
    public int Id_TipoPersona { get; set; }
    public string Id_Region { get; set; }
    
}