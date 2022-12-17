import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCredential } from 'firebase/auth';
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

  /**
   * Verifica que el usuario haya compeltado su registro
   * @param pUser Objeto usuario
   */
  validateRegistration(pUser: UserCredential) {

    console.log(pUser);

    // TODO: Validar si el usuario completó sus datos y está en la bbdd local
    // en caso de registro, navegar a la pagina para completar sus datos
    this.iRouter.navigate(['/complete-registration']);

    // en caso contrario, navegar al home
    //this.iRouter.navigate(['/home']);
  }
}
