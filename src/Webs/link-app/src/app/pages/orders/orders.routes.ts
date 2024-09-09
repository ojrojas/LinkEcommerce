import { Routes } from '@angular/router';

export const RoutesOrders: Routes = [
  {
    path: '',
    loadComponent: () => import('./orders.component').then(component => component.OrdersComponent),
  },
  {
    path: 'details/:id',
    loadComponent: () => import('./details/details.component').then(component => component.DetailsComponent)
  },
  {
    path: 'form',
    loadComponent: () => import('./form/form.component').then(component => component.FormComponent)
  }
]
