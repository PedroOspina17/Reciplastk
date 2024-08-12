import { WeightcontrolService } from './../../../services/weightcontrol.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import { WeightControlModel } from '../../../models/WeightControlModel';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-separtormodals',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, MatDialogModule, MatGridListModule, MatFormFieldModule],
  templateUrl: './separtormodals.component.html',
  styleUrl: './separtormodals.component.css'
})
export class SepartormodalsComponent implements OnInit{

  formWeightControl: FormGroup;
  hidePassword: boolean = true;
  titleAction: string = "Agregar";
  buttonAction: string = "Guardar";
  id: number;
  // listProducts: Products[] = [];
  listProducts: Array<any>= [{nombre:"pp", descripcion:"xxxxx"},
    {nombre:"soplado", descripcion:"yyyyy"},
    {nombre:"ps",descripcion:"zzzzzz"},
    {nombre:"pasta", descripcion:"aaaaaa"}];

  constructor(
    private fb: FormBuilder,
    private weightControlService: WeightcontrolService,
    private actualModal: MatDialogRef<SepartormodalsComponent>,
    @Inject(MAT_DIALOG_DATA) public dateWeightcontrol: WeightControlModel,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService,
  ) {

    this.formWeightControl = this.fb.group({
      weight: ["", Validators.required],
      totalPack:  ["", Validators.required],
      isActive :  [true, Validators.required]
    });

    this.id = Number(aRoute.snapshot.paramMap.get('id'));
    if(this.id != 0){
      this.titleAction = "Editar";
      this.buttonAction = "Actualizar";

    }
  }

  ngOnInit(): void {
    if(this.dateWeightcontrol != null){
      this.formWeightControl.patchValue({
        weight: this.dateWeightcontrol.weight,
        totalPack:  this.dateWeightcontrol.totalpack ,
        isActive :  this.dateWeightcontrol.isactive,
      })
    }

  }

  AddAndEditWeightControl(): void{

    const weightControl: WeightControlModel = {

      alternateid: this.formWeightControl.value.alternateid,
      weight: this.formWeightControl.value.weight,
      totalpack: this.formWeightControl.value.totalPack,
      ispaid: this.formWeightControl.value.ispaid ,
      isactive: this.formWeightControl.value.isactive,
    }

    weightControl.weightcontrolid = this.id;
    if(this.id !=0){
      this.weightControlService.Update(weightControl).subscribe((result)=>{
        if(result.wasSuccessful){
          this.toastr.info("El registro fue modificado con exito, Registro Creado")
          this.actualModal.close("true")
        }else{
          this.toastr.info("El registro no pudo ser modificado,Error")
        }
      })
    }else{
      this.weightControlService.Create(weightControl).subscribe((result)=>{
        if(result.wasSuccessful){
          this.toastr.success("El registro fue creado exitosamente", "Registro Creado");
          this.actualModal.close("true")
        }else{
          this.toastr.info("El registro no pudo ser creado, Error")
        }

      })
    }

  }


}
