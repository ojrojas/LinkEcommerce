import { Component, inject, input } from '@angular/core';
import { CatalogECommerceStore } from '../../../core/stores/catalogs.store.signals';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.scss'
})
export class EditComponent {
  store = inject(CatalogECommerceStore);
  catalogItemResponse = this.store.catalogItem();
  id = input<string>('', { alias: 'id' });

  ngOnInit(): void {
    console.log("catalogItem", this.id());
    this.store.getItemById(this.id());
  }
}
