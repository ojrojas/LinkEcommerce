import { CatalogItem } from "../models/catalogitem.model";

export interface GetCatalogByIdResponse {
  correlationId: string;
  catalogItem: CatalogItem;
}
