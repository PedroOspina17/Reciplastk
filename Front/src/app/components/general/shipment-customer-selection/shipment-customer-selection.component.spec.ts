import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentCustomerSelectionComponent } from './shipment-customer-selection.component';

describe('ShipmentCustomerSelectionComponent', () => {
  let component: ShipmentCustomerSelectionComponent;
  let fixture: ComponentFixture<ShipmentCustomerSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShipmentCustomerSelectionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShipmentCustomerSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
