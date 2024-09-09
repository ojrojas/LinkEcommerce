import { BaseEntity } from "./baseentity.model";

export interface BasketCatalogItem extends BaseEntity {
  CatalogItemId: number;
  Name: string;
  Price: number;
  OldPrice: number;
  Quantity: number;
  PictureBase64: string;
}
