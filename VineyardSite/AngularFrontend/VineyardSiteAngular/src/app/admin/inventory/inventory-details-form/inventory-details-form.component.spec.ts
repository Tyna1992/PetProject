import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryDetailsFormComponent } from './inventory-details-form.component';

describe('InvetoryDetailsFormComponent', () => {
  let component: InventoryDetailsFormComponent;
  let fixture: ComponentFixture<InventoryDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InventoryDetailsFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InventoryDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
