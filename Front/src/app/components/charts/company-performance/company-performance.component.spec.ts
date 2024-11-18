import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyPerformanceComponent } from './company-performance.component';

describe('CompanyPerformanceComponent', () => {
  let component: CompanyPerformanceComponent;
  let fixture: ComponentFixture<CompanyPerformanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyPerformanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyPerformanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
