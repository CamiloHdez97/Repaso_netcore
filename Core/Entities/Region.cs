using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Core.Estities;

public class Region {

    [Key]
    public string CodRegion { get; set; }
    public string NomRegion { get; set; }
    public string CodEstado { get; set; }
    public Estado Estado { get;set; }
    public ICollection<Persona> Personas { get; set; }
}