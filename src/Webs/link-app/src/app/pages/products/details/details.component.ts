import { Component, inject, input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { GetCatalogByIdResponse } from '../../../core/dtos/response.dto';
import { RouterLink } from '@angular/router';
import { ModulesMaterial } from '../../../shared/components.material.modules';
import { CatalogECommerceStore } from '../../../core/stores/catalogs.store.signals';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [AsyncPipe, RouterLink, ModulesMaterial],
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss'
})
export class DetailsComponent implements OnInit {
  store = inject(CatalogECommerceStore);
  id = input<string>('', { alias: 'id' });

  ngOnInit(): void {
    console.log("catalogItem", this.id());
    this.store.getItemById(this.id());
  }

  getInfoUnits(count: number): string {
    if (count > 1)
      return `${count} units`;
    else
      return `only ${count} unit`
  }
}
