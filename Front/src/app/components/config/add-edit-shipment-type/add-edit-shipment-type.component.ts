import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ShipmentTypeViewModel } from '../../../models/ShipmentTypeViewModel';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ShipmentTypeService } from '../../../services/shipment-type.service';
@Component({
  selector: 'app-add-edit-shipment-type',
  standalone: true,
  imports: [RouterLink, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-edit-shipment-type.component.html',
  styleUrl: './add-edit-shipment-type.component.css',
})
export class AddEditShipmentTypeComponent {
  formShipment: FormGroup;
  AddEdit: string = 'Agrear';
  loader: boolean = false;
  id: number;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private shipmentTypeservice: ShipmentTypeService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute
  ) {
    this.formShipment = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['',Validators.maxLength(50)],
      isactive: [true]
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
    console.log(this.id);
  }
  ngOnInit(): void {
    if (this.id == 0) {
      this.AddEdit = 'Agregar';

    } else {
      this.AddEdit = 'Editar';
      this.GetById(this.id);
    }
  }

  GetById(id: number) {
    this.shipmentTypeservice.GetById(id).subscribe((result) => {
      if (result.wasSuccessful == true) {
        this.formShipment.setValue({
          name: result.data.name,
          description: result.data.description,
          isactive: result.data.isactive
        });
        console.log(this.formShipment)
      } else {
        console.log('Informacion incorrecta');
      }
    });
  }
  AddEditShipment() {
    this.loader = true;
    const shipment : ShipmentTypeViewModel = {
      name: this.formShipment.value.name,
      description: this.formShipment.value.description,
      isactive: this.formShipment.value.isactive
    };
    console.log(shipment,this.formShipment)
    if (this.id == 0) {
      this.shipmentTypeservice.Create(shipment).subscribe((result)=>{
        if (result.wasSuccessful == true) {
          this.loader = false;
          this.toastr.success(result.statusMessage)
          this.router.navigate(['/config/shipmenttype'])
        } else {
          this.loader = false;
          this.toastr.error(result.statusMessage,'Error')
        }
      })
    } else {
      shipment.shipmenttypeid = this.id;
      this.shipmentTypeservice.Update(shipment,this.id).subscribe((result)=>{
        if (result.wasSuccessful == true) {
          this.loader = false;
          this.toastr.success(result.statusMessage)
          this.router.navigate(['/config/shipmenttype'])
        } else {
          this.loader = false;
          this.toastr.error(result.statusMessage,'Error')
          this.router.navigate(['/config/shipmenttype'])
        }
      })
    }
  }
}
