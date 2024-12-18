import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentPayableComponent } from './shipment-payable.component';

describe('ShipmentPayableComponent', () => {
  let component: ShipmentPayableComponent;
  let fixture: ComponentFixture<ShipmentPayableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShipmentPayableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipmentPayableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
