import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeightControlForPaymentsComponent } from './weight-control-for-payments.component';

describe('WeightControlForPaymentsComponent', () => {
  let component: WeightControlForPaymentsComponent;
  let fixture: ComponentFixture<WeightControlForPaymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeightControlForPaymentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeightControlForPaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
