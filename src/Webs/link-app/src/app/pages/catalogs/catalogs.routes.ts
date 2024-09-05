import { Routes } from "@angular/router";

export const catalogOrders: Routes = [
  {
    path: 'catalogs/form',
    loadComponent: () => import('./form/form.component').then(component => component.FormComponent)
  },
];
