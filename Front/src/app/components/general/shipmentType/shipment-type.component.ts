import { Component } from '@angular/core';
import { LoaderComponent } from "../../shared/loader/loader.component";
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-shipment-type',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule],
  templateUrl: './shipment-type.component.html',
  styleUrl: './shipment-type.component.css'
})
export class ShipmentTypeComponent {

}
