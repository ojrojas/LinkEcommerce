import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'products',
    loadChildren: () => import('./pages/products/products.routes').then(component => component.ProductsRoutes)
  },
  {
    path: 'basket/:id',
    loadComponent: () => import('./pages/basket/basket.component').then(component => component.BasketComponent)
  },
  {
    path:'catalogs',
    loadChildren: () => import('./pages/catalogs/catalogs.routes').then(component=> component.CatalogRoutes)
  },
  {
    path:'orders',
    loadChildren: () => import('./pages/orders/orders.routes').then(component=> component.RoutesOrders)
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
