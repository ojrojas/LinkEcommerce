import { Component, Inject, inject, Input } from '@angular/core';
import { CatalogItem } from '../../core/models/catalogitem.model';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [],
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {
  @Input() catalogItem: CatalogItem | undefined = undefined;
  constructor() {
  }
}
