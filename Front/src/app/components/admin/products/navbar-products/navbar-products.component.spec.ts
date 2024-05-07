import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarProductsComponent } from './navbar-products.component';

describe('NavbarProductsComponent', () => {
  let component: NavbarProductsComponent;
  let fixture: ComponentFixture<NavbarProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavbarProductsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NavbarProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
