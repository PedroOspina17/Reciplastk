import { Component } from '@angular/core';
import { WeightControlTypeModel } from '../../../models/WeightControlTypeModel';
import { WeightCotrolTypeService } from '../../../services/weight-cotrol-type.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weight-control-type',
  standalone: true,
  imports: [CommonModule, RouterLink, LoaderComponent],
  templateUrl: './weight-control-type.component.html',
  styleUrl: './weight-control-type.component.css',
})
export class WeightControlTypeComponent {
  constructor(
    private fb: FormBuilder,
    private controlType: WeightCotrolTypeService,
    private toastr: ToastrService,
    private httplcient: HttpClient
  ) {}
  controlTypeList: WeightControlTypeModel[] = [];
  loader: boolean = false;
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll() {
    this.loader = true;
    this.controlType.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.controlTypeList = r.data;
        console.log(this.controlTypeList);
      } else {
        this.toastr.info('No se encontro nigun tipo de control de peso');
      }
    });
    this.loader = false;
  }
  Delete(id:number){
    this.controlType.Delete(id).subscribe(r=>{
      if (r.wasSuccessful == true) {
        this.toastr.info(r.statusMessage);
      } else {
        this.toastr.info(r.statusMessage);
      }
      this.GetAll();
    });
  }
}
