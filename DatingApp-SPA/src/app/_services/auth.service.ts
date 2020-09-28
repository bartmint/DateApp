import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
 baseUrl =  'http://localhost:5001/api/';
 private currentUserSource = new ReplaySubject<User>(1);
 currentUser$ = this.currentUserSource.asObservable();


constructor(private http: HttpClient) { }


// tslint:disable-next-line: typedef
login(model: any) {
  return this.http.post(this.baseUrl + 'account/login', model).pipe(
    map((response: User) => {
      const user = response;
      if (user){
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      }
    })
  );
}
register(model: any){
  return this.http.post(this.baseUrl + 'account/register', model).pipe(
    map((user: User) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
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

setCurrentUser(user: User){
  this.currentUserSource.next(user);
}
}