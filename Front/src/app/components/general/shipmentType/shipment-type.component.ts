import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ShipmentTypeViewModel } from '../../../models/ShipmentTypeViewModel';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ShipmentTypeService } from '../../../services/shipment-type.service';
import { LoaderComponent } from '../../shared/loader/loader.component';

@Component({
  selector: 'app-shipment-type',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule],
  templateUrl: './shipment-type.component.html',
  styleUrl: './shipment-type.component.css',
})
export class ShipmentTypeComponent {
  ShipmentTypeList: ShipmentTypeViewModel[] = [];
  loader: boolean = false;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private shipmentTypeservice: ShipmentTypeService,
    private toastr: ToastrService
  ) {}
  ngOnInit():void{
    this.GetAll();
  }
  GetAll(){
    this.loader = true;
    this.shipmentTypeservice.GetAll().subscribe(result=>{
      if (result.wasSuccessful == true) {
        this.ShipmentTypeList = result.data;
        this.loader = false;
      }else{
        this.toastr.info("No se encontro ningun cargamento")
      }
    })
  }
  Delete(id2: number){
    this.loader = true;
    this.shipmentTypeservice.Delete(id2).subscribe(result=>{
      if (result.wasSuccessful == true) {
        this.loader = false;
        this.toastr.info(result.statusMessage);
      } else {
        this.toastr.error(result.statusMessage,"Error")
      }
      this.GetAll();
    })
  }
}
