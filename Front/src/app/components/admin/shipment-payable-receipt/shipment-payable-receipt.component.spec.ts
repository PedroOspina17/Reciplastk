import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentPayableReceiptComponent } from './shipment-payable-receipt.component';

describe('ShipmentPayableReceiptComponent', () => {
  let component: ShipmentPayableReceiptComponent;
  let fixture: ComponentFixture<ShipmentPayableReceiptComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShipmentPayableReceiptComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShipmentPayableReceiptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
