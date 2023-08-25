import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HelpdeskService } from '../helpdesk.service';

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.css']
})
export class TicketDetailsComponent implements OnInit{

tickets: any; 

constructor(private route: ActivatedRoute,private helpdeskService: HelpdeskService) {}

ngOnInit(): void {
  this.getTicketDetails();
}

getTicketDetails() {
  const id = this.route.snapshot.paramMap.get('idTicket');
  if (id) {
    this.helpdeskService.getTicket(+id).subscribe((tickets) => {
      this.tickets = tickets;
    });
  }
}





}
