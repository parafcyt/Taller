import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';
import { UserCredential } from 'firebase/auth';
import { LoginType } from '../../enums/loginType.enum';
import { UserRegistrationState } from '../../enums/userRegistrationState.enum';
import { IValidateRegistration } from '../../interfaces/validateRegistration.interface';
import { LoginData } from '../../models/loginData';
import { user, Auth } from '@angular/fire/auth';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit, IValidateRegistration {

  mShowText: LoginType = LoginType.Login;

  constructor(
    private readonly iRouter: Router,
    private readonly iAuthService: AuthService,
    private readonly iAuth: Auth
  ) { }

  ngOnInit(): void {

    user(this.iAuth).subscribe(pCurrentUser => {

      if (pCurrentUser != null) {
        
        this.iRouter.navigate(['/public']);
      }
    });
  }

  loginWithMail(loginData: LoginData) {

    this.iAuthService
      .loginWithMail(loginData)
      .then((pUser: UserCredential) => this.validateRegistration(pUser))
      .catch((e) => console.log(e));
  }

  loginWithGoogle() {

    this.iAuthService
      .loginWithGoogle()
      .then((pUser: UserCredential) => this.validateRegistration(pUser))
      .catch((e) => console.log(e));
  }

  loginWithFacebook() {

    this.iAuthService
      .loginWithFacebook()
      .then((pUser: UserCredential) => this.validateRegistration(pUser))
      .catch((e) => console.log(e));
  }

  loginWithTwitter() {

    this.iAuthService
      .loginWithTwitter()
      .then((pUser: UserCredential) => this.validateRegistration(pUser))
      .catch((e) => console.log(e));
  }

  validateRegistration(pUser: UserCredential) {

    this.iAuthService.createUserIfNotExists(pUser.user).subscribe(pResponse => {

      if (pResponse.code === UserRegistrationState.Uncompleted) {
        
        this.iRouter.navigate(['/account/complete-registration']);
      }
      else {
        this.iRouter.navigate(['/public']);
      }
    });
  }
}
