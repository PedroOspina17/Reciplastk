import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWeightControlTypeComponent } from './add-edit-weight-control-type.component';

describe('AddEditWeightControlTypeComponent', () => {
  let component: AddEditWeightControlTypeComponent;
  let fixture: ComponentFixture<AddEditWeightControlTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditWeightControlTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddEditWeightControlTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
