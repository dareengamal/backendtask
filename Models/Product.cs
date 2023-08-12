using System.ComponentModel.DataAnnotations;

using System;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required and must be at least 3 characters long.")]
    [MinLength(3)]
    public string Name { get; set; }

    [MaxLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Product price is required and must be at least 0.01.")]
    [Range(0.01, Double.MaxValue)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock quantity is required and must be a non-negative value.")]
    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    public DateTime CreatedDate { get; set; }
}
