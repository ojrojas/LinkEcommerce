import { Component } from '@angular/core';
import { ModulesMaterial } from '../../shared/components.material.modules';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [ModulesMaterial],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {
  date = new Date();
}
