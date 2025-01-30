import { Component } from '@angular/core';
import { WeightControlTypeRequest } from '../../../models/Requests/WeightControlTypeRequest';
import { WeightCotrolTypeService } from '../../../services/weight-cotrol-type.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-weight-control-type',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './weight-control-type.component.html',
  styleUrl: './weight-control-type.component.css',
})
export class WeightControlTypeComponent {
  constructor(
    private controlType: WeightCotrolTypeService,
    private toastr: ToastrService
  ) { }
  controlTypeList: WeightControlTypeRequest[] = [];
  loader: boolean = false;
  DeletePopUp: boolean = false;
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll() {
    this.loader = true;
    this.controlType.GetAll().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.controlTypeList = r.Data;
      } else {
        this.toastr.info('No se encontro nigun tipo de control de peso');
      }
    });
    this.loader = false;
  }
  Delete(id: number) {

    this.DeletePopUp = true
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'Esto borrara todos los datos previamente almacenados en la tabla.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FFA500 ',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Sí, Eliminar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.controlType.Delete(id).subscribe(r => {
          if (r.WasSuccessful == true) {
            this.toastr.info(r.StatusMessage);
          } else {
            this.toastr.info(r.StatusMessage);
          }
          this.GetAll();
        });
      } else {
        this.DeletePopUp = false;
      }
    });
  }
}
