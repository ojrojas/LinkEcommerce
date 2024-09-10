import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AsyncPipe } from '@angular/common';
// import { LoggerSeqService } from '../../shared/logger.seq';
import { ListItemComponent } from './list-item/list-item.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { CatalogECommerceStore } from '../../core/stores/catalogs.store.signals';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [RouterLink, AsyncPipe, ListItemComponent, MatGridListModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductsComponent implements OnInit {
  store = inject(CatalogECommerceStore);
  // logger = inject(LoggerSeqService);

  constructor() {
  }
  ngOnInit(): void {
    this.store.getAllCatalogItems();
    console.log("items", this.store.catalogItems()?.paginatedItems);
  }
}
