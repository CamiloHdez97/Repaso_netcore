using System.ComponentModel.DataAnnotations;

namespace Core.Estities;

public class Estado {
    [Key]
    public string CodEstado { get; set; }
    public string NomEstado { get; set; }
    public string CodPais { get; set; }
    public Pais Pais { get; set; }
    public ICollection<Region> Regiones { get; set; }
    
}