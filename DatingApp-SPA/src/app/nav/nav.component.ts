import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/auth.service';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}; // inicjalizacja jako pusty objekt


  constructor(public accountSerivce: AccountService, private router: Router, private toastr: ToastrService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }
  // tslint:disable-next-line: typedef
  login() {
    this.accountSerivce.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/members'); // po zalogowaniu przenosi do members
      console.log(response);
      

    }
    );
  }
  // tslint:disable-next-line: typedef
  logout(){
    this.accountSerivce.logout();

  }

 // tslint:disable-next-line: typedef


}
 // ngx-toastr
 
