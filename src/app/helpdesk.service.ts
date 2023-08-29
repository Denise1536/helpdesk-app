import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HelpdeskService {
  private apiUrl = 'https://localhost:7199/api/helpdesk';
  constructor(private http: HttpClient) { }

  getTickets(): Observable<any[]> 
  {
    return this.http.get<any[]>(this.apiUrl);
  }

  getTicket(id: number): Observable<any> {
    console.log(id)
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<any>(url);
  }

  createTicket(ticket: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, ticket);
  }

  updateTicket(id: number, ticket: any): Observable<any> {
    console.log(ticket)
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<any>(url, ticket);
  }

  createFavorite(favorite: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, favorite);
  }

  deleteFavorite(favorite: any): Observable<any> {
    const url = `${this.apiUrl}/${!favorite}`;
    return this.http.post<any>(url, favorite);
  }

  getFavorites(favorite: any): Observable<any> {
    const url = `${this.apiUrl}/${favorite}`;
    return this.http.get<any>(url);
  }

}

