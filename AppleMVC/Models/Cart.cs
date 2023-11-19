using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppleMVC.Models
{
    public class CartItem
    {
        public ProductDetail _product { get ; set; }
        public int _quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        //Lấy sản phẩm bỏ vào giỏ hàng
        public void Add_Product_Cart(ProductDetail _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ProductDetailID == _pro.ProductDetailID);
            if (item == null) //nếu giỏ hàng rỗng thì thêm dòng hàng mới vào giỏ
                items.Add(new CartItem
                {
                    _product = _pro,
                    _quantity = _quan,
                });
            else
                item._quantity += _quan;
        }

        //Tính tổng số lượng trong giỏ hàng
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }

        //Tính thành tiền cho mỗi dòng trong sản phẩm
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.Price);
            return (decimal)total;
        }

        //Cập nhật số lượng sản phẩm khi KH muốn đặt thêm
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ProductDetailID == id);
            if (item != null)
                item._quantity = _new_quan;
        }

        //Xóa sản phẩm trong giỏ hàng
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ProductDetailID == id);
        }

        //Xóa giỏ hàng khi KH thanh toán
        public void ClearCart()
        {
            items.Clear();
        }

        public IEnumerable<CartItem> GetItemsByCategory(string CategoryName)
        {
            return items.Where(s => s._product.Product.Category.CategoryName == CategoryName);
        }

    }
}