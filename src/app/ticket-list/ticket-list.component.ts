import { Component, OnInit } from '@angular/core';
import { HelpdeskService } from '../helpdesk.service';

@Component({
  selector: 'ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css']
})
export class TicketListComponent implements OnInit{
  tickets: any[] = [];

  constructor(private dataService:HelpdeskService){}

  ngOnInit(): void {
    this.getTicketsFromService()
  }
  getTicketsFromService() {
    this.dataService.getTickets().subscribe(
      (data: any[]) => {
        this.tickets = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  

}