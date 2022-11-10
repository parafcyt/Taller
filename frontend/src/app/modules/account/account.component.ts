import { Component, OnInit } from '@angular/core';
import { Auth, authState, signInAnonymously, signOut, User, GoogleAuthProvider, signInWithPopup } from '@angular/fire/auth';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor(private auth: Auth) { }

  ngOnInit(): void {
    signInWithPopup(this.auth, new GoogleAuthProvider());
  }

}
