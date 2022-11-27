import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginData } from '../../interfaces/loginData';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(
    private readonly iAuthService: AuthService,
    private readonly iRouter: Router
  ) { }

  ngOnInit(): void {
  }

  loginWithMail(loginData: LoginData) {

    this.iAuthService
      .loginWithMail(loginData)
      .then(() => this.iRouter.navigate(['/home']))
      .catch((e) => console.log(e));
  }

  loginWithGoogle() {

    this.iAuthService
      .loginWithGoogle()
      .then(() => this.iRouter.navigate(['/home']))
      .catch((e) => console.log(e));
  }

  loginWithFacebook() {

    this.iAuthService
      .loginWithFacebook()
      .then(() => this.iRouter.navigate(['/home']))
      .catch((e) => console.log(e));
  }

  loginWithTwitter() {

    this.iAuthService
      .loginWithTwitter()
      .then(() => this.iRouter.navigate(['/home']))
      .catch((e) => console.log(e));
  }
}
