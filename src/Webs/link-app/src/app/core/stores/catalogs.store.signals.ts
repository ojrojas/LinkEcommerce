import { patchState, signalStore, withMethods, withState } from '@ngrx/signals'
import { CatalogItem } from '../models/catalogitem.model';
import { inject } from '@angular/core';
import { CatalogService } from '../services/catalog-services.service';
import { setFulfilled, setPending, withRequestStatus } from './state.request.features';
import { PaginationResponse } from '../dtos/paginationResponse.dto';
import { GetCatalogByIdResponse } from '../dtos/response.dto';

type CatalogECommerceState =
  {
    catalogItems: PaginationResponse<CatalogItem[]> | undefined
    isLoading: boolean;
    catalogItem: GetCatalogByIdResponse | undefined;
  };

const initialState: CatalogECommerceState = {
  catalogItems: undefined,
  isLoading: false,
  catalogItem: undefined
};

export const CatalogECommerceStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withRequestStatus(),
  withMethods((store, catalogService = inject(CatalogService)) => ({
    getAllCatalogItems(pageSize: number = 12, pageIndex: number = 0, apiVersion: string = '1.0') {
      patchState(store, setPending());
      catalogService.getAllItems(pageSize, pageIndex, apiVersion).subscribe(
        result => {
          patchState(store, { catalogItems: result }, setFulfilled());
        }
      )
    },
    getItemById(id: string, apiVersion = '1.0') {
      patchState(store, setPending());
      catalogService.getItemById(id, apiVersion).subscribe(result => {
        patchState(store, { catalogItem: result }, setFulfilled());
      })
    },
    getItemsByBrandId(brandid: string, pageSize: number = 10, pageIndex: number = 0, apiVersion: string = "1.0") {
      patchState(store, setPending());
      catalogService.getItemsByBrandId(brandid, pageSize, pageIndex, apiVersion).subscribe(result => {
        patchState(store, { catalogItems: result }, setFulfilled());
      })
    },
    getItemsByBrandIdAndTypeId(brandid: string, typeid: string, pageSize: number = 10, pageIndex: number = 0, apiVersion: string = "1.0") {
      patchState(store, setPending());
      catalogService.getItemsByBrandIdAndTypeId(brandid, typeid, pageSize, pageIndex, apiVersion).subscribe(result => {
        patchState(store, { catalogItems: result }, setFulfilled());
      })
    },
    deleteCatalogItemById(id: string, apiVersion: string = "1.0") {
      patchState(store, setPending());
      catalogService.deleteCatalogItemById(id, apiVersion).subscribe(
        result => {
          patchState(store, setFulfilled());
          this.getAllCatalogItems();
        }
      )
    },
    editCatalogItem(catalogItem: CatalogItem, apiVersion: string = "1.0") {
      patchState(store, setPending());
      catalogService.editCatalogItem(catalogItem, apiVersion).subscribe(
        result => {
          patchState(store, setFulfilled());
          this.getAllCatalogItems();
        }
      )
    },
    createCatalogItem(catalogItem: CatalogItem, apiVersion: string = "1.0") {
      patchState(store, setPending());
      catalogService.createCatalogItem(catalogItem, apiVersion).subscribe(
        result => {
          patchState(store, setFulfilled());
          this.getAllCatalogItems();
        }
      )
    }

  }))
);
