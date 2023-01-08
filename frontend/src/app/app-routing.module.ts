import { NgModule } from '@angular/core';
import { canActivate, redirectLoggedInTo, redirectUnauthorizedTo } from '@angular/fire/auth-guard';
import { RouterModule, Routes } from '@angular/router';


const redirectUnauthorizedToLogin = () => redirectUnauthorizedTo(['/']);

const routes: Routes = [
  {
    path: '',
    redirectTo: '/public',
    pathMatch: 'full'
  },
  {
    path: 'account',
    loadChildren: () => import('src/app/shared/modules/account/account.module')
      .then(mod => mod.AccountModule)
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public.module')
      .then(mod => mod.PublicModule)
  },
  {
    path: 'private',
    loadChildren: () => import('./modules/private/private.module')
      .then(mod => mod.PrivateModule),
      ...canActivate(redirectUnauthorizedToLogin)
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
