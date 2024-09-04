import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'products',
    loadComponent: () => import('./pages/products/products.component').then(component => component.ProductsComponent)
  },
  {
    path: 'products/details/:id',
    loadComponent: () => import('./pages/details/details.component').then(component => component.DetailsComponent)
  },
  {
    path: 'basket/:id',
    loadComponent: () => import('./pages/basket/basket.component').then(component => component.BasketComponent)
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
