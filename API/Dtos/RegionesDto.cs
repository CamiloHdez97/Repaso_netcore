using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace API.Dtos;

public class RegionesDto {

    public string Cod { get; set; }
    public string Name { get; set; }
    public string Id_Estado { get; set; }

}