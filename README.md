# Hệ Thống Quản Lý Bán Đồ Ăn Nhanh - POS Fast Food Management System (C# WinForms & SQL Server)

Phần mềm Quản lý Bán Đồ Ăn Nhanh tại quầy (Point of Sale - POS) với giao diện người dùng hiện đại thiết kế bằng **Guna.UI2**, tích hợp **Entity Framework 6** và hệ quản trị cơ sở dữ liệu **Microsoft SQL Server**.

---

## 📌 Tính Năng Chính Của Hệ Thống

### 1. Màn Hình Bán Hàng Tại Quầy (POS Terminal)
- **Menu trực quan theo danh mục**: Phân loại theo Combo, Burger, Món mặn (Foods), Đồ uống (Drinks), Tráng miệng (Desserts), Đồ ăn vặt (Snacks).
- **Thẻ món ăn sinh động**: Hiển thị ảnh đại diện sắc nét, tên món ăn và giá bán.
- **Giỏ hàng thời gian thực (`Cart`)**:
  - Thêm / bớt / xóa món ăn nhanh chóng.
  - Tự động tính toán tổng tiền, áp dụng thuế và chiết khấu.
  - Thanh toán và lưu hóa đơn (`Order`, `OrderDetail`) vào hệ thống.

### 2. Quản Lý Thực Đơn & Sản Phẩm
- Thêm mới món ăn (`frmAddItem`), chỉnh sửa thông tin món (`frmEditItem`), xem chi tiết (`frmItemDetail`).
- Quản lý phân loại sản phẩm (`TypeProduct`) và trạng thái kinh doanh của từng mặt hàng.

### 3. Quản Lý Nhân Viên & Bảo Mật
- Đăng nhập hệ thống bảo mật (`frmlogin`), đổi mật khẩu (`frmChangePass`).
- Quản lý danh sách nhân viên (`Employee`) và phân quyền vai trò (`RoleEmployee` - Quản lý, Thu ngân, Phục vụ).

---

## 🛠️ Công Nghệ Sử Dụng
- **Ngôn ngữ**: C# (.NET Framework 4.7.2)
- **Giao diện**: Windows Forms kết hợp bộ thư viện hiện đại **Guna.UI2.WinForms**
- **ORM**: Entity Framework 6 (Database First)
- **Cơ sở dữ liệu**: Microsoft SQL Server
- **Database Script**: File script khởi tạo dữ liệu `PosFastFoods.sql` đi kèm sẵn

---

## 📂 Cấu Trúc Dự Án
```
fast-food-pos-management/
├── Data/                        # Hình ảnh thực đơn (Combo, Dessert, Drinks, Foods, Snack)
├── QLBanDoAnNhanh/
│   ├── Models/                  # Entity Framework Data Models
│   │   ├── Employee.cs
│   │   ├── Order.cs
│   │   ├── OrderDetail.cs
│   │   ├── Product.cs
│   │   ├── RoleEmployee.cs
│   │   └── TypeProduct.cs
│   ├── frmMain.cs               # Giao diện chính POS bán hàng
│   ├── Cart.cs                  # Giỏ hàng & thanh toán
│   ├── frmlogin.cs              # Đăng nhập hệ thống
│   ├── frmAddItem.cs            # Thêm mới món ăn
│   ├── frmEditItem.cs           # Sửa thông tin món
│   └── App.config               # Cấu hình chuỗi kết nối Database
├── packages/                    # Gói thư viện Guna.UI2 và Entity Framework
├── PosFastFoods.sql             # Script khởi tạo Database SQL Server
└── QLBanDoAnNhanh.sln           # Visual Studio Solution
```

---

## 🚀 Hướng Dẫn Cài Đặt & Chạy Phần Mềm

### 1. Khởi tạo Cơ sở dữ liệu
1. Mở **SQL Server Management Studio (SSMS)**.
2. Mở file `PosFastFoods.sql` và nhấn **Execute** để tạo cơ sở dữ liệu `PosFastFoods` cùng toàn bộ bảng và dữ liệu mẫu.

### 2. Cấu hình Connection String
Mở file `QLBanDoAnNhanh/App.config` và điều chỉnh `connectionString` phù hợp với thông tin SQL Server trên máy tính của bạn:
```xml
<connectionStrings>
    <add name="PosFastFood" connectionString="data source=YOUR_SERVER_NAME;initial catalog=PosFastFoods;integrated security=True;..." />
</connectionStrings>
```

### 3. Khởi chạy ứng dụng
1. Mở file `QLBanDoAnNhanh.sln` bằng **Visual Studio 2019/2022**.
2. Nhấn **F5** để bắt đầu sử dụng phần mềm.
