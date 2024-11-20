import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCustomerTypeComponent } from './add-edit-customer-type.component';

describe('AddEditCustomerTypeComponent', () => {
  let component: AddEditCustomerTypeComponent;
  let fixture: ComponentFixture<AddEditCustomerTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditCustomerTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddEditCustomerTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
