import { Routes } from "@angular/router";

export const ProductsRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./products.component').then(component => component.ProductsComponent)
  },
  {
    path: 'details/:id',
    loadComponent: () => import('./details/details.component').then(component => component.DetailsComponent)
  }
];
