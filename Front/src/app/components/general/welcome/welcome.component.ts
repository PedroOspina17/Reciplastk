import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NavbarProductsComponent } from '../../admin/products/navbar-products/navbar-products.component';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [RouterOutlet, RouterLink, NavbarProductsComponent],
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent {

}
