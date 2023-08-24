import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketFavoriteComponent } from './ticket-favorite.component';

describe('TicketFavoriteComponent', () => {
  let component: TicketFavoriteComponent;
  let fixture: ComponentFixture<TicketFavoriteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TicketFavoriteComponent]
    });
    fixture = TestBed.createComponent(TicketFavoriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
