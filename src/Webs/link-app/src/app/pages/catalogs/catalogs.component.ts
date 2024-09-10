import { Component, inject } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CatalogECommerceStore } from '../../core/stores/catalogs.store.signals';

@Component({
  selector: 'app-catalogs',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './catalogs.component.html',
  styleUrl: './catalogs.component.scss'
})
export class CatalogsComponent {
  store = inject(CatalogECommerceStore);

  constructor() {
  }

  DeleteCatalogItem(id: string){
    this.store.deleteCatalogItemById(id);
  }
}
