import { CommonModule } from '@angular/common';
import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { MatGridListModule} from '@angular/material/grid-list';
import { MatFormFieldModule} from '@angular/material/form-field';
import { WeightControlModel } from '../../../models/WeightControlModel';
import { WeightcontrolService } from './../../../services/weightcontrol.service';
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
  loading: boolean = false;
  hideDiv: boolean = true;
  titleAction: string = "Agregar";
  id: number;

  listProducts = [
    { id: 1, nombre: 'pp', peso: 15 },
    { id: 2, nombre: 'soplado', peso: 4 },
    { id: 3, nombre: 'ps', peso: 3},
    { id: 4, nombre: 'pasta', peso: 15 },
  ];

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
    }
  }

  ngOnInit(){
    if(this.dateWeightcontrol != null){
      this.formWeightControl.patchValue({
        Weight: this.dateWeightcontrol.Weight,
        TotalPack:  this.dateWeightcontrol.Totalpack ,
        })
    }

  }

  AddWeightControl(){

    const weightControl: WeightControlModel = {

      Weight: this.formWeightControl.value.weight,
      Totalpack: this.formWeightControl.value.totalPack,
      Ispaid: this.formWeightControl.value.Ispaid ,
      Isactive: this.formWeightControl.value.Isactive,
    }

    weightControl.Weightcontrolid = this.id;
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
