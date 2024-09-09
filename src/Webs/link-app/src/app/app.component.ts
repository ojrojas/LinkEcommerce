import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./components/header/header.component";
import { FooterComponent } from "./components/footer/footer.component";
import { environment } from '../environments/environment.development';
import { ModulesMaterial } from './shared/components.material.modules';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent,
    RouterOutlet,
    ModulesMaterial
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'link-app';
  drawer = document.getElementById("drawer");
  environmentsApp = environment;
  constructor() {

  }
}
