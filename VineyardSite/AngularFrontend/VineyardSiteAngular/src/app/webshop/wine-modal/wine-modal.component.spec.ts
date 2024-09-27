import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WineModalComponent } from './wine-modal.component';

describe('WineModalComponent', () => {
  let component: WineModalComponent;
  let fixture: ComponentFixture<WineModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WineModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WineModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
