import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from './shared/modules/account/services/auth.service';

import { user, Auth } from '@angular/fire/auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'frontend';
  isUserAuthenticated: boolean = false;

  constructor(
    public readonly iAuthService: AuthService,
    private readonly iRouter: Router,
    private readonly iAuth: Auth) { }

  ngOnInit(): void {

    user(this.iAuth).subscribe(pCurrentUser => {
      this.isUserAuthenticated = pCurrentUser ? true : false;
    });
  }

  logout() {
    
    this.iAuthService
      .logout()
      .subscribe(() => {
        this.iRouter.navigate(['/']);
      });
  }
}
