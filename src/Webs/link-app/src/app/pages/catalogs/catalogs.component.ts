import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginationResponse } from '../../core/dtos/paginationResponse.dto';
import { CatalogServicesService } from '../../core/services/catalog-services.service';
import { CatalogItem } from '../../core/models/catalogitem.model';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-catalogs',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './catalogs.component.html',
  styleUrl: './catalogs.component.scss'
})
export class CatalogsComponent {
  catalogService = inject(CatalogServicesService);
  products$:Observable<PaginationResponse<CatalogItem[]>>;

  constructor() {
    this.products$ = this.catalogService.getAllItems();
  }

  DeleteCatalogItem(id: string){
    this.catalogService
  }
}
