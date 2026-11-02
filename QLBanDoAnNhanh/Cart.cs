using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLBanDoAnNhanh.Models; // Namespace chứa Model Product, Order...

namespace QLBanDoAnNhanh
{
    public partial class Cart : Form
    {
        // 1. Biến lưu dữ liệu
        private List<CartItem> _cartItems;
        private int _idEmployee;

        // 2. Constructor
        public Cart(List<CartItem> items, int idEmployee)
        {
            InitializeComponent();
            _cartItems = items;
            _idEmployee = idEmployee;
            LoadDataToGrid();
        }

        // 3. Load Form
        private void Cart_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        // 4. Hiển thị dữ liệu
        private void LoadDataToGrid()
        {
            dgvCart.Rows.Clear();

            foreach (var item in _cartItems)
            {
                int index = dgvCart.Rows.Add();

                dgvCart.Rows[index].Cells[0].Value = item.ProductName;
                dgvCart.Rows[index].Cells[1].Value = item.Quantity;
                dgvCart.Rows[index].Cells[2].Value = item.Price.ToString("0.00") + " VND";
                dgvCart.Rows[index].Cells[3].Value = item.Total.ToString("0.00") + " VND";

                // Lưu item gốc để xóa
                dgvCart.Rows[index].Tag = item;
            }

            UpdateTotalMoney();
        }

        private void UpdateTotalMoney()
        {
            decimal total = _cartItems.Sum(x => x.Total);

            // Nếu muốn tính thuế, bỏ comment dòng dưới
            // total = total + (total * 0.05m); 

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
            lblTongTienValue.Text = total.ToString("0.00") + " VND";
        }

        

        // Nút quay lại
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 5. Nút Xóa Món
       

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!");
                return;
            }

            // --- ĐÃ SỬA: Dùng đúng tên PosFastFood như trong frmAddItem ---
            using (var db = new PosFastFood())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // A. Tạo Hóa Đơn
                        Order order = new Order();
                        order.CreateDate = DateTime.Now;
                        order.IdEmployee = _idEmployee;
                        order.Total = _cartItems.Sum(x => x.Total); // Cộng thêm thuế ở đây nếu cần

                        // B. Tạo Chi Tiết Hóa Đơn
                        foreach (var item in _cartItems)
                        {
                            OrderDetail detail = new OrderDetail();
                            detail.IdProduct = item.ProductId;
                            detail.quantity = item.Quantity;

                            // Thêm chi tiết vào hóa đơn
                            order.OrderDetails.Add(detail);
                        }

                        // C. Lưu vào Database
                        db.Orders.Add(order);
                        db.SaveChanges(); // Lưu cả Order và OrderDetails cùng lúc

                        trans.Commit(); // Xác nhận giao dịch thành công

                        MessageBox.Show("Thanh toán thành công! Mã hóa đơn: " + order.IdOrder);

                        // Đóng form và trả về kết quả OK
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(); // Gặp lỗi thì quay lui, không lưu gì cả
                        MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                    }
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                CartItem item = dgvCart.CurrentRow.Tag as CartItem;
                _cartItems.Remove(item);                 // Xóa khỏi List
                dgvCart.Rows.Remove(dgvCart.CurrentRow); // Xóa khỏi Grid
                UpdateTotalMoney();                      // Tính lại tiền
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!");
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTienValue_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTienText_Click(object sender, EventArgs e)
        {

        }

        // 6. Nút Thanh Toán (QUAN TRỌNG NHẤT)

    }
}