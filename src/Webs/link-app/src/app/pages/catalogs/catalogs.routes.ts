import { Routes } from "@angular/router";

export const CatalogRoutes: Routes = [
  {
    path: 'edit/:id',
    loadComponent: () => import('./edit/edit.component').then(component => component.EditComponent)
  },
  {
    path: 'details/:id',
    loadComponent: () => import('./details/details.component').then(component => component.DetailsComponent)
  },
  {
    path: 'form',
    loadComponent: () => import('./form/form.component').then(component => component.FormComponent)
  },
  {
    path: '',
    loadComponent: () => import('./catalogs.component').then(component => component.CatalogsComponent),
    pathMatch: 'full'
  },
];
