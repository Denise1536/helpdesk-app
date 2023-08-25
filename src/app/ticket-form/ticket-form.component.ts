import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HelpdeskService } from '../helpdesk.service';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})

export class TicketFormComponent implements OnInit {
  ticket: any;
  isEditing: boolean = false;
  
    constructor(private route: ActivatedRoute, private router: Router, private helpdeskService: HelpdeskService){
  
    }
  
    ngOnInit(): void {
      const id = this.route.snapshot.paramMap.get('idTicket');
      if (id) {
        this.isEditing = true;
        this.getTicketDetails(+id);
      }
    }
    getTicketDetails(id: number) {
      this.helpdeskService.getTicket(id).subscribe((ticket) => {
        this.ticket = ticket;});
    }
  
    updateTicket() {
      if (this.isEditing) {
        this.helpdeskService
          .updateTicket(this.ticket.idTicket, this.ticket)
          .subscribe(() => {
            this.router.navigate(['/tickets']); });
      } else {
        this.helpdeskService.createTicket(this.ticket).subscribe(() => {
          this.router.navigate(['/tickets']); });
      }
    } 
    cancelForm() {this.router.navigate(['/tickets']); }
  }