import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeComparisonComponent } from './employee-comparison.component';

describe('EmployeeComparisonComponent', () => {
  let component: EmployeeComparisonComponent;
  let fixture: ComponentFixture<EmployeeComparisonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeeComparisonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmployeeComparisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
