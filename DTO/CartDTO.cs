﻿namespace Project.DTO {
    public class CartDTO {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public short? Quantity { get; set; }

        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
