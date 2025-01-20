import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeightControlReportsComponent } from './weight-control-reports.component';

describe('WeightControlReportsComponent', () => {
  let component: WeightControlReportsComponent;
  let fixture: ComponentFixture<WeightControlReportsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeightControlReportsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeightControlReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
