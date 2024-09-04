import { Component, inject } from '@angular/core';
import { CardComponent } from "../../components/card/card.component";
import { Observable } from 'rxjs';
import { RouterLink } from '@angular/router';
import { AsyncPipe } from '@angular/common';
import { CatalogServicesService } from '../../core/services/catalog-services.service';
import { LoggerSeqService } from '../../shared/logger.seq';
import { CatalogItem } from '../../core/models/catalogitem.model';
import { PaginationResponse } from '../../core/dtos/paginationResponse.dto';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CardComponent, RouterLink, AsyncPipe],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  catalogService = inject(CatalogServicesService);
  logger = inject(LoggerSeqService);
  products$:Observable<PaginationResponse<CatalogItem[]>>;

  constructor() {
    this.logger.logInfo("Heeey this works");
    this.products$ = this.catalogService.getAllItems();

  }
}
