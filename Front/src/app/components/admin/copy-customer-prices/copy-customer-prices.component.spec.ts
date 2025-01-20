import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CopyCustomerPricesComponent } from './copy-customer-prices.component';

describe('CopyCustomerPricesComponent', () => {
  let component: CopyCustomerPricesComponent;
  let fixture: ComponentFixture<CopyCustomerPricesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CopyCustomerPricesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CopyCustomerPricesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
