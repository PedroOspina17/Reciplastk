import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialProcessingPricesComponent } from './material-processing-prices.component';

describe('MaterialProcessingPricesComponent', () => {
  let component: MaterialProcessingPricesComponent;
  let fixture: ComponentFixture<MaterialProcessingPricesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaterialProcessingPricesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaterialProcessingPricesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
