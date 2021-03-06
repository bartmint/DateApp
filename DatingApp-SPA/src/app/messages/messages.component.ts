import { Component, OnInit } from '@angular/core';
import { Message } from '../_models/message';
import { Pagination } from '../_models/pagination';
import { MessageService } from '../_services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
messages: Message[]=[];
pagination: Pagination;
container='Unread';
pageNumber=1;
pageSize=5;
loading=false;

  constructor(private messageSrvice: MessageService) { }

  ngOnInit() {
    this.loadMessages();
  }
  loadMessages(){
    this.loading=true;
    this.messageSrvice.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages=response.result;
      this.pagination=response.pagination;
      this.loading=false;
    })
  }
  pageChanged(event: any){
    this.pageNumber=event.page;
    this.loadMessages();
  }
  deleteMessage(id:number){
    this.messageSrvice.deleteMessage(id).subscribe(()=>{
      this.messages.splice(this.messages.findIndex(m=>m.id===id), 1);
    })
  }

}
