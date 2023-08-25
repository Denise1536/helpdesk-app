import { Component, OnInit } from '@angular/core';
import { HelpdeskService } from '../helpdesk.service';

@Component({
  selector: 'ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css']
})
export class TicketListComponent implements OnInit{
  tickets: any[] = [];

  constructor(private helpdeskService:HelpdeskService){}

  ngOnInit(): void {
    this.getTickets()
  }
 
getTickets() {
  this.helpdeskService.getTickets().subscribe((tickets) => {
    this.tickets = tickets;
  });
}

  getTicketsFromService() {
    this.helpdeskService.getTickets().subscribe(
      (data: any[]) => {
        this.tickets = data;
      },
      (error) => {
        console.log(error);
      }
    );
  } 
  

}