import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { canActivate, redirectLoggedInTo, redirectUnauthorizedTo } from '@angular/fire/auth-guard';

/**
 * Pipe para redireccionar al login
 */
const redirectUnauthorizedToLogin = () => redirectUnauthorizedTo(['']);

/**
 * Pipe para redireccionar al home en caso de que el usuario quiera acceder al login
 */
const redirectLoggedInToHome = () => redirectLoggedInTo(['home']);

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./modules/account/account.module')
      .then(mod => mod.AccountModule),
      ...canActivate(redirectLoggedInToHome),
  },
  {
    path: 'home',
    loadChildren: () => import('./modules/client/client.module')
      .then(mod => mod.ClientModule),
      ...canActivate(redirectUnauthorizedToLogin),
  },
  {
    path: 'administration',
    loadChildren: () => import('./modules/admin/admin.module')
      .then(mod => mod.AdminModule),
      ...canActivate(redirectUnauthorizedToLogin),
  },
  {
    path: 'account',
    loadChildren: () => import('./modules/account/account.module')
      .then(mod => mod.AccountModule),
      ...canActivate(redirectUnauthorizedToLogin),
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
