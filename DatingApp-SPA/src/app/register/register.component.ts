import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

 @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }

  register() {
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.accountService.login(response);
      this.cancel();
      
    }, error => {
      console.log(error);
    });
    }
    cancel() {
      this.cancelRegister.emit(false);
    }
}