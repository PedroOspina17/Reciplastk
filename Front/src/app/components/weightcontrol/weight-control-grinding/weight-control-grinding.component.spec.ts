import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeightControlGrindingComponent } from './weight-control-grinding.component';

describe('WeightControlGrindingComponent', () => {
  let component: WeightControlGrindingComponent;
  let fixture: ComponentFixture<WeightControlGrindingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeightControlGrindingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeightControlGrindingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
