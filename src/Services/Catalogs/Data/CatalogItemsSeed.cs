namespace LinkEcommerce.Services.Catalogs.Data;

public class CatalogItemsSeed
{
    public IEnumerable<CatalogItem> GetCatalogItems()
    {
        var createdBy = Guid.NewGuid();
        var state = true;


        return [
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Fanta Naranja 2.5L",
                Price = 4500,
                Description = "Fanta Naranja 2.5 Litros",
                State = true,
                MaxItemsInStock = 100,
                AvailableQuantity = 1,
                PictureBase64 = string.Empty,
                
                
            },
        ];
    }
}