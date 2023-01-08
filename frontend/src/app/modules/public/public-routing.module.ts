import { NgModule } from '@angular/core';
import { canActivate, redirectLoggedInTo, redirectUnauthorizedTo } from '@angular/fire/auth-guard';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './modules/home/home.component';

/**
 * Pipe para redireccionar al login
 */
const redirectUnauthorizedToLogin = () => redirectUnauthorizedTo(['/account/']);

/**
 * Pipe para redireccionar al home en caso de que el usuario quiera acceder al login
 */
const redirectLoggedInToHome = () => redirectLoggedInTo(['']);

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  // {
  //   path: '',
  //   loadChildren: () => import('./modules/home/home.component')
  //     .then(mod => mod.HomeComponent),
  //     ...canActivate(redirectUnauthorizedToLogin),
  //     ...canActivate(redirectLoggedInToHome)
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule { }
