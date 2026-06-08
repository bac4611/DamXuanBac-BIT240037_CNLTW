# Ứng dụng quản lý sinh viên ASP.NET MVC

## 1. Giới thiệu

Đây là ứng dụng web ASP.NET MVC đơn giản dùng để quản lý thông tin sinh viên. Ứng dụng được xây dựng theo mô hình MVC gồm Model, View và Controller. Dữ liệu sinh viên được lưu tạm bằng `List<Student>` trong chương trình, chưa sử dụng cơ sở dữ liệu.

Ứng dụng có các chức năng chính:

* Hiển thị danh sách sinh viên
* Thêm sinh viên mới
* Sửa thông tin sinh viên
* Xóa sinh viên
* Xem chi tiết sinh viên
* Kiểm tra dữ liệu nhập bằng validation
* Sử dụng Layout chung cho các trang

---

## 2. Cấu trúc project

Project được chia thành các phần chính:

```text
Controllers
    StudentController.cs

Models
    Student.cs

Views
    Student
        Index.cshtml
        Create.cshtml
        Edit.cshtml
        Detail.cshtml
        Delete.cshtml

    Shared
        _Layout.cshtml
```

Trong đó:

* `Models/Student.cs`: định nghĩa đối tượng sinh viên.
* `Controllers/StudentController.cs`: xử lý các request từ người dùng.
* `Views/Student`: chứa các giao diện hiển thị dữ liệu sinh viên.
* `Views/Shared/_Layout.cshtml`: layout dùng chung cho toàn bộ trang web.

---

## 3. Luồng xử lý chung của mô hình MVC

Luồng xử lý trong ứng dụng MVC diễn ra như sau:

```text
Người dùng gửi request
        ↓
Routing xác định Controller và Action cần gọi
        ↓
Controller xử lý request
        ↓
Controller làm việc với Model hoặc dữ liệu trong List
        ↓
Controller trả dữ liệu sang View
        ↓
View dùng Razor để hiển thị HTML cho người dùng
```

Ví dụ khi người dùng truy cập trang danh sách sinh viên:

```text
Người dùng truy cập /Student/Index
        ↓
Routing gọi StudentController
        ↓
Action Index() được thực thi
        ↓
Controller lấy danh sách sinh viên từ List<Student>
        ↓
Controller truyền danh sách sang View Index.cshtml
        ↓
View hiển thị bảng danh sách sinh viên
```

---

## 4. Luồng chức năng hiển thị danh sách sinh viên

Khi người dùng vào trang danh sách sinh viên, hệ thống sẽ gọi action `Index()` trong `StudentController`.

Luồng xử lý:

```text
GET /Student/Index
        ↓
Gọi action Index()
        ↓
Lấy toàn bộ dữ liệu sinh viên từ List<Student>
        ↓
return View(students)
        ↓
Index.cshtml nhận Model là danh sách sinh viên
        ↓
Dùng vòng lặp foreach để hiển thị dữ liệu ra bảng
```

Chức năng này giúp người dùng xem toàn bộ sinh viên hiện có trong hệ thống.

---

## 5. Luồng chức năng xem chi tiết sinh viên

Khi người dùng bấm nút "Chi tiết", hệ thống sẽ truyền `id` của sinh viên lên Controller.

Luồng xử lý:

```text
GET /Student/Detail/{id}
        ↓
Gọi action Detail(int id)
        ↓
Tìm sinh viên trong List theo Id
        ↓
Nếu tìm thấy thì trả về View Detail.cshtml
        ↓
Nếu không tìm thấy thì trả về NotFound()
```

Trong action này, chương trình sử dụng `FirstOrDefault()` để tìm sinh viên có `Id` trùng với `id` được truyền vào.

---

## 6. Luồng chức năng thêm sinh viên

Chức năng thêm sinh viên gồm 2 bước: hiển thị form và xử lý dữ liệu sau khi submit.

### Bước 1: Hiển thị form thêm sinh viên

```text
GET /Student/Create
        ↓
Gọi action Create()
        ↓
return View()
        ↓
Hiển thị form thêm sinh viên
```

### Bước 2: Xử lý dữ liệu khi người dùng bấm lưu

```text
POST /Student/Create
        ↓
Gọi action Create(Student student)
        ↓
Kiểm tra ModelState.IsValid
        ↓
Nếu dữ liệu hợp lệ:
        - Tạo Id mới cho sinh viên
        - Thêm sinh viên vào List<Student>
        - Redirect về trang Index
        ↓
Nếu dữ liệu không hợp lệ:
        - Trả lại View Create
        - Hiển thị lỗi validation
```

