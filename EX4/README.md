## Luồng hoạt động của chương trình

Dự án được xây dựng theo mô hình MVC gồm ba thành phần chính: Model, View và Controller. Người dùng thao tác trên giao diện View, yêu cầu sẽ được gửi đến Controller để xử lý. Controller có nhiệm vụ nhận request, xử lý dữ liệu thông qua Model nếu cần, sau đó trả kết quả về View để hiển thị cho người dùng.

### 1. Luồng trang chủ

Khi người dùng truy cập vào website, hệ thống sẽ gọi đến `HomeController`.

* Người dùng truy cập trang chủ.
* Request được gửi đến action `Index`.
* Action `Index` trả về View tương ứng.
* Giao diện trang chủ được hiển thị cho người dùng.

Ngoài ra, người dùng có thể truy cập trang `Privacy`. Khi có lỗi xảy ra trong hệ thống, action `Error` sẽ được sử dụng để hiển thị thông tin lỗi.

### 2. Luồng đăng nhập

Chức năng đăng nhập được xử lý bởi `AccountController`.

Khi người dùng mở trang đăng nhập:

* Người dùng truy cập đường dẫn `/Account/Login`.
* Phương thức `Login` với `[HttpGet]` được gọi.
* Controller trả về giao diện form đăng nhập.
* Người dùng nhập tên đăng nhập và mật khẩu.

Khi người dùng bấm nút đăng nhập:

* Form gửi dữ liệu lên server bằng phương thức POST.
* Phương thức `Login` với `[HttpPost]` được gọi.
* Hệ thống kiểm tra tên đăng nhập và mật khẩu.
* Nếu người dùng bỏ trống tên đăng nhập hoặc mật khẩu, hệ thống hiển thị thông báo lỗi.
* Nếu người dùng nhập đầy đủ thông tin, hệ thống hiển thị thông báo đăng nhập thành công.

Chức năng đăng nhập hiện tại chỉ kiểm tra dữ liệu nhập vào có đầy đủ hay không, chưa thực hiện xác thực tài khoản bằng cơ sở dữ liệu.

### 3. Luồng hiển thị danh sách sách

Chức năng quản lý sách được xử lý bởi `BookController`.

Khi người dùng truy cập danh sách sách:

* Người dùng truy cập đường dẫn `/Book/Index`.
* Action `Index` trong `BookController` được gọi.
* Controller lấy danh sách sách từ biến `static List<Book>`.
* Danh sách sách được truyền sang View.
* View hiển thị danh sách sách gồm mã sách, tên sách và giá sách.

Dữ liệu sách hiện đang được lưu tạm trong bộ nhớ bằng `static List<Book>`, chưa sử dụng database.

### 4. Luồng xem chi tiết sách

Khi người dùng muốn xem thông tin chi tiết của một cuốn sách:

* Người dùng chọn một sách trong danh sách.
* Hệ thống gửi request đến đường dẫn `/Book/Detail/{id}`.
* Action `Detail` nhận vào tham số `id`.
* Controller tìm sách có `id` tương ứng trong danh sách.
* Nếu tìm thấy sách, hệ thống trả về View chi tiết sách.
* Nếu không tìm thấy sách, hệ thống trả về lỗi `NotFound`.

Luồng này giúp người dùng xem thông tin cụ thể của từng cuốn sách trong hệ thống.

### 5. Luồng thêm sách mới

Khi người dùng muốn thêm sách mới:

* Người dùng truy cập đường dẫn `/Book/Create`.
* Action `Create` với `[HttpGet]` được gọi.
* Controller trả về giao diện form thêm sách.
* Người dùng nhập tên sách và giá sách.
* Người dùng bấm nút thêm sách.
* Form gửi dữ liệu lên server bằng phương thức POST.
* Action `Create` với `[HttpPost]` được gọi.
* Controller kiểm tra dữ liệu bằng `ModelState.IsValid`.

Nếu dữ liệu không hợp lệ:

* Hệ thống trả lại form thêm sách.
* Các thông báo lỗi validation được hiển thị cho người dùng.
* Người dùng sửa lại thông tin và gửi lại form.

Nếu dữ liệu hợp lệ:

* Controller tìm `id` lớn nhất hiện có trong danh sách sách.
* Sách mới được gán `id` mới bằng `maxId + 1`.
* Sách mới được thêm vào danh sách.
* Hệ thống hiển thị thông báo thêm sách thành công.

### 6. Luồng kiểm tra dữ liệu sách

Model `Book` sử dụng Data Annotations để kiểm tra dữ liệu đầu vào.

Các điều kiện kiểm tra gồm:

* Tên sách không được để trống.
* Giá sách không được để trống.
* Giá sách phải lớn hơn 0.

Khi người dùng nhập sai dữ liệu ở form thêm sách, hệ thống sẽ không thêm sách mới mà hiển thị thông báo lỗi để người dùng nhập lại.

### 7. Tóm tắt luồng tổng quát

Luồng hoạt động tổng quát của chương trình như sau:

```text
Người dùng thao tác trên giao diện
        ↓
View gửi request đến Controller
        ↓
Controller nhận và xử lý request
        ↓
Controller làm việc với Model nếu cần
        ↓
Controller trả dữ liệu về View
        ↓
View hiển thị kết quả cho người dùng
```

Đối với chức năng quản lý sách:

```text
Người dùng vào trang danh sách sách
        ↓
BookController gọi action Index
        ↓
Lấy danh sách sách từ List<Book>
        ↓
Trả dữ liệu sang View
        ↓
Hiển thị danh sách sách
```

Đối với chức năng thêm sách:

```text
Người dùng mở form thêm sách
        ↓
Nhập tên sách và giá sách
        ↓
Gửi form lên BookController
        ↓
Kiểm tra dữ liệu bằng ModelState
        ↓
Nếu sai thì hiển thị lỗi
        ↓
Nếu đúng thì thêm sách vào danh sách
        ↓
Hiển thị thông báo thành công
```

Đối với chức năng đăng nhập:

```text
Người dùng mở form đăng nhập
        ↓
Nhập tên đăng nhập và mật khẩu
        ↓
Gửi form lên AccountController
        ↓
Kiểm tra dữ liệu nhập vào
        ↓
Nếu thiếu thông tin thì báo lỗi
        ↓
Nếu nhập đầy đủ thì báo đăng nhập thành công
```
