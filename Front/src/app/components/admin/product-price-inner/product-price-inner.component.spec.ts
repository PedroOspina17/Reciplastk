import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductPriceInnerComponent } from './product-price-inner.component';

describe('ProductPriceInnerComponent', () => {
  let component: ProductPriceInnerComponent;
  let fixture: ComponentFixture<ProductPriceInnerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductPriceInnerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductPriceInnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
