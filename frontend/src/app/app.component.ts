import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './modules/account/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';

  constructor(
    public readonly iAuthService: AuthService,
    private readonly iRouter: Router) { }

  logout() {
    
    this.iAuthService
      .logout()
      .then(() => this.iRouter.navigate(['/']))
      .catch((e) => console.log(e));
  }
}
