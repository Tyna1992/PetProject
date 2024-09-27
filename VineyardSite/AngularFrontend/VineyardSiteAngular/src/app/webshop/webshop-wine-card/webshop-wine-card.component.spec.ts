import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebshopWineCardComponent } from './webshop-wine-card.component';

describe('WebshopWineCardComponent', () => {
  let component: WebshopWineCardComponent;
  let fixture: ComponentFixture<WebshopWineCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WebshopWineCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WebshopWineCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
