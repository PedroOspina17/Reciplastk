import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ShipmentTypeRequest } from '../../../models/Requests/ShipmentTypeRequest';
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
      if (result.WasSuccessful == true) {
        this.formShipment.setValue({
          name: result.Data.name,
          description: result.Data.description,
          isactive: result.Data.isactive
        });
      } else {
        this.toastr.error(result.Data);
      }
    });
  }
  AddEditShipment() {
    this.loader = true;
    const shipment : ShipmentTypeRequest = {
      Name: this.formShipment.value.name,
      Description: this.formShipment.value.description,
      IsActive: this.formShipment.value.isactive
    };
    if (this.id == 0) {
      this.shipmentTypeservice.Create(shipment).subscribe((result)=>{
        if (result.WasSuccessful == true) {
          this.loader = false;
          this.toastr.success(result.StatusMessage)
          this.router.navigate(['/config/shipmenttype'])
        } else {
          this.loader = false;
          this.toastr.error(result.StatusMessage,'Error')
        }
      })
    } else {
      shipment.Id = this.id;
      this.shipmentTypeservice.Update(shipment,this.id).subscribe((result)=>{
        if (result.WasSuccessful == true) {
          this.loader = false;
          this.toastr.success(result.StatusMessage)
          this.router.navigate(['/config/shipmenttype'])
        } else {
          this.loader = false;
          this.toastr.error(result.StatusMessage,'Error')
          this.router.navigate(['/config/shipmenttype'])
        }
      })
    }
  }
}
