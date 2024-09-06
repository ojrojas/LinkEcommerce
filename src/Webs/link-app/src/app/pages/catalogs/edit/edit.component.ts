import { Component, inject, input } from '@angular/core';
import { CatalogServicesService } from '../../../core/services/catalog-services.service';
import { Observable } from 'rxjs';
import { GetCatalogByIdResponse } from '../../../core/dtos/response.dto';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.scss'
})
export class EditComponent {
  catalogService: CatalogServicesService = inject(CatalogServicesService);
  catalogItemResponse$: Observable<GetCatalogByIdResponse> | undefined ;
  id = input<string>('', { alias: 'id' });

  ngOnInit(): void {
    console.log("catalogItem", this.id());
    this.catalogItemResponse$=  this.catalogService.getItemById(this.id());
  }
}