`ModelState.IsValid` dùng để kiểm tra dữ liệu người dùng nhập có thỏa mãn các điều kiện validation trong Model hay không.

Ví dụ:

* Tên sinh viên không được để trống
* Email phải đúng định dạng
* Lớp không được để trống
* Điểm phải nằm trong khoảng từ 0 đến 10

---

## 7. Luồng chức năng sửa sinh viên

Chức năng sửa sinh viên cũng gồm 2 bước: hiển thị form sửa và cập nhật dữ liệu.

### Bước 1: Hiển thị form sửa

```text
GET /Student/Edit/{id}
        ↓
Gọi action Edit(int id)
        ↓
Tìm sinh viên theo Id
        ↓
Nếu tìm thấy thì truyền sinh viên sang View Edit.cshtml
        ↓
View hiển thị form có sẵn dữ liệu cũ
```

### Bước 2: Cập nhật dữ liệu sau khi submit

```text
POST /Student/Edit
        ↓
Gọi action Edit(Student student)
        ↓
Kiểm tra ModelState.IsValid
        ↓
Tìm sinh viên cũ trong List theo Id
        ↓
Cập nhật lại Name, Email, ClassName, Score
        ↓
Redirect về trang Index
```

Nếu dữ liệu nhập không hợp lệ, hệ thống sẽ trả lại View Edit để người dùng sửa lỗi.

---

## 8. Luồng chức năng xóa sinh viên

Chức năng xóa gồm 2 bước: hiển thị màn hình xác nhận và xử lý xóa.

### Bước 1: Hiển thị trang xác nhận xóa

```text
GET /Student/Delete/{id}
        ↓
Gọi action Delete(int id)
        ↓
Tìm sinh viên theo Id
        ↓
Nếu tìm thấy thì truyền sinh viên sang View Delete.cshtml
        ↓
Hiển thị thông tin sinh viên và hỏi người dùng có chắc chắn muốn xóa không
```

### Bước 2: Xóa sinh viên

```text
POST /Student/DeleteConfirmed
        ↓
Gọi action DeleteConfirmed(int id)
        ↓
Tìm sinh viên theo Id
        ↓
Xóa sinh viên khỏi List<Student>
        ↓
Redirect về trang Index
```

Sau khi xóa thành công, người dùng được chuyển về trang danh sách sinh viên.

---

## 9. Vai trò của Layout

File `_Layout.cshtml` được dùng để tạo giao diện chung cho toàn bộ website.

Layout chứa các phần dùng chung như:

* Thẻ HTML cơ bản
* Navbar
* Footer
* Link CSS Bootstrap
* Script JavaScript
* Vị trí hiển thị nội dung chính

Trong layout có đoạn:

```cshtml
@RenderBody()
```

Đây là vị trí để nội dung của từng View được hiển thị. Ví dụ khi mở `Index.cshtml`, nội dung của `Index.cshtml` sẽ được đưa vào vị trí `@RenderBody()` trong layout.

Ngoài ra layout còn có:

```cshtml
@await RenderSectionAsync("Scripts", required: false)
```

Đoạn này cho phép từng View khai báo thêm script riêng nếu cần. Ví dụ các trang `Create.cshtml` và `Edit.cshtml` có thể dùng section này để thêm script validation.

---

## 10. Vai trò của Razor View Engine

Razor View Engine cho phép viết code C# trực tiếp trong file `.cshtml`.

Ví dụ trong trang danh sách sinh viên, Razor được dùng để duyệt danh sách sinh viên:

```cshtml
@foreach (var student in Model)
{
    <tr>
        <td>@student.Id</td>
        <td>@student.Name</td>
        <td>@student.Email</td>
        <td>@student.ClassName</td>
        <td>@student.Score</td>
    </tr>
}
```

Nhờ Razor, View có thể hiển thị dữ liệu động được truyền từ Controller sang.

---

## 11. Kết luận

Ứng dụng quản lý sinh viên đã áp dụng mô hình MVC để tách rõ trách nhiệm giữa Model, View và Controller. Controller xử lý request và điều phối dữ liệu, Model mô tả đối tượng sinh viên, còn View hiển thị giao diện cho người dùng.

Ứng dụng đã hoàn thành các chức năng CRUD cơ bản gồm thêm, xem, sửa, xóa và hiển thị danh sách sinh viên. Dữ liệu được lưu tạm bằng `List<Student>`, phù hợp với yêu cầu bài tập chưa cần sử dụng database. Ngoài ra, ứng dụng còn sử dụng Razor View Engine, Layout dùng chung, `@RenderBody()`, `@RenderSection()` và validation cơ bản để kiểm tra dữ liệu nhập.
