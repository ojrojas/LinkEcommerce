import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'products',
    loadComponent: () => import('./pages/products/products.component').then(component => component.ProductsComponent)
  },
  {
    path: 'basket/:id',
    loadComponent: () => import('./pages/basket/basket.component').then(component => component.BasketComponent)
  },
  {
    path:'catalogs',
    loadComponent: () => import('./pages/catalogs/catalogs.component').then(component=> component.CatalogsComponent)
  },
  {
    path:'orders',
    loadComponent: () => import('./pages/orders/orders.component').then(component=> component.OrdersComponent)
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
