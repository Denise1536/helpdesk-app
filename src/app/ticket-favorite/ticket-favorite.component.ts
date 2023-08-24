import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HelpdeskService } from '../helpdesk.service';

@Component({
  selector: 'app-ticket-favorite',
  templateUrl: './ticket-favorite.component.html',
  styleUrls: ['./ticket-favorite.component.css']
})
export class TicketFavoriteComponent implements OnInit{

  tickets: any; 
  
  constructor(private route: ActivatedRoute,private helpdeskService: HelpdeskService) {}
  
  ngOnInit(): void {
    this.getFavorites();
  }
  
  getFavorites() {
    const id = this.route.snapshot.paramMap.get('idTicket');
    if (id) {
      this.helpdeskService.getTicket(+id).subscribe((ticket: any) => {
        this.tickets = ticket;
      });
    }
  }
  
  
  
  
  
  }
  
