import { WeightcontrolService } from './../../../services/weightcontrol.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { WeightControlModel } from '../../../models/WeightControlModel';
@Component({
  selector: 'app-separtormodals',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, MatDialogModule],
  templateUrl: './separtormodals.component.html',
  styleUrl: './separtormodals.component.css'
})
export class SepartormodalsComponent implements OnInit{

  formWeightControl: FormGroup;
  ocultarPassword: boolean = true;
  tituloAccion: string = "Agregar";
  botonAccion: string = "Guardar";
  // listProducts: Products[] = [];
  listaProductos: Array<any>= [{nombre:"pp", descripcion:"xxxxx"}, 
    {nombre:"soplado", descripcion:"yyyyy"}, 
    {nombre:"ps",descripcion:"zzzzzz"}, 
    {nombre:"pasta", descripcion:"aaaaaa"}];

  constructor(
    private weightControlService: WeightcontrolService,
    private actualModal: MatDialogRef<SepartormodalsComponent>,
    @Inject(MAT_DIALOG_DATA) public datosweightcontrol: WeightControlModel,
    private fb: FormBuilder,

  ) {
    
    this.formWeightControl = this.fb.group({
      weight: ["", Validators.required],
      totalPack:  ["", Validators.required],
      isActive :  [true, Validators.required]
    });

    if(this.datosweightcontrol != null){
      this.tituloAccion = "Editar";
      this.botonAccion = "Actualizar";

    }
  }

  ngOnInit(): void {
    
  }

  
}
