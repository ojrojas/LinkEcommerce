namespace LinkEcommerce.Services.Catalogs.Data;

public static class CatalogItemsSeed
{
    public static IEnumerable<CatalogItem> GetCatalogItems()
    {
        Console.WriteLine("CRREEEEATE CATALOGS ITEMS");
        var createdBy = Guid.NewGuid();
        var state = true;
        Guid menSClothingType = Guid.NewGuid();
        Guid JeweryType = Guid.NewGuid();
        Guid electronicsType = Guid.NewGuid();
        Guid womensClothingType = Guid.NewGuid();

        Guid menSClothingBrand = Guid.NewGuid();
        Guid JeweryBrand = Guid.NewGuid();
        Guid electronicsBrand = Guid.NewGuid();
        Guid womensClothingBrand = Guid.NewGuid();

        var mensClothing = new CatalogType
        {
            Name = "men's clothing",
            Id = menSClothingType,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };

        var jewelery = new CatalogType
        {
            Name = "jewelery",
            Id = JeweryType,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };
        var electronics = new CatalogType
        {
            Name = "electronics",
            Id = electronicsType,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };
        var womensClothing = new CatalogType
        {
            Name = "womens clothing",
            Id = womensClothingType,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };

        /// 

        var menSClothingBrand1 = new CatalogBrand
        {
            Name = "XCFI",
            Id = menSClothingBrand,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };

        var JeweryBrand1 = new CatalogBrand
        {
            Name = "TOPAC",
            Id = JeweryBrand,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };
        var electroniscBrand1 = new CatalogBrand
        {
            Name = "ELECT",
            Id = electronicsBrand,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };
        var womensClothingBrand1 = new CatalogBrand
        {
            Name = "womens clothing",
            Id = womensClothingBrand,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            State = state
        };


        return [
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                Price = 109000,
                Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                State = true,
                CatalogType = mensClothing,
                CatalogBrand = menSClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg"
            },
            new() {
                Id = Guid.NewGuid(),
                Name =  "Mens Casual Premium Slim Fit T-Shirts",
                Price = 22000,
                Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                State = true,
                CatalogType = mensClothing,
                CatalogBrand = menSClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name =      "Mens Cotton Jacket",
                Price = 150000,
                Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
                State = true,
                 CatalogType = mensClothing,
                CatalogBrand = menSClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =          "Mens Cotton Jacket",
                Price = 109000,
                Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
                State = true,
                 CatalogType = mensClothing,
                CatalogBrand = menSClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name =              "Mens Casual Slim Fit",
                Price = 665000,
                Description =       "The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
                State = true,
                  CatalogType = mensClothing,
                CatalogBrand = menSClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name =              "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
                Price = 665000,
                Description =           "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
                State = true,
                CatalogType =jewelery,
                CatalogBrand = JeweryBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =     "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =              "Solid Gold Petite Micropave ",
                Price = 665000,
                Description =           "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.",
                State = true,
                CatalogType =jewelery,
                CatalogBrand = JeweryBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =         "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =              "White Gold Plated Princess",
                Price = 665000,
                Description =           "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...",
                State = true,
                CatalogType =jewelery,
                CatalogBrand = JeweryBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =         "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =              "Pierced Owl Rose Gold Plated Stainless Steel Double",
                Price = 665000,
                Description =           "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel",
                State = true,
                 CatalogType =jewelery,
                CatalogBrand = JeweryBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =         "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name =              "WD 2TB Elements Portable External Hard Drive - USB 3.0 ",
                Price = 665000,
                Description =           "USB 3.0 and USB 2.0 Compatibility Fast data transfers Improve PC Performance High Capacity; Compatibility Formatted NTFS for Windows 10, Windows 8.1, Windows 7; Reformatting may be required for other operating systems; Compatibility may vary depending on user’s hardware configuration and operating system",
                State = true,
                CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =             "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =            "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
                Price = 665000,
                Description =           "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive; Based on published specifications and internal benchmarking tests using PCMark vantage scores) Boosts burst write performance, making it ideal for typical PC workloads The perfect balance of performance and reliability Read/write speeds of up to 535MB/s/450MB/s (Based on internal testing; Performance may vary depending upon drive capacity, host device, OS and application.)",
                State = true,
               CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 =                 "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name =          "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5",
                Price = 665000,
                Description = "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. The advanced SLC Cache Technology allows performance boost and longer lifespan 7mm slim design suitable for Ultrabooks and Ultra-slim notebooks. Supports TRIM command, Garbage Collection technology, RAID, and ECC (Error Checking & Correction) to provide the optimized performance and enhanced reliability.",
                State = true,
               CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name = "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive",
                Price = 665000,
                Description = "Expand your PS4 gaming experience, Play anywhere Fast and easy, setup Sleek design with high capacity, 3-year manufacturer's limited warranty",
                State = true,
                CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name =          "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin",
                Price = 665000,
                Description =   "21. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. No compatibility for VESA Mount Refresh Rate: 75Hz - Using HDMI port Zero-frame design | ultra-thin | 4ms response time | IPS panel Aspect ratio - 16: 9. Color Supported - 16. 7 million colors. Brightness - 250 nit Tilt angle -5 degree to 15 degree. Horizontal viewing angle-178 degree. Vertical viewing angle-178 degree 75 hertz",
                State = true,
                CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg"
            },
             new() {
                Id = Guid.NewGuid(),
                Name = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED ",
                Price = 665000,
                Description = "49 INCH SUPER ULTRAWIDE 32:9 CURVED GAMING MONITOR with dual 27 inch screen side by side QUANTUM DOT (QLED) TECHNOLOGY, HDR support and factory calibration provides stunningly realistic and accurate color and contrast 144HZ HIGH REFRESH RATE and 1ms ultra fast response time work to eliminate motion blur, ghosting, and reduce input lag",
                State = true,
                CatalogType = electronics,
                CatalogBrand =electroniscBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/81Zt42ioCgL._AC_SX679_.jpg"
            },
               new() {
                Id = Guid.NewGuid(),
                Name = "BIYLACLESEN Women's 3-in-1 Snowboard Jacket Winter Coats",
                Price = 665000,
                Description = "Note:The Jackets is US standard size, Please choose size as your usual wear Material: 100% Polyester; Detachable Liner Fabric: Warm Fleece. Detachable Functional Liner: Skin Friendly, Lightweigt and Warm.Stand Collar Liner jacket, keep you warm in cold weather. Zippered Pockets: 2 Zippered Hand Pockets, 2 Zippered Pockets on Chest (enough to keep cards or keys)and 1 Hidden Pocket Inside.Zippered Hand Pockets and Hidden Pocket keep your things secure. Humanized Design: Adjustable and Detachable Hood and Adjustable cuff to prevent the wind and water,for a comfortable fit. 3 in 1 Detachable Design provide more convenience, you can separate the coat and inner as needed, or wear it together. It is suitable for different season and help you adapt to different climates",
                State = true,
                CatalogType =womensClothing,
                CatalogBrand = womensClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg"
            },
               new() {
                Id = Guid.NewGuid(),
                Name = "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket",
                Price = 665000,
                Description = "100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER), Faux leather material for style and comfort / 2 pockets of front, 2-For-One Hooded denim style faux leather jacket, Button detail on waist / Detail stitching at sides, HAND WASH ONLY / DO NOT BLEACH / LINE DRY / DO NOT IRON",
                State = true,
                CatalogType =womensClothing,
                CatalogBrand = womensClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/51Y5NI-I5jL._AC_UX679_.jpg"
            },
              new() {
                Id = Guid.NewGuid(),
                Name = "Rain Jacket Women Windbreaker Striped Climbing Raincoats",
                Price = 665000,
                Description = "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. Button and zipper front closure raincoat, fully stripes Lined and The Raincoat has 2 side pockets are a good size to hold all kinds of things, it covers the hips, and the hood is generous but doesn't overdo it.Attached Cotton Lined Hood with Adjustable Drawstrings give it a real styled look.",
                State = true,
                CatalogType =womensClothing,
                CatalogBrand = womensClothingBrand1,
                MaxItemsInStock = 100,
                AvailableQuantity = 100,
                PictureBase64 = "https://fakestoreapi.com/img/71HblAHs5xL._AC_UY879_-2.jpg"
            },
        ];
    }
}
