import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material.module';
import { AccountRoutingModule } from './account-routing.module';

import { AccountComponent } from './account.component';
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { CompleteRegistrationComponent } from './pages/complete-registration/complete-registration.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';

@NgModule({
  declarations: [
    AccountComponent,
    LoginFormComponent,
    LoginPageComponent,
    CompleteRegistrationComponent,
    RegisterPageComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class AccountModule { }
