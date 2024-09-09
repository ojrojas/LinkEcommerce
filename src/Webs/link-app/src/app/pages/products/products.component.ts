import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';
import { AsyncPipe } from '@angular/common';
import { CatalogServicesService } from '../../core/services/catalog-services.service';
// import { LoggerSeqService } from '../../shared/logger.seq';
import { CatalogItem } from '../../core/models/catalogitem.model';
import { PaginationResponse } from '../../core/dtos/paginationResponse.dto';
import { ListItemComponent } from './list-item/list-item.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { ECommerceStore } from '../../store.signals';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [RouterLink, AsyncPipe, ListItemComponent, MatGridListModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  catalogService = inject(CatalogServicesService);
  store = inject(ECommerceStore);
  // logger = inject(LoggerSeqService);
  products$: Observable<PaginationResponse<CatalogItem[]>>;

  constructor() {
    // this.logger.logInfo("Heeey this works");
    this.products$ = this.catalogService.getAllItems();
  }
}
