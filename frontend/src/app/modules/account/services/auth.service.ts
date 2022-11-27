import { Injectable } from '@angular/core';
import { 
  Auth, 
  authState, 
  signInAnonymously, 
  signOut, 
  User, 
  GoogleAuthProvider, 
  signInWithPopup, 
  FacebookAuthProvider, 
  TwitterAuthProvider,
  signInWithEmailAndPassword,
  createUserWithEmailAndPassword
} from '@angular/fire/auth';
import { LoginData } from '../interfaces/loginData';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private iAuth: Auth) { }

  loginWithGoogle() {
    
    return signInWithPopup(this.iAuth, new GoogleAuthProvider());
  }

  loginWithFacebook() {
    
    return signInWithPopup(this.iAuth, new FacebookAuthProvider());
  }

  loginWithTwitter() {

    return signInWithPopup(this.iAuth, new TwitterAuthProvider());
  }

  loginWithMail({ email, password }: LoginData) {

    return signInWithEmailAndPassword(this.iAuth, email, password);
  }

  registerWithMail({ email, password }: LoginData) {

    return createUserWithEmailAndPassword(this.iAuth, email, password);
  }

  logout() {

    return signOut(this.iAuth);
  }
  
}
