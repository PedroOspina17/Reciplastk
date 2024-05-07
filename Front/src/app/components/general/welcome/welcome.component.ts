import { Component } from '@angular/core';
import { ListProductsComponent } from '../../admin/products/list-products/list-products.component';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [ListProductsComponent],
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent {

}
