using System.ComponentModel.DataAnnotations;

namespace Core.Estities;

public class TipoPersona{

    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<Persona> Personas { get; set; }

}