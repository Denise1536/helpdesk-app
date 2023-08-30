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
  favorites: any[] = [];
  
  constructor(private route: ActivatedRoute,private helpdeskService: HelpdeskService) {}
  
  ngOnInit(): void {
    this.getFavoritesFromService();
  }
  
  getFavoritesFromService() {
    console.log("gettingfavorites")
    this.helpdeskService.getFavorites().subscribe(
      (data: any[]) => {
        console.log(data)
        this.favorites = data;
      },
      (error) => {
        console.log(error);
      }
    );
  } 
}




 