using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Core.Estities;

public class Pais {
    [Key]
    public string CodPais {get;set;}
    public string NomPais {get;set;}
    public ICollection<Estado> Estados {get;set;}


}