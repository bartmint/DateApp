import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  // tslint:disable-next-line: max-line-length
  providedIn: 'root' // serwis jest rejestrowany jako dostawca modulu, bez dodawania go do dostawcow w app.module.ts ngModules, dodawany jest do providers
})
export class AccountService {
 baseUrl =  environment.apiUrl;
 private currentUserSource = new ReplaySubject<User>(1);
 currentUser$ = this.currentUserSource.asObservable();


constructor(private http: HttpClient, private router: Router) { }


// tslint:disable-next-line: typedef
login(model: any) {
  return this.http.post(this.baseUrl + 'account/login', model).pipe(
    map((user: User) => {
      if (user){
        this.setCurrentUser(user);
      }
    })
  );
}
// tslint:disable-next-line: typedef
register(model: any){
  return this.http.post(this.baseUrl + 'account/register', model).pipe(
    map((user: User) => {
      if (user) {
        this.setCurrentUser(user);
      }
      return user; // tylko do wyswietlenia w konsoli
    })
  );
}

// tslint:disable-next-line: typedef
logout(){
  localStorage.removeItem('user');
  this.currentUserSource.next(null);
}

// tslint:disable-next-line: typedef
setCurrentUser(user: User){
  localStorage.setItem('user', JSON.stringify(user));
  this.currentUserSource.next(user);
}
}
