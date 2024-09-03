import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'products',
    loadComponent: () => import('./pages/catalog/products/products.component').then(component => component.ProductsComponent)
  },
  {
    path: 'products/details/:id',
    loadComponent: () => import('./pages/catalog/details/details.component').then(component => component.DetailsComponent)
  },
  {
    path: 'basket/:id',
    loadComponent: () => import('./pages/catalog/basket/basket.component').then(component => component.BasketComponent)
  },
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'products', pathMatch: 'full'
  }
];
