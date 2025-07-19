using System;

namespace Lab_3.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }

        public string Name { get; set; } = null!;

        public decimal UnitPrice { get; set; }     // Giá đang bán

        public decimal? OriginalPrice { get; set; } // Giá gốc (có thể null)

        public string? ImageUrl { get; set; }       // Đường dẫn ảnh sản phẩm

        // Các trường khác nếu bạn vẫn muốn giữ
        public string? Category { get; set; }

        public string? Color { get; set; }

        public long AvailableQuantity { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
