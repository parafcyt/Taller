import { Injectable } from '@angular/core';
import { 
  Auth, 
  signOut, 
  User, 
  GoogleAuthProvider, 
  signInWithPopup, 
  FacebookAuthProvider, 
  TwitterAuthProvider,
  signInWithEmailAndPassword,
  createUserWithEmailAndPassword
} from '@angular/fire/auth';
import { LoginData } from '../models/loginData';
import { from, map, Observable } from 'rxjs'
import { ICreateUserResponse } from '../models/createUserResponse';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = { 
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private iAuth: Auth,
    private iHttp: HttpClient) { }

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

  logout(): Observable<void> {

    const mObservable = from(signOut(this.iAuth));

    return mObservable.pipe(
      map(() => {
        console.log("Sesión cerrada con éxito");
      })
    );
  }

  public createUserIfNotExists(pUser: User): Observable<ICreateUserResponse> {

    let mUser = {
        displayName: pUser.displayName,
        email: pUser.email,
        phoneNumber: pUser.phoneNumber,
        uid: pUser.uid,
    }

    return this.iHttp.post<ICreateUserResponse>("https://localhost:7011/api/Account/CreateUserIfNotExists", mUser, httpOptions);
  } 
}
