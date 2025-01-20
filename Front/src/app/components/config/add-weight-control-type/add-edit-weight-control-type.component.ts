import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { WeightCotrolTypeService } from '../../../services/weight-cotrol-type.service';
import { WeightControlTypeModel } from '../../../models/WeightControlTypeModel';

@Component({
  selector: 'app-add-edit-weight-control-type',
  standalone: true,
  imports: [RouterLink, CommonModule, FormsModule,ReactiveFormsModule],
  templateUrl: './add-edit-weight-control-type.component.html',
  styleUrl: './add-edit-weight-control-type.component.css'
})
export class AddEditWeightControlTypeComponent {
  formcontroltype: FormGroup;
  AddEdit: string = 'Agrear';
  id: number = -1;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private weightCotrolTypeService: WeightCotrolTypeService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute
  ){
    this.formcontroltype = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['',Validators.maxLength(50)],
      isactive: [true]
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'))
  }
  ngOnInit():void {
    if (this.id != 0) {
      this.AddEdit = 'Editar';
      this.GetById(this.id)
    } 
  }
  GetById(id:number){
    this.weightCotrolTypeService.GetById(id).subscribe(r=>{
      if (r.wasSuccessful == true) {
        this.formcontroltype.setValue({
          name: r.data.name,
          description: r.data.description,
          isactive: r.data.isactive
        })
      } else {
        this.toastr.error("No se pudo recopilar la informacion de la base de datos",'Error')
      }
    })
  }
  CreateOrEdit(){
    const ControlType: WeightControlTypeModel ={
      name: this.formcontroltype.value.name,
      description: this.formcontroltype.value.description,
      isactive: this.formcontroltype.value.isactive
    };
    if (this.id != 0) {
      ControlType.weightcontroltypeid = this.id;
      this.weightCotrolTypeService.Update(ControlType).subscribe(r=>{
        if (r.wasSuccessful == true) {
          this.toastr.success(r.statusMessage)
          this.router.navigate(['/config/WeightControlTypeComponent'])
        } else {
          this.toastr.error(r.statusMessage,'Error')
          this.router.navigate(['/config/WeightControlTypeComponent'])
        }
      })
    } else {
      this.weightCotrolTypeService.Create(ControlType).subscribe(r=>{
        if (r.wasSuccessful == true) {
          this.toastr.success(r.statusMessage)
          this.router.navigate(['/config/WeightControlTypeComponent'])
        } else {
          this.toastr.error(r.statusMessage)
        }
      })
    }
  }
}

