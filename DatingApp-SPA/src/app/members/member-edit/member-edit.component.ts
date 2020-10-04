import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/auth.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  @ViewChild('editForm') editForm: NgForm; // pozwla na dostep do formularza
  member: Member ;
  user: User;
  @HostListener('window:beforeunload', ['$event']) unloadNotifiaction($event: any){
    if (this.editForm.dirty){
      $event.returnValue = true; // jesli wprowadzimy zmiany w formularzy i nie zapiszemy i chcemy wyjsc ze strony to pokaze blad
    }
  }

  constructor(private accountService: AccountService, private memberService: MembersService, private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
   }

  ngOnInit() {
    this.loadMember();

  }

  // tslint:disable-next-line: typedef
  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {
    this.member = member;

    });
  }
updateMember(){
  this.memberService.updateMember(this.member).subscribe(() => {
    this.toastr.success('profile updated succesfully');
    this.editForm.reset(this.member);
  });

}
}
