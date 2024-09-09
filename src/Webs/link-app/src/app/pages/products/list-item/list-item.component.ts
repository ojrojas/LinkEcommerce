import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CatalogItem } from '../../../core/models/catalogitem.model';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-list-item',
  standalone: true,
  imports: [RouterLink, MatCardModule, MatButtonModule],
  templateUrl: './list-item.component.html',
  styleUrl: './list-item.component.scss'
})
export class ListItemComponent {
  @Input() catalogItem: CatalogItem | undefined = undefined;
}
