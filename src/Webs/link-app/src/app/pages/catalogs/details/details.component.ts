import { Component, inject, input, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CatalogECommerceStore } from '../../../core/stores/catalogs.store.signals';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [AsyncPipe, RouterLink],
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss'
})
export class DetailsComponent implements OnInit {
  store = inject(CatalogECommerceStore);
  catalogItemResponse = this.store.catalogItem();
  id = input<string>('', { alias: 'id' });

  ngOnInit(): void {
    console.log("catalogItem", this.id());
    this.store.getItemById(this.id());
  }
}
