import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from "../../shared/modules/material.module";
import { ReactiveFormsModule } from '@angular/forms';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { CompleteRegistrationComponent } from './pages/complete-registration/complete-registration.component';



@NgModule({
  declarations: [
    AccountComponent,
    LoginFormComponent,
    LoginPageComponent,
    CompleteRegistrationComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class AccountModule { }
