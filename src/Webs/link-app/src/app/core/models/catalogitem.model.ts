import { BaseEntity } from "./baseentity.model";
import { Brand } from "./brand.model";
import { CatalogType } from "./type.model";

export interface CatalogItem extends BaseEntity {
  name: string;
  description: string;
  price: number;
  catalogBrand: Brand;
  catalogBrandId: string;
  catalogType: CatalogType;
  catalogTypeId: string;
  pictureBase64: string;
  availableQuantity: number;
  maxItemsInStock: number;
}
