using System.ComponentModel.DataAnnotations;

namespace MVCTemplate005.Models;

public class Book
{
    public int id { get; set; }

    [Required(ErrorMessage = "Không được để trống")]
    public string name { get; set; } = string.Empty;

    [Range(typeof(double), "0.0000000000000001", "1.7976931348623157E+308", ErrorMessage = "Giá phải lớn hơn 0")]
    public double price { get; set; }
}
