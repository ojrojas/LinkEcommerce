using System.ComponentModel.DataAnnotations;

namespace LinkEcommerce.Services.Basket.Models;

public class BasketCatalogItem: BaseEntity
{
    public int CatalogItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureBase64 { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Quantity < 1)
        {
            results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
        }

        return results;
    }
}