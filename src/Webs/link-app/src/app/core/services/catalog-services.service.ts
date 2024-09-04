import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CatalogItem } from '../models/catalogitem.model';
import { PaginationResponse } from '../dtos/paginationResponse.dto';

@Injectable({
  providedIn: 'root'
})
export class CatalogServicesService {
  private readonly _httpClient = inject(HttpClient);

  constructor() {

  }

  getAllItems(pageSize: number = 10, pageIndex: number = 0, apiVersion: string = "1.0"): Observable<PaginationResponse<CatalogItem[]>> {
    return this._httpClient.get<PaginationResponse<CatalogItem[]>>(`/catalogs/api/catalogs/getallitems?PageSize=${pageSize}&PageIndex=${pageIndex}&api-version=${apiVersion}`);
  }

  getItemById(id: string, apiVersion: string = "1.0"): Observable<CatalogItem> {
    return this._httpClient.get<CatalogItem>(
      `/catalogs/api/catalogs/getitembyid/${id}?api-version=${apiVersion}`
    );
  }

  getItemsByBrandId(brandid: string, pageSize: number = 10, pageIndex: number = 0, apiVersion: string = "1.0"):
    Observable<PaginationResponse<CatalogItem[]>> {
    return this._httpClient.get<PaginationResponse<CatalogItem[]>>(
      `/catalogs/api/catalogs/getitemsbybrandid/${brandid}?PageSize=${pageSize}&PageIndex=${pageIndex}&api-version=${apiVersion}`
    );
  }

  getItemsByBrandIdAndTypeId(
    brandid: string, typeid: string, pageSize: number = 10, pageIndex: number = 0, apiVersion: string = "1.0"): Observable<PaginationResponse<CatalogItem[]>> {
    return this._httpClient.get<PaginationResponse<CatalogItem[]>>(
      `/catalogs/api/catalogs/getitemsbybrandidandtypeid/brand/${brandid}/type/${typeid}?PageSize=${pageSize}&PageIndex=${pageIndex}&api-version=${apiVersion}`
    );
  }
}
