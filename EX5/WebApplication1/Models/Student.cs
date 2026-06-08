namespace WebApplication1.Models;

using System.ComponentModel.DataAnnotations;
public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sinh viên không được để trống")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Lớp không được để trống")]
    public string ClassName { get; set; }

    [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
    public double Score { get; set; }
}