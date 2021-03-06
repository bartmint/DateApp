import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from 'src/app/_services/auth.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.scss']
})
export class MembersListComponent implements OnInit {
  members$: Member[];
  pagination: Pagination;
  userParams: UserParams;
  user: User;
  genderList = [{value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}];


  constructor(private memberService: MembersService) {
    this.userParams = this.memberService.getUserParams();

   }

  ngOnInit() {
    this.loadMembers();
  }
loadMembers(){
  this.memberService.setUserParams(this.userParams);
  this.memberService.getMembers(this.userParams).subscribe(response => {
    this.members$ = response.result;
    this.pagination = response.pagination;
  });
}
pageChanged(event: any){
this.userParams.pageNumber = event.page;
this.memberService.setUserParams(this.userParams);
this.loadMembers();
}

resetFilter(){
  this.userParams = this.memberService.resetUserParams();
  this.loadMembers();
}}
