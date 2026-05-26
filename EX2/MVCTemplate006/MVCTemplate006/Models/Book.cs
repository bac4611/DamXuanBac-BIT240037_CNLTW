namespace MVCTemplate006.Models;

using System.ComponentModel.DataAnnotations;

public class Book
{
    public int id { get; set; }

    
    [Required(ErrorMessage = "Không được để trống tên sách!")]
    public string name { get; set; }

   
    [Required(ErrorMessage = "Vui lòng nhập giá sách!")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0!")]
    public decimal price { get; set; }
}