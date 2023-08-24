import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';
import { TicketFavoriteComponent } from './ticket-favorite/ticket-favorite.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';
import { TicketListComponent } from './ticket-list/ticket-list.component';

const routes: Routes = [

  { path: '', redirectTo: '/tickets', pathMatch: 'full' },
  { path: 'tickets', component: TicketListComponent },
  { path: 'tickets/:id', component: TicketDetailsComponent },
  { path: 'add-ticket', component: TicketFormComponent },
  { path: 'update-ticket/:id', component: TicketFormComponent },
  { path: 'add-favorite/:id', component: TicketFavoriteComponent },
  { path: 'delete-favorite/:id', component: TicketFavoriteComponent },
  { path: 'get-favorites', component: TicketFavoriteComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
