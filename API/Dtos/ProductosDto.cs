using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProductosDto {

    public string Cod { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double valor { get; set; }
    public int Stock_Minimo { get; set; }
    public int Stock_Maximo { get; set; }


}