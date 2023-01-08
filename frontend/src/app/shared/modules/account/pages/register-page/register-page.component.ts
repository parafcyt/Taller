import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCredential } from 'firebase/auth';
import { LoginType } from '../../enums/loginType.enum';
import { UserRegistrationState } from '../../enums/userRegistrationState.enum';
import { IValidateRegistration } from '../../interfaces/validateRegistration.interface';
import { LoginData } from '../../models/loginData';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit, IValidateRegistration {

  mShowText: LoginType = LoginType.Registration;

  constructor(
    private readonly iAuthService: AuthService,
    private readonly iRouter: Router
  ) { }
  
  ngOnInit(): void {
  }

  registerWithMail(loginData: LoginData) {

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

  validateRegistration(pUser: UserCredential): void {
    
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
