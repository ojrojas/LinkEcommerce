
namespace LinkEcommerce.Services.Catalogs.Data;

public class CatalogItemsSeed
{
    public IEnumerable<CatalogItem> GetCatalogItems()
    {
        return [
            new()
            {
                Id = Guid.NewGuid(),
                Name = ""
            },
        ];
    }
}

// {
//   "asin": "B07N4M94X4",
//   "attributes": {
//     "total_hdmi_ports": [
//       {
//         "value": 4,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "resolution": [
//       {
//         "language_tag": "en_US",
//         "value": "4K",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_weight": [
//       {
//         "unit": "pounds",
//         "value": 107.6,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "product_subcategory": [
//       {
//         "value": "50400120",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "bullet_point": [
//       {
//         "language_tag": "en_US",
//         "value": "SMART TV WITH UNIVERSAL GUIDE: Simple on-screen Guide is an easy way to find streaming content and live TV shows",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "100% COLOR VOLUME WITH QUANTUM DOTS: Powered by Quantum dots, Samsung’s 4K QLED TV offers over a billion shades of brilliant color and 100% color volume for exceptional depth of detail that will draw you in to the picture for the best 4K TV experience",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "QUANTUM PROCESSOR 4K: Intelligently powered processor instantly upscales content to 4K for sharp detail and refined color",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "QUANTUM HDR 4X: 4K depth of detail with high dynamic range powered by HDR10+ delivers the lightest to darkest colors, scene by scene, for amazing picture realism",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "AMBIENT MODE: Customizes and complements your living space by turning a blank screen of this big screen TV into enticing visuals including décor, info, photos and artwork",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "SMART TV FEATURES: OneRemote to control all compatible devices, Bixby voice command, on-screen universal guide, SmartThings to control compatible home appliances and devices, smart speaker expandability with Alexa and Google Assistant compatibility, and more",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_dimensions": [
//       {
//         "width": {
//           "unit": "inches",
//           "value": 72.4
//         },
//         "length": {
//           "unit": "inches",
//           "value": 2.4
//         },
//         "height": {
//           "unit": "inches",
//           "value": 41.4
//         },
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "brand": [
//       {
//         "language_tag": "en_US",
//         "value": "SAMSUNG",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "control_method": [
//       {
//         "value": "voice",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_package_dimensions": [
//       {
//         "length": {
//           "unit": "centimeters",
//           "value": 26.67
//         },
//         "width": {
//           "unit": "centimeters",
//           "value": 121.92
//         },
//         "height": {
//           "unit": "centimeters",
//           "value": 203.2
//         },
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "image_aspect_ratio": [
//       {
//         "language_tag": "en_US",
//         "value": "16:9",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "part_number": [
//       {
//         "value": "QN82Q60RAFXZA",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "includes_remote": [
//       {
//         "value": true,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "style": [
//       {
//         "language_tag": "en_US",
//         "value": "TV only",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_type_name": [
//       {
//         "language_tag": "en_US",
//         "value": "TV",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "battery": [
//       {
//         "cell_composition": [
//           {
//             "value": "alkaline"
//           }
//         ],
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "image_contrast_ratio": [
//       {
//         "language_tag": "en_US",
//         "value": "QLED 4K",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "manufacturer": [
//       {
//         "language_tag": "en_US",
//         "value": "Samsung",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "number_of_boxes": [
//       {
//         "value": 1,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "total_usb_ports": [
//       {
//         "value": 2,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "model_number": [
//       {
//         "value": "QN82Q60RAFXZA",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "supplier_declared_dg_hz_regulation": [
//       {
//         "value": "not_applicable",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "num_batteries": [
//       {
//         "quantity": 2,
//         "type": "aaa",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "california_proposition_65": [
//       {
//         "compliance_type": "on_product_combined_cancer_reproductive",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "compliance_type": "chemical",
//         "chemical_names": [
//           "di_2_ethylhexyl_phthalate_dehp"
//         ],
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "display": [
//       {
//         "resolution_maximum": [
//           {
//             "unit": "pixels",
//             "language_tag": "en_US",
//             "value": "3840 x 2160"
//           }
//         ],
//         "size": [
//           {
//             "unit": "inches",
//             "value": 82
//           }
//         ],
//         "type": [
//           {
//             "language_tag": "en_US",
//             "value": "QLED"
//           }
//         ],
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_name": [
//       {
//         "language_tag": "en_US",
//         "value": "Samsung QN82Q60RAFXZA Flat 82-Inch QLED 4K Q60 Series (2019) Ultra HD Smart TV with HDR and Alexa Compatibility",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "list_price": [
//       {
//         "currency": "USD",
//         "value": 3799.99,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "batteries_required": [
//       {
//         "value": false,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "includes_rechargable_battery": [
//       {
//         "value": false,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "product_site_launch_date": [
//       {
//         "value": "2019-03-11T08:00:01.000Z",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "product_category": [
//       {
//         "value": "50400100",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "batteries_included": [
//       {
//         "value": false,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "connectivity_technology": [
//       {
//         "language_tag": "en_US",
//         "value": "Bluetooth",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "USB",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Wireless",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "HDMI",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "included_components": [
//       {
//         "language_tag": "en_US",
//         "value": "QLED Standard Smart Remote",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Power Cable",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Stand",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Samsung Smart Control",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "specification_met": [
//       {
//         "language_tag": "en_US",
//         "value": "",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "parental_control_technology": [
//       {
//         "value": "V-Chip",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "power_consumption": [
//       {
//         "unit": "watts",
//         "value": 120,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "cpsia_cautionary_statement": [
//       {
//         "value": "no_warning_applicable",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_type_keyword": [
//       {
//         "value": "qled-televisions",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "number_of_items": [
//       {
//         "value": 1,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "warranty_description": [
//       {
//         "language_tag": "en_US",
//         "value": "1 year manufacturer",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "max_resolution": [
//       {
//         "unit": "pixels",
//         "value": 8.3,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "color": [
//       {
//         "language_tag": "en_US",
//         "value": "Black",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "screen_surface_description": [
//       {
//         "language_tag": "en_US",
//         "value": "Flat",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "item_package_weight": [
//       {
//         "unit": "kilograms",
//         "value": 62.142,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "speaker_type": [
//       {
//         "language_tag": "en_US",
//         "value": "2CH",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "supported_internet_services": [
//       {
//         "language_tag": "en_US",
//         "value": "Amazon Instant Video",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "YouTube",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Netflix",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Hulu",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Browser",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "tuner_technology": [
//       {
//         "language_tag": "en_US",
//         "value": "Analog Tuner",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "controller_type": [
//       {
//         "language_tag": "en_US",
//         "value": "SmartThings",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Voice Control",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "special_feature": [
//       {
//         "language_tag": "en_US",
//         "value": "100% Color Volume with Quantum Dot; Quantum Processor 4K; Ambient Mode; Quantum HDR 4X; Real Game Enhancer",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "wireless_communication_technology": [
//       {
//         "language_tag": "en_US",
//         "value": "Wi-Fi::Wi-Fi Direct::Bluetooth",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "model_year": [
//       {
//         "value": 2019,
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "power_source_type": [
//       {
//         "language_tag": "en_US",
//         "value": "Corded Electric",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "street_date": [
//       {
//         "value": "2019-03-21T00:00:01Z",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "mounting_type": [
//       {
//         "language_tag": "en_US",
//         "value": "Table Mount",
//         "marketplace_id": "ATVPDKIKX0DER"
//       },
//       {
//         "language_tag": "en_US",
//         "value": "Wall Mount",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ],
//     "refresh_rate": [
//       {
//         "unit": "hertz",
//         "language_tag": "en_US",
//         "value": "120",
//         "marketplace_id": "ATVPDKIKX0DER"
//       }
//     ]
//   },
//   "classifications": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "classifications": [
//         {
//           "displayName": "QLED TVs",
//           "classificationId": "21489946011",
//           "parent": {
//             "displayName": "Televisions",
//             "classificationId": "172659",
//             "parent": {
//               "displayName": "Television & Video",
//               "classificationId": "1266092011",
//               "parent": {
//                 "displayName": "Electronics",
//                 "classificationId": "172282"
//               }
//             }
//           }
//         }
//       ]
//     }
//   ],  
//   "dimensions": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "item": {
//         "height": {
//           "unit": "inches",
//           "value": 41.4
//         },
//         "length": {
//           "unit": "inches",
//           "value": 2.4
//         },
//         "weight": {
//           "unit": "pounds",
//           "value": 107.6
//         },
//         "width": {
//           "unit": "inches",
//           "value": 72.4
//         }
//       },
//       "package": {
//         "height": {
//           "unit": "inches",
//           "value": 10.49999998929
//         },
//         "length": {
//           "unit": "inches",
//           "value": 79.9999999184
//         },
//         "weight": {
//           "unit": "kilograms",
//           "value": 62.142
//         },
//         "width": {
//           "unit": "inches",
//           "value": 47.99999995104
//         }
//       }
//     }
//   ],
//   "identifiers": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "identifiers": [
//         {
//           "identifier": "0887276302195",
//           "identifierType": "EAN"
//         },
//         {
//           "identifier": "00887276302195",
//           "identifierType": "GTIN"
//         },
//         {
//           "identifier": "887276302195",
//           "identifierType": "UPC"
//         }
//       ]
//     }
//   ],
//   "images": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "images": [
//         {
//           "variant": "MAIN",
//           "link": "https://m.media-amazon.com/images/I/91uohwV+k3L.jpg",
//           "height": 1707,
//           "width": 2560
//         },
//         {
//           "variant": "MAIN",
//           "link": "https://m.media-amazon.com/images/I/51DZzp3w3vL.jpg",
//           "height": 333,
//           "width": 500
//         },
//         {
//           "variant": "PT01",
//           "link": "https://m.media-amazon.com/images/I/81w2rTVShlL.jpg",
//           "height": 2560,
//           "width": 2560
//         },
//         {
//           "variant": "PT01",
//           "link": "https://m.media-amazon.com/images/I/41Px9eq9tkL.jpg",
//           "height": 500,
//           "width": 500
//         },
//         {
//           "variant": "PT02",
//           "link": "https://m.media-amazon.com/images/I/51NTNhdhPyL.jpg",
//           "height": 375,
//           "width": 500
//         },
//         {
//           "variant": "PT03",
//           "link": "https://m.media-amazon.com/images/I/51o4zpL+A3L.jpg",
//           "height": 375,
//           "width": 500
//         },
//         {
//           "variant": "PT04",
//           "link": "https://m.media-amazon.com/images/I/71ux2k9GAZL.jpg",
//           "height": 1000,
//           "width": 1000
//         },
//         {
//           "variant": "PT04",
//           "link": "https://m.media-amazon.com/images/I/61UUX63yw1L.jpg",
//           "height": 500,
//           "width": 500
//         },
//         {
//           "variant": "PT05",
//           "link": "https://m.media-amazon.com/images/I/61LwHkljX-L.jpg",
//           "height": 1000,
//           "width": 1000
//         },
//         {
//           "variant": "PT05",
//           "link": "https://m.media-amazon.com/images/I/51wJTQty3PL.jpg",
//           "height": 500,
//           "width": 500
//         },
//         {
//           "variant": "PT06",
//           "link": "https://m.media-amazon.com/images/I/61uvoB4VvoL.jpg",
//           "height": 1000,
//           "width": 1000
//         },
//         {
//           "variant": "PT06",
//           "link": "https://m.media-amazon.com/images/I/51ZexIO628L.jpg",
//           "height": 500,
//           "width": 500
//         },
//         {
//           "variant": "PT07",
//           "link": "https://m.media-amazon.com/images/I/7121MGd2ncL.jpg",
//           "height": 1000,
//           "width": 1000
//         },
//         {
//           "variant": "PT07",
//           "link": "https://m.media-amazon.com/images/I/61QK+JBMrGL.jpg",
//           "height": 500,
//           "width": 500
//         },
//         {
//           "variant": "PT08",
//           "link": "https://m.media-amazon.com/images/I/61ECcGlG4IL.jpg",
//           "height": 1080,
//           "width": 1920
//         },
//         {
//           "variant": "PT08",
//           "link": "https://m.media-amazon.com/images/I/31TxwfqvB5L.jpg",
//           "height": 281,
//           "width": 500
//         },
//         {
//           "variant": "PT09",
//           "link": "https://m.media-amazon.com/images/I/41B5vgmp4IL.jpg",
//           "height": 375,
//           "width": 500
//         },
//         {
//           "variant": "PT10",
//           "link": "https://m.media-amazon.com/images/I/51S5IY3AV0L.jpg",
//           "height": 375,
//           "width": 500
//         },
//         {
//           "variant": "PT11",
//           "link": "https://m.media-amazon.com/images/I/41-6bmPtUlL.jpg",
//           "height": 375,
//           "width": 500
//         },
//         {
//           "variant": "PT12",
//           "link": "https://m.media-amazon.com/images/I/41s9Q6gWJ7L.jpg",
//           "height": 448,
//           "width": 500
//         },
//         {
//           "variant": "PT13",
//           "link": "https://m.media-amazon.com/images/I/519nG0mRzuL.jpg",
//           "height": 314,
//           "width": 500
//         },
//         {
//           "variant": "PT14",
//           "link": "https://m.media-amazon.com/images/I/71sHhrGMc7L.jpg",
//           "height": 1097,
//           "width": 1500
//         },
//         {
//           "variant": "PT14",
//           "link": "https://m.media-amazon.com/images/I/41CH6gKtU5L.jpg",
//           "height": 366,
//           "width": 500
//         },
//         {
//           "variant": "PT15",
//           "link": "https://m.media-amazon.com/images/I/21-s7QYrTxL.jpg",
//           "height": 500,
//           "width": 175
//         },
//         {
//           "variant": "EEGL",
//           "link": "https://m.media-amazon.com/images/I/61i3dsKD09L.jpg",
//           "height": 1375,
//           "width": 370
//         },
//         {
//           "variant": "EEGL",
//           "link": "https://m.media-amazon.com/images/I/41E7ku-qdGL.jpg",
//           "height": 500,
//           "width": 135
//         },
//         {
//           "variant": "EGUS",
//           "link": "https://m.media-amazon.com/images/I/61i3dsKD09L.jpg",
//           "height": 1375,
//           "width": 370
//         },
//         {
//           "variant": "EGUS",
//           "link": "https://m.media-amazon.com/images/I/41E7ku-qdGL.jpg",
//           "height": 500,
//           "width": 135
//         }
//       ]
//     }
//   ],
//   "productTypes": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "productType": "TELEVISION"
//     }
//   ],
//   "salesRanks": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "classificationRanks": [
//         {
//           "classificationId": "21489946011",
//           "title": "QLED TVs",
//           "link": "http://www.amazon.com/gp/bestsellers/electronics/21489946011",
//           "rank": 113
//         }
//       ],
//       "displayGroupRanks": [
//         {
//           "websiteDisplayGroup": "ce_display_on_website",
//           "title": "Electronics",
//           "link": "http://www.amazon.com/gp/bestsellers/electronics",
//           "rank": 72855
//         }
//       ]
//     }
//   ],
//   "summaries": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "brand": "SAMSUNG",
//       "browseClassification": {
//         "displayName": "QLED TVs",
//         "classificationId": "21489946011"
//       },
//       "color": "Black",
//       "itemClassification": "BASE_PRODUCT",
//       "itemName": "Samsung QN82Q60RAFXZA Flat 82-Inch QLED 4K Q60 Series (2019) Ultra HD Smart TV with HDR and Alexa Compatibility",
//       "manufacturer": "Samsung",
//       "modelNumber": "QN82Q60RAFXZA",
//       "packageQuantity": 1,
//       "partNumber": "QN82Q60RAFXZA",
//       "size": "82-Inch",
//       "style": "TV only",
//       "websiteDisplayGroup": "ce_display_on_website"
//     }
//   ],
//   "relationships": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "relationships": [
//         {
//           "type": "VARIATION",
//           "parentAsins": [
//             "B08J7TQ9FL"
//           ],
//           "variationTheme": {
//             "attributes": [
//               "color",
//               "size"
//             ],
//             "theme": "SIZE_NAME/COLOR_NAME"
//           }
//         }
//       ]
//     }
//   ],
//   "vendorDetails": [
//     {
//       "marketplaceId": "ATVPDKIKX0DER",
//       "brandCode": "SAMF9",
//       "manufacturerCode": "SAMF9",
//       "manufacturerCodeParent": "SAMF9",
//       "productCategory": {
//         "displayName": "Televisions",
//         "value": "50400100"
//       },
//       "productGroup": "Home Entertainment",
//       "productSubcategory": {
//         "displayName": "Plasma TVs",
//         "value": "50400120"
//       },
//       "replenishmentCategory": "OBSOLETE"
//     }
//   ]
// }
