import { Routes } from '@angular/router';

export const routesOrders: Routes = [
  {
    path: 'orders/details/:id',
    loadComponent: () => import('./details/details.component').then(component => component.DetailsComponent)
  },
  {
    path: 'orders/form',
    loadComponent: () => import('./form/form.component').then(component => component.FormComponent)
  }
]
