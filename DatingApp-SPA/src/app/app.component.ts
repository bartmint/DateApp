import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  users: any;
  title = 'DatingApp-SPA';

constructor(private http: HttpClient, private accountService: AccountService){}
  // tslint:disable-next-line: typedef
  ngOnInit() {
      this.setCurrentUser();
    }


  // tslint:disable-next-line: typedef
  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }}

