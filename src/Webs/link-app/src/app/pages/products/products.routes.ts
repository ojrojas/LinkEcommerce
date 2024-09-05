import { Routes } from "@angular/router";

export const productsRoutes: Routes = [
  {
    path: 'products/details/:id',
    loadComponent: () => import('./details/details.component').then(component => component.DetailsComponent)
  },
];
