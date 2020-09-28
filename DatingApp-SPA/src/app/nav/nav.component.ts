import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/auth.service';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  

  constructor(public accountSerivce: AccountService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
   
  }
  // tslint:disable-next-line: typedef
  login() {
    this.accountSerivce.login(this.model).subscribe(response => {
      console.log(response);
     
    }, error => {
      console.log(error);
    });
  }
  // tslint:disable-next-line: typedef
  logout(){
    this.accountSerivce.logout();
  
  }
 // tslint:disable-next-line: typedef

 
}
