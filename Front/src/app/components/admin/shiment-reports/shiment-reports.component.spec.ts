import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShimentReportsComponent } from './shiment-reports.component';

describe('ShimentReportsComponent', () => {
  let component: ShimentReportsComponent;
  let fixture: ComponentFixture<ShimentReportsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShimentReportsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ShimentReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
