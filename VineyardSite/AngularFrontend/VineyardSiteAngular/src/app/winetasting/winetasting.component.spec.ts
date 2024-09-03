import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinetastingComponent } from './winetasting.component';

describe('WinetastingComponent', () => {
  let component: WinetastingComponent;
  let fixture: ComponentFixture<WinetastingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WinetastingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WinetastingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
